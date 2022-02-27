using Blazor.FacileBudget.DataAccess.Models.Services.Application;
using Blazor.FacileBudget.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
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
    }
}