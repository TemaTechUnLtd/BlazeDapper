namespace BlazeDapper.MODELS.DAL
{
    public class PagedDataRequest
    {
        public PagingRequest Paging { get; set; }
        public List<QueryFilter> FilterSet { get; set; }
    }
}
