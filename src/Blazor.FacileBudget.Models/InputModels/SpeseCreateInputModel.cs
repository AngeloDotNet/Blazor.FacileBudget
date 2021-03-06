using Blazor.FacileBudget.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseCreateInputModel
    {
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "La valuta è obbligatoria")]
        [Display(Name = "Valuta")]
        public string Importo_Currency { get; set; }
        
        [Required(ErrorMessage = "L'importo è obbligatorio")]
        [Display(Name = "Importo")]
        public string Importo_Amount { get; set; }

        public Money Importo { get; set; }
    }
}
