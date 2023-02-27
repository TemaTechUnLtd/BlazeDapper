using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class DataHeaderRow<T> : ComponentBase where T : class
    {
        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        private async Task GetFilteredData()
        {
            await TopPage.GetFilteredData();
        }

        private async Task ClearFilters()
        {
            await TopPage.TaskClearFilters();
        }
    }
}
