using Blazor.FacileBudget.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseCreateInputModel
    {
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Display(Name = "Importo")]
        public Money Importo { get; set; }
    }
}
