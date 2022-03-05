using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseExtractInputModel
    {
        [Required]
        [Display(Name = "Mese")]
        public string Mese { get; set; }

        [Required]
        [Display(Name = "Anno")]
        public string Anno { get; set; }
    }
}