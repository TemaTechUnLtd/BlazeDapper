using BlazeDapper.CORE.Utilities;
using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public abstract class PagedDataSetBase<T> : ComponentBase where T : class
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }      

        [Parameter]
        public string ClientID { get; set; }

        private PagedDataRequest pagedDataRequest { get; set; }

        public PagingData pagingData { get; set; } = new PagingData();

        public PagedResultSet<List<T>> pagedResultSet { get; set; }

        public string Message { get; set; }

        public List<QueryFilter> ColumnFilters { get; set; } = new List<QueryFilter>();
        public List<SurplusDataItem> SurplussData { get; set; } = new List<SurplusDataItem>();

        public bool IsLoading { get; set; }

        #region Data Retrieval

        protected override async Task OnInitializedAsync()
        {
            PagingRequest pagingRequest = new();

            FilterColumns.GetColumnHeadings<T>(pagingRequest, ColumnFilters, SurplussData);

            pagedDataRequest = new PagedDataRequest { FilterSet = ColumnFilters, Paging = pagingRequest };
            IsLoading = true;

            if (!String.IsNullOrEmpty(ClientID))//todo: find a more generic way fo doing this. Should not be hardcoding in identifier coloumn
            {
                var patientFilter = ColumnFilters.SingleOrDefault(cf => cf.ColumnName == "PatientID" || cf.ColumnName == "ClientID");

                if (patientFilter != null)
                {
                    patientFilter.SearchTerms[0] = ClientID;
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

            pagedResultSet = await GetCachedData(pagedDataRequest);
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

            pagedResultSet = await GetCachedData(pagedDataRequest);

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

            pagedResultSet = await GetCachedData(pagedDataRequest);

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

            pagedResultSet = await GetCachedData(pagedDataRequest);

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
        private async Task<PagedResultSet<List<T>>> GetCachedData(PagedDataRequest pagedDataRequest)
        {
           
                pagedResultSet = await GetItems(pagedDataRequest);
             
            return pagedResultSet;
        }

        public async Task TaskClearFilters()
        {
            foreach (var filter in ColumnFilters)
            {
                for (int i = 0; i < filter.SearchTerms.Count; i++)
                {
                    filter.SearchTerms[i] = "";
                }
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

        public virtual async Task<PagedResultSet<List<T>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return new PagedResultSet<List<T>>();
        }

        public virtual Task HandleLinkAction<T>(string columnName, object dataItem)
        {
            //the check below is because appointments still points to bi mart.
            //when all data is in app-dev, we wont need to double check the column name

            var itemID = dataItem.GetType().GetProperty("ClientID")?.GetValue(dataItem);

            if (itemID == null)
            {
                itemID = dataItem.GetType().GetProperty("PatientID")?.GetValue(dataItem);
            }

            NavigationManager.NavigateTo("/patients/" + itemID.ToString());

            return Task.CompletedTask;
        }

   

        private static string GetSequenceIds(PagedResultSet<List<T>> pagedResultSet)
        {
            //get sequenceids or patient ids
            var sequenceIDs = new StringBuilder();

            foreach (var item in pagedResultSet.Data)
            {
                var itemProp = item.GetType().GetProperty("SequenceID");

                if (itemProp == null)
                    itemProp = item.GetType().GetProperty("PatientID");

                var propValue = itemProp.GetValue(item, null);

                if (propValue != null)
                    sequenceIDs.Append(propValue.ToString() + ",");
            }

            return sequenceIDs.ToString();
        }
    }
}
