using Blazor.FacileBudget.DataAccess.Models.Entities;
using Blazor.FacileBudget.Models.ViewModels;

namespace Blazor.FacileBudget.DataAccess.Models.Extensions
{
    public static class SpesaExtension
    {
        public static SpesaViewModel ToSpesaViewModel(this Spesa spesa)
        {
            return new SpesaViewModel
            {
                SpesaId = spesa.SpesaId,
                Descrizione = spesa.Descrizione,
                Importo = spesa.Importo,
                Mese = spesa.Mese,
                Anno = spesa.Anno
            };
        }
    }
}