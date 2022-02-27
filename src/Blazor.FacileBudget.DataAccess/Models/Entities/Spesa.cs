using Blazor.FacileBudget.Models.ValueObjects;

namespace Blazor.FacileBudget.DataAccess.Models.Entities
{
    public partial class Spesa
    {
        public int SpesaId { get; set; }
        public string Descrizione { get; set; }
        public Money Importo { get; set; }
        public string Mese { get; set; }
        public string Anno { get; set; }
    }
}