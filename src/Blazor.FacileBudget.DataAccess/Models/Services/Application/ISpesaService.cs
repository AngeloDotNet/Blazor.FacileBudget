using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Application
{
    public interface ISpesaService
    {
        Task<List<SpesaViewModel>> GetSpese();
        Task CreateSpesa(SpeseCreateInputModel inputModel);
        Task<List<SpesaViewModel>> ExtractSpese(SpeseExtractInputModel inputModel);
        Task<bool> IsSpeseAvailableAsync(SpeseExtractInputModel inputModel);
        Task<StringBuilder> CreateExcel(SpeseExtractInputModel inputModel);
        decimal SumSpese(SpeseExtractInputModel inputModel);
        Task<SpesaViewModel> GetSpesa(int spesaId);
        Task DeleteSpesa(int spesaId);
    }
}