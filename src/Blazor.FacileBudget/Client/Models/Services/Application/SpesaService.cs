using System.Collections.Generic;
using System.Net;
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

        public List<SpesaViewModel> spese { get; set; }
        public SpesaViewModel spesa { get; set; }

        public async Task<List<SpesaViewModel>> GetAllData()
        {
            spese = await httpClient.GetFromJsonAsync<List<SpesaViewModel>>("api/Budget/ListaSpese");
            return spese;
        }

        public async Task<bool> Create(SpeseCreateInputModel inputModel)
        {
            var bRes = await httpClient.PostAsJsonAsync<SpeseCreateInputModel>("api/Budget/CreaSpesa", inputModel);
            
            if (bRes.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SpesaViewModel>> Extract(SpeseExtractInputModel inputModel)
        {
            spese = await httpClient.GetFromJsonAsync<List<SpesaViewModel>>($"api/Budget/EstraiSpese/?Mese={inputModel.Mese}&Anno={inputModel.Anno}");
            return spese;
        }

        public async Task<string> GetTotalSpese(SpeseExtractInputModel inputModel)
        {
            string totale = await httpClient.GetStringAsync($"api/Budget/TotaleSpese/?Mese={inputModel.Mese}&Anno={inputModel.Anno}");
            return totale;
        }

        public async Task<SpesaViewModel> GetSpesa(int SpesaId)
        {
            spesa = await httpClient.GetFromJsonAsync<SpesaViewModel>($"api/Budget/DettaglioSpesa/{SpesaId}");
            return spesa;
        }

        public async Task<bool> DeleteSpesa(int SpesaId)
        {
            var bRes = await httpClient.DeleteAsync($"api/Budget/CancellaSpesa/{spesa.SpesaId}");

            if (bRes.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}