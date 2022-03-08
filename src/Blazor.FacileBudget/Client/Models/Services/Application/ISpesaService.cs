using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Client.Models.Services.Application
{
    public interface ISpesaService
    {
        Task GetAllData();
        Task<bool> Create(SpeseCreateInputModel inputModel);
        Task<List<SpesaViewModel>> Extract(SpeseExtractInputModel inputModel);
    }
}