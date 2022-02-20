using Blazor.FacileBudget.Models.InputModels;
using FluentValidation;

namespace Blazor.FacileBudget.Validation
{
    public class SpeseCreateValidator : AbstractValidator<SpeseCreateInputModel>
    {
        public SpeseCreateValidator()
        {
            RuleFor(m => m.Descrizione)
                .NotEmpty().WithMessage("La descrizione è obbligatoria")
                .MinimumLength(2).WithMessage("La descrizione dev'essere di almeno {MinLength} caratteri");

            RuleFor(m => m.Importo)
                .NotEmpty().WithMessage("L'importo è obbligatorio");
        }
    }
}
