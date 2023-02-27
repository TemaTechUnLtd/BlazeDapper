namespace BlazeDapper.MODELS.DAL
{
    public class PagingRequest
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string OrderColumn { get; set; }

        public bool OrderDescending { get; set; }
    }
}
