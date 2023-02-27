using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class Paging<T> : ComponentBase where T : class
    {
        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        private async Task GetNextPage()
        {
            await TopPage.GetNextPage();
        }

        private async Task GetPreviousPage()
        {
            await TopPage.GetPreviousPage();
        }
    }
}
