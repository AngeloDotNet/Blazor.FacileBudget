using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder => { 
                webHostBuilder.UseStartup<Startup>(); // Usare solo per il debug, lasciare commentato per il deploy su IIS

                //// Per eseguire il deploy su IIS, decommentare il codice sottostante e lanciare il comando: dotnet publish --configuration Release
                //webHostBuilder.UseStartup<Startup>()
                //.UseSerilog((webHostBuilderContext, loggerConfiguration) => 
                //{
                //    loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                //});
            });
    }
}
