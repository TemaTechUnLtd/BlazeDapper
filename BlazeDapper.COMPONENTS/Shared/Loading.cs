using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.Shared
{
    public partial class Loading : ComponentBase
    {
        [Parameter]
        public bool IsLoading { get; set; }

        [Parameter]
        public string LoadingText { get; set; } = "Loading...";

        [Parameter]
        public RenderFragment LoadingTemplate { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}