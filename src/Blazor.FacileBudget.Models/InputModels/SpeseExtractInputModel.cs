using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseExtractInputModel
    {
        [Required(ErrorMessage = "Il mese è obbligatorio")]
        [Display(Name = "Mese")]
        public string Mese { get; set; }

        [Required(ErrorMessage = "L'anno è obbligatorio")]
        [Display(Name = "Anno")]
        public string Anno { get; set; }
    }
}