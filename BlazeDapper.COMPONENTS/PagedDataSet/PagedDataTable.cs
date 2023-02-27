using BlazeDapper.MODELS.DAL;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class PagedDataTable<T> : ComponentBase where T : class
    {
        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        [Parameter]
        public PagedResultSet<List<T>> pagedTableData { get; set; } = new PagedResultSet<List<T>>();
    }
}
