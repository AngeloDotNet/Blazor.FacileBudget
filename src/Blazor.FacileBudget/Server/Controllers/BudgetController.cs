using Blazor.FacileBudget.DataAccess.Models.Services.Application;
using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
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
            try 
            {
                await spesaService.CreateSpesa(inputModel);
                return Ok();
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("EstraiSpese")]
        public async Task<IActionResult> ExtractSpeseAsync([FromQuery] SpeseExtractInputModel periodo)
        {
            var spese = await spesaService.ExtractSpese(periodo);
            return Ok(spese);
        }

        [HttpGet("TotaleSpese")]
        public decimal GetTotaleSpeseAsync([FromQuery] SpeseExtractInputModel periodo)
        {
            var spese = spesaService.SumSpese(periodo);
            return spese;
        }

        [HttpGet("GeneraExcel")]
        public async Task<FileResult> GenerateExcel([FromQuery] SpeseExtractInputModel periodo)
        {
            string SelMese = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(periodo.Mese)).ToString();
            string FileName = "Report_" + SelMese + "_" + periodo.Anno.ToString() + ".csv";

            StringBuilder sb = await spesaService.CreateExcel(periodo);

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", FileName);
        }

        [HttpGet("DettaglioSpesa/{spesaId}")]
        public async Task<IActionResult> GetSpesaAsync(int spesaId)
        {
            try
            {
                SpesaViewModel spesa = await spesaService.GetSpesa(spesaId);
                return Ok(spesa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("CancellaSpesa/{spesaId}")]
        public async Task<IActionResult> DeleteSpesa(int spesaId)
        {
            try
            {
                await spesaService.DeleteSpesa(spesaId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}