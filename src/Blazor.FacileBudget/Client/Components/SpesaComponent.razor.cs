using Blazor.FacileBudget.Models.InputModels;
using Microsoft.AspNetCore.Components;

namespace Blazor.FacileBudget.Client.Components
{
    public partial class SpesaComponent : ComponentBase
    {
        [Parameter]
        public SpeseCreateInputModel spesa { get; set; }
    }
}