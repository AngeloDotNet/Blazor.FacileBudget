using Blazor.FacileBudget.DataAccess.Models.Entities;
using Blazor.FacileBudget.DataAccess.Models.Extensions;
using Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure;
using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Application
{
    public class EfCoreSpesaService : ISpesaService
    {
        private readonly ILogger<FacileBudgetDbContext> logger;
        private readonly FacileBudgetDbContext dbContext;
        private readonly ITransactionLogger transactionLogger;

        public EfCoreSpesaService(ILogger<FacileBudgetDbContext> logger, FacileBudgetDbContext dbContext, ITransactionLogger transactionLogger)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.transactionLogger = transactionLogger;
        }

        private string meseCorrente = DateTime.Now.ToString("MM");
        private string annoCorrente = DateTime.Now.ToString("yyyy");

        public async Task<List<SpesaViewModel>> GetSpese()
        {
            IQueryable<Spesa> baseQuery = dbContext.Spese;

            IQueryable<Spesa> queryLinq = baseQuery
                .Where(spesa => spesa.Mese.Contains(meseCorrente) && spesa.Anno.Contains(annoCorrente))
                .AsNoTracking();

            List<SpesaViewModel> spese = await queryLinq
                .Select(spesa => spesa.ToSpesaViewModel())
                .ToListAsync();

            return spese;
        }

        public async Task CreateSpesa(SpeseCreateInputModel inputModel)
        {
            var spesa = new Spesa
            {
                Descrizione = inputModel.Descrizione,
                Importo = inputModel.Importo,
                Mese = meseCorrente,
                Anno = annoCorrente
            };

            dbContext.Spese.Add(spesa);

            try
            {
                string data = meseCorrente + "/" + annoCorrente;
                logger.LogInformation("Aggiunta spesa " + inputModel.Descrizione + " con importo " + inputModel.Importo + " in data " + data + "");

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                logger.LogError("Si è verificato un errore, aggiornato il transaction logger");
                await transactionLogger.LogTransactionAsync(inputModel);
            }
        }
    }
}