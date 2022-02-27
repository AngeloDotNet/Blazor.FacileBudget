using Blazor.FacileBudget.DataAccess.Models.Entities;
using Blazor.FacileBudget.DataAccess.Models.Extensions;
using Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure;
using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Application
{
    public class EfCoreSpesaService : ISpesaService
    {
        private readonly FacileBudgetDbContext dbContext;

        public EfCoreSpesaService(FacileBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            await dbContext.SaveChangesAsync();
        }
    }
}
