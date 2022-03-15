using Blazor.FacileBudget.Models.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Blazor.FacileBudget.Components
{
    public partial class SpeseComponent : ComponentBase
    {
        [Parameter]
        public List<SpesaViewModel> Spese { get; set; }

        [Parameter]
        public int RowsPerPage { get; set; }

        [Parameter]
        public int[] PageSizeOptions { get; set; }

        [Parameter]
        public bool HideRowsPerPage { get; set; }

        [Parameter]
        public bool HidePageNumber { get; set; }

        [Parameter]
        public bool HidePagination { get; set; }

        [Parameter]
        public bool HasError { get; set; }

        [Parameter]
        public bool IsLoading { get; set; }
    }
}
