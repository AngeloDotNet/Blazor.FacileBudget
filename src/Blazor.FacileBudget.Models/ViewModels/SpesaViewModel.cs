using Blazor.FacileBudget.Models.ValueObjects;

namespace Blazor.FacileBudget.Models.ViewModels
{
    public class SpesaViewModel
    {
        public int SpesaId { get; set; }
        public string Descrizione { get; set; }
        public Money Importo { get; set; }
        public string Mese { get; set; }
        public string Anno { get; set; }
    }
}