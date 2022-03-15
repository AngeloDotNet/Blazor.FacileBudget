using Blazor.FacileBudget.Models.InputModels;
using Microsoft.AspNetCore.Components;

namespace Blazor.FacileBudget.Components
{
    public partial class SpesaComponent : ComponentBase
    {
        [Parameter]
        public SpeseCreateInputModel Spesa { get; set; }
    }
}