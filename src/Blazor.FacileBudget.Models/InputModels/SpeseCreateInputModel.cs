using Blazor.FacileBudget.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseCreateInputModel
    {
        [Required]
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Required]
        [Display(Name = "Valuta")]
        public string Importo_Currency { get; set; }
        
        [Required]
        [Display(Name = "Importo")]
        public string Importo_Amount { get; set; }

        public Money Importo { get; set; }
    }
}
