using Blazor.FacileBudget.Models.InputModels;
using FluentValidation;

namespace Blazor.FacileBudget.Validation
{
    public class SpeseExtractValidator : AbstractValidator<SpeseExtractInputModel>
    {
        public SpeseExtractValidator()
        {
            RuleFor(m => m.Mese)
                .NotEmpty().WithMessage("Il mese è obbligatoria")
                .Length(2).WithMessage("Il mese dev'essere di {MaxLength} caratteri");

            RuleFor(m => m.Anno)
                .NotEmpty().WithMessage("L'anno è obbligatorio")
                .Length(4).WithMessage("L'anno dev'essere di {MaxLength} caratteri");
        }
    }
}