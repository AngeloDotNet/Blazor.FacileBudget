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
        SpeseCreateInputModel spesa = new();

        public void Cancel()
        {
            navigationManager.NavigateTo("/spese");
        }

        private async Task Create()
        {
            string NuovoImporto = spesa.Importo_Amount.Replace(".", ",");

            SpeseCreateInputModel NuovaSpesa = new()
            {
                Descrizione = spesa.Descrizione,
                Importo_Amount = spesa.Importo_Amount,
                Importo_Currency = spesa.Importo_Currency,
                Importo = new Money(Enum.Parse<Currency>(Convert.ToString(spesa.Importo_Currency)), Convert.ToDecimal(NuovoImporto, new CultureInfo("it-IT")))
            };

            bool result = await spesaService.Create(NuovaSpesa);

            if (result == true)
            {
                Snackbar.Add("Spesa inserita con successo !", Severity.Success);

                await Task.Delay(5000);
                navigationManager.NavigateTo("/spese");
            }
            else
            {
                Snackbar.Add("Spesa non inserita, riprovare !", Severity.Error);
            }
        }
    }
}