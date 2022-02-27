using Blazor.FacileBudget.Models.InputModels;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure;
using System;

namespace Blazor.FacileBudget.Server.Models.Services.Infrastructure
{
    public class LocalTransactionLogger : ITransactionLogger
    {
        private readonly IHostEnvironment env;
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public LocalTransactionLogger(IHostEnvironment env)
        {
            this.env = env;
        }

        private string meseCorrente = DateTime.Now.ToString("MM");
        private string annoCorrente = DateTime.Now.ToString("yyyy");

        public async Task LogTransactionAsync(SpeseCreateInputModel inputModel)
        {
            string filePath = Path.Combine(env.ContentRootPath, "Data", "transactions.txt");
            string content = $"\r\n{inputModel.Descrizione}\t{inputModel.Importo}\t{meseCorrente}\t{annoCorrente}";

            try
            {
                await semaphore.WaitAsync();
                await File.AppendAllTextAsync(filePath, content);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}