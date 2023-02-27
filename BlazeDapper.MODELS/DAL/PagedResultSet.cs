namespace BlazeDapper.MODELS.DAL
{
    public class PagedResultSet<T> where T : class
    {
        public int StartRecord { get; set; }
        public int EndRecord { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public T Data { get; set; }

        public PagedResultSet(T data, int totalRecords, int currentPageNumber, int pageSize)
        {
            Data = data;
            TotalRecords = totalRecords;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;

            TotalPages = Convert.ToInt32(Math.Ceiling(TotalRecords / (double)pageSize));
            HasNextPage = CurrentPageNumber < TotalPages;
            HasPreviousPage = CurrentPageNumber > 1;

            StartRecord = (CurrentPageNumber * PageSize) - (PageSize - 1);
            EndRecord = CurrentPageNumber * PageSize;
        }

        public PagedResultSet()
        {
        }
    }
}
