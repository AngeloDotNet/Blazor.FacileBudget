using Blazor.FacileBudget.Models.InputModels;
using Blazor.FacileBudget.Models.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.Client.Pages
{
    public partial class Spese : ComponentBase
    {
        private SpeseExtractInputModel MeseNow = new()
        {
            Mese = DateTime.Now.ToString("MM"),
            Anno = DateTime.Now.ToString("yyyy")
        };

        private SpeseExtractInputModel mesePrev1 = new()
        {
            Mese = DateTime.Now.AddMonths(-1).ToString("MM"),
            Anno = DateTime.Now.AddMonths(-1).ToString("yyyy")
        };

        private SpeseExtractInputModel mesePrev2 = new()
        {
            Mese = DateTime.Now.AddMonths(-2).ToString("MM"),
            Anno = DateTime.Now.AddMonths(-2).ToString("yyyy")
        };

        List<SpesaViewModel> spese = new();
        List<SpesaViewModel> ListaMeseNow = new();
        List<SpesaViewModel> ListaMesePrev1 = new();
        List<SpesaViewModel> ListaMesePrev2 = new();

        private string TotaleSpese = string.Empty;

        private int rowsPerPage = 10; //Questo valore deve essere presente anche in pageSizeOptions così da poter permettere di tornare al valore dopo un eventuale cambiamento.
        private int[] pageSizeOptions = new int[] { 5, 10, 15 };

        private bool hideRowsPerPage;
        private bool hidePageNumber;
        private bool hidePagination;

        private bool hasError = false;
        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            await Task.Delay(3000);

            try
            {
                await CheckingData();

                if (spese.Count <= rowsPerPage)
                {
                    hideRowsPerPage = true;
                    hidePageNumber = true;
                    hidePagination = true;
                }
                else
                {
                    hideRowsPerPage = true;
                    hidePageNumber = false;
                    hidePagination = false;
                }
            }
            catch (Exception)
            {
                hasError = true;
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task CheckingData()
        {
            spese = await spesaService.GetAllData();
            TotaleSpese = await spesaService.GetTotalSpese(MeseNow);

            ListaMeseNow = await spesaService.Extract(MeseNow);
            ListaMesePrev1 = await spesaService.Extract(mesePrev1);
            ListaMesePrev2 = await spesaService.Extract(mesePrev2);
        }

        public void NuovaSpesa()
        {
            navigationManager.NavigateTo("/spesa", false);
        }

        public void ReportMeseNow()
        {
            navigationManager.NavigateTo($"api/Budget/GeneraExcel/?Mese={MeseNow.Mese}&Anno={MeseNow.Anno}", true);
        }

        public void ReportMesePrev1()
        {
            navigationManager.NavigateTo($"api/Budget/GeneraExcel/?Mese={mesePrev1.Mese}&Anno={mesePrev1.Anno}", true);
        }

        public void ReportMesePrev2()
        {
            navigationManager.NavigateTo($"api/Budget/GeneraExcel/?Mese={mesePrev2.Mese}&Anno={mesePrev2.Anno}", true);
        }
    }
}