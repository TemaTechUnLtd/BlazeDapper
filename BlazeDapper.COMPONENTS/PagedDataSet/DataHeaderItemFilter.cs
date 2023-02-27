using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class DataHeaderItemFilter<T> : ComponentBase where T : class
    {
        [Parameter]
        public string SearchTerm { get; set; }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public string ColumnName { get; set; }

        [Parameter]
        public string DisplayName { get; set; }

        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        private void BindToFilter()
        {
            var filter = TopPage.ColumnFilters.Where(f => f.ColumnName == ColumnName).SingleOrDefault();

            if (filter != null)
            {
                filter.SearchTerms[Index] = SearchTerm;
            }
        }
    }
}
