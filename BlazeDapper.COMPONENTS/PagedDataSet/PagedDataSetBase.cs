namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    using BlazeDapper.MODELS;
    using BlazeDapper.MODELS.DAL;
    using BlazeDapper.MODELS.Utilities;
    using Microsoft.AspNetCore.Components;

    public abstract class PagedDataSetBase<T> : ComponentBase where T : class
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }      

        [Parameter]
        public int Id { get; set; }

        private PagedDataRequest pagedDataRequest { get; set; }

        public PagingData pagingData { get; set; } = new PagingData();

        public PagedResultSet<List<T>> pagedResultSet { get; set; }

        public string Message { get; set; }

        public List<QueryFilter> ColumnFilters { get; set; } = new List<QueryFilter>();

        public bool IsLoading { get; set; }

        #region Data Retrieval

        protected override async Task OnInitializedAsync()
        {
            PagingRequest pagingRequest = new();

            FilterColumns.GetColumnHeadings<T>(pagingRequest, ColumnFilters);

            pagedDataRequest = new PagedDataRequest { FilterSet = ColumnFilters, Paging = pagingRequest };
            IsLoading = true;

            if (Id > 0)//todo: find a more generic way fo doing this. Should not be hardcoding in identifier coloumn
            {
                var patientFilter = ColumnFilters.SingleOrDefault(cf => cf.ColumnName == "Id");

                if (patientFilter != null)
                {
                    patientFilter.SearchTerms[0] = Id.ToString();
                }

                pagedResultSet = await GetItems(pagedDataRequest);

                if (pagedResultSet != null)
                {
                    pagingData.SetPagingInfo(pagedResultSet);
                }
            }
            IsLoading = false;
        }

        public async Task GetNextPage()
        {
            IsLoading = true;
            StateHasChanged();

            pagedDataRequest.Paging.PageNumber = pagedResultSet.CurrentPageNumber + 1;

            pagedResultSet = await GetItems(pagedDataRequest);
            if (pagedResultSet != null)
            {
                pagingData.SetPagingInfo(pagedResultSet);
            }

            IsLoading = false;
            StateHasChanged();
        }

        public async Task GetPreviousPage()
        {
            IsLoading = true;
            StateHasChanged();

            if (pagedResultSet.CurrentPageNumber == 1)
                return;

            pagedDataRequest.Paging.PageNumber = pagedResultSet.CurrentPageNumber - 1;

            pagedResultSet = await GetItems(pagedDataRequest);

            if (pagedResultSet != null)
            {
                pagingData.SetPagingInfo(pagedResultSet);
               
            }

            IsLoading = false;
            StateHasChanged();
        }

        public async Task GetSortedData(string sortColumn)
        {
            IsLoading = true;
            StateHasChanged();

            if (pagedDataRequest.Paging.OrderColumn == sortColumn)
            {
                pagedDataRequest.Paging.OrderDescending = !this.pagedDataRequest.Paging.OrderDescending;
            }
            else
            {
                pagedDataRequest.Paging.OrderColumn = sortColumn;
                pagedDataRequest.Paging.OrderDescending = false;
            }

            pagedDataRequest.Paging.PageNumber = 1;

            pagedResultSet = await GetItems(pagedDataRequest);

            if (pagedResultSet != null)
            {
                pagingData.SetPagingInfo(pagedResultSet);
               
            }

            IsLoading = false;
            StateHasChanged();
        }

        public async Task GetFilteredData()
        {
            IsLoading = true;
            StateHasChanged();

            pagedDataRequest.FilterSet = ColumnFilters;
            pagedDataRequest.Paging.PageNumber = 1;

            pagedResultSet = await GetItems(pagedDataRequest);

            if (pagedResultSet != null && pagedResultSet.Data.Count > 0)
            {
                pagingData.SetPagingInfo(pagedResultSet);
               
            }
            else
            {
                Message = "No results found";
            }

            IsLoading = false;
            StateHasChanged();
        }

      
        #endregion

        public async Task TaskClearFilters() 
        {
            foreach (var filter in ColumnFilters)
            {
                for (int i = 0; i < filter.SearchTerms.Count; i++)
                {
                    filter.SearchTerms[i] = "";
                }

                filter.BoolValue = BoolValue.Select;
            }
            StateHasChanged();
        }

        internal void SetFilter(string columnHeader, string columnValue)
        {
            var filterIwant = ColumnFilters.Where(c => c.ColumnName == columnHeader).SingleOrDefault();

            if (filterIwant != null)
            {
                filterIwant.SearchTerms = new List<string> { columnValue };
            }

            StateHasChanged();
        }

        protected abstract  Task<PagedResultSet<List<T>>> GetItems(PagedDataRequest pagedDataRequest);

        public  Task HandleLinkAction<T>(string columnName, object dataItem)
        {
            var itemID = dataItem.GetType().GetProperty("Id")?.GetValue(dataItem);

            switch(columnName)                 
            {
                case "SupplierId":
                    NavigationManager.NavigateTo("/suppliers/" + itemID);
                    break;
                case "OrderId":
                    NavigationManager.NavigateTo("/orders/" + itemID);
                    break;
                case "ProductId":
                    NavigationManager.NavigateTo("/products/" + itemID);
                    break;
                case "CustomerId":
                    NavigationManager.NavigateTo("/customers/" + itemID);
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
