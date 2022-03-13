using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Client.Models.Services.Application
{
    public interface ISpesaService
    {
        Task<List<SpesaViewModel>> GetAllData();
        Task<bool> Create(SpeseCreateInputModel inputModel);
        Task<List<SpesaViewModel>> Extract(SpeseExtractInputModel inputModel);
        Task<string> GetTotalSpese(SpeseExtractInputModel inputModel);
        Task<SpesaViewModel> GetSpesa(int SpesaId);
        Task<bool> DeleteSpesa(int SpesaId);
    }
}