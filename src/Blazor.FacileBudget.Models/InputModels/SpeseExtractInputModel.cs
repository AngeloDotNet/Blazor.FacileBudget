using System.ComponentModel.DataAnnotations;

namespace Blazor.FacileBudget.Models.InputModels
{
    public class SpeseExtractInputModel
    {
        [Display(Name = "Mese")]
        public string Mese { get; set; }

        [Display(Name = "Anno")]
        public string Anno { get; set; }
    }
}