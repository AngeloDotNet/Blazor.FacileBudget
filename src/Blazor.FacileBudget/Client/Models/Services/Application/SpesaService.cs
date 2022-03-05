using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;

namespace Blazor.FacileBudget.Client.Models.Services.Application
{
    public class SpesaService : ISpesaService
    {
        private HttpClient httpClient;

        public SpesaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<SpesaViewModel> Spese { get; set; }

        public SpeseCreateInputModel Spesa { get; set; }

        public async Task GetAllData()
        {
            Spese = await httpClient.GetFromJsonAsync<List<SpesaViewModel>>("api/Budget/ListaSpese");
        }

        public async Task Create(SpeseCreateInputModel inputModel)
        {
            await httpClient.PostAsJsonAsync<SpeseCreateInputModel>("api/Budget/CreaSpesa", inputModel);
        }

        public async Task<List<SpesaViewModel>> Extract(SpeseExtractInputModel inputModel)
        {
            Spese = await httpClient.GetFromJsonAsync<List<SpesaViewModel>>($"api/Budget/EstraiSpese/?Mese={inputModel.Mese}&Anno={inputModel.Anno}");
            return Spese;
        }
    }
}