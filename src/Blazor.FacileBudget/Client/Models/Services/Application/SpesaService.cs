using Blazor.FacileBudget.Models.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        public async Task GetAllSpese()
        {
            Spese = await httpClient.GetFromJsonAsync<List<SpesaViewModel>>("api/Budget/ListaSpese");
        }
    }
}
