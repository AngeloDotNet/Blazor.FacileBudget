using Blazor.FacileBudget.Models.Enums;
using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ValueObjects;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Client.Pages
{
    public partial class Spesa : ComponentBase
    {
        SpeseCreateInputModel SpesaInputModel = new();

        public void Cancel()
        {
            navigationManager.NavigateTo("/spese", false);
        }

        private async Task Create()
        {
            string NuovoImporto = SpesaInputModel.Importo_Amount.Replace(".", ",");

            SpeseCreateInputModel NuovaSpesa = new()
            {
                Descrizione = SpesaInputModel.Descrizione,
                Importo_Amount = SpesaInputModel.Importo_Amount,
                Importo_Currency = SpesaInputModel.Importo_Currency,
                Importo = new Money(Enum.Parse<Currency>(Convert.ToString(SpesaInputModel.Importo_Currency)), Convert.ToDecimal(NuovoImporto, new CultureInfo("it-IT")))
            };

            bool result = await spesaService.Create(NuovaSpesa);

            if (result == true)
            {
                Snackbar.Add("Spesa inserita con successo !", Severity.Success);

                await Task.Delay(5000);
                navigationManager.NavigateTo("/spese", false);
            }
            else
            {
                Snackbar.Add("Spesa non inserita, riprovare !", Severity.Error);
            }
        }
    }
}