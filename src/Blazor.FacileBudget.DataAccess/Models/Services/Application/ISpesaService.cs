using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Application
{
    public interface ISpesaService
    {
        Task<List<SpesaViewModel>> GetSpese();
        Task CreateSpesa(SpeseCreateInputModel inputModel);
    }
}