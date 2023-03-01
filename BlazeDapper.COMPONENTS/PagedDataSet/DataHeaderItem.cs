using BlazeDapper.MODELS.DAL;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class DataHeaderItem<T> : ComponentBase where T : class
    {
        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        [Parameter]
        public QueryFilter ColumnHeader { get; set; }

        private async Task GetSortedData(string sortColumn)
        {
            await TopPage.GetSortedData(sortColumn);
        }

        public async Task GetFilteredData()
        {
            await TopPage.GetFilteredData();
        }

        private void AddSearchTerm()
        {
            if (ColumnHeader.SearchTerms.Count < 5)
            {
                ColumnHeader.SearchTerms.Add("");
            }
        }

        private void RemoveSearchTerm()
        {
            int listCount = ColumnHeader.SearchTerms.Count;

            if (listCount > 1)
            {
                ColumnHeader.SearchTerms.RemoveAt(listCount - 1);
            }
        }

        private void SetFilterType()
        {
            TimeSpan span = new TimeSpan(23, 59, 59);

            if (ColumnHeader.ToDate != null && ColumnHeader.FromDate != null)
            {
                ColumnHeader.FilterType = FilterType.Between;
                ColumnHeader.ToDate = ColumnHeader.ToDate.Value.Date.Add(span);
            }

            if (ColumnHeader.ToDate == null && ColumnHeader.FromDate != null)
                ColumnHeader.FilterType = FilterType.After;

            if (ColumnHeader.ToDate != null && ColumnHeader.FromDate == null)
                ColumnHeader.FilterType = FilterType.Before;
        }
    }
}
