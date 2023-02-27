using BlazeDapper.MODELS.DAL;

namespace BlazeDapper.MODELS
{
    public class PagingData
    {
        public PagingData()
        {
        }

        public void SetPagingInfo<T>(PagedResultSet<List<T>> pagedResultSet) where T : class
        {
            TotalRecords = pagedResultSet.TotalRecords;
            CurrentPageNumber = pagedResultSet.CurrentPageNumber;
            PageSize = pagedResultSet.PageSize;
            TotalPages = pagedResultSet.TotalPages;
            HasNextPage = pagedResultSet.HasNextPage;
            HasPreviousPage = pagedResultSet.HasPreviousPage;
            StartRecord = pagedResultSet.StartRecord;
            EndRecord = pagedResultSet.EndRecord;
        }

        public int TotalRecords { get; set; }
        public int CurrentPageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int StartRecord { get; set; }
        public int EndRecord { get; set; }
    }
}
