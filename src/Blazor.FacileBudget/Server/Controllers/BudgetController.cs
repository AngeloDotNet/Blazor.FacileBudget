using Blazor.FacileBudget.DataAccess.Models.Services.Application;
using Blazor.FacileBudget.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : Controller
    {
        private readonly ISpesaService spesaService;

        public BudgetController(ISpesaService spesaService)
        {
            this.spesaService = spesaService;
        }

        [HttpGet("ListaSpese")]
        public async Task<IActionResult> GetSpeseAsync()
        {
            var spese = await spesaService.GetSpese();
            return Ok(spese);
        }

        [HttpPost("CreaSpesa")]
        public async Task<IActionResult> CreateSpesaAsync(SpeseCreateInputModel inputModel)
        {
            await spesaService.CreateSpesa(inputModel);
            return NoContent();
        }

        [HttpPost("EstraiSpese")]
        public async Task<IActionResult> ExtractSpeseAsync(SpeseExtractInputModel inputModel)
        {
            var spese = await spesaService.ExtractSpese(inputModel);
            return Ok(spese);
        }

        [HttpPost("VerificaSpese")]
        public async Task<bool> CheckSpeseAsync(SpeseExtractInputModel inputModel)
        {
            bool result = await spesaService.IsSpeseAvailableAsync(inputModel);
            return result;
        }

        [HttpPost("GeneraExcel")]
        public async Task<FileResult> GenerateExcel(SpeseExtractInputModel inputModel)
        {
            string SelMese = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(inputModel.Mese)).ToString();
            string FileName = "Report_" + SelMese + "_" + inputModel.Anno.ToString() + ".csv";

            StringBuilder sb = await spesaService.CreateExcel(inputModel);

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", FileName);
        }
    }
}