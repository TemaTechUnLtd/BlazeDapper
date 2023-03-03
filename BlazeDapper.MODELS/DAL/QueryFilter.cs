namespace BlazeDapper.MODELS.DAL
{
    public class QueryFilter
    {
        public string DisplayName { get; set; }
        public string ColumnName { get; set; }
        public TypeCode ColumnType { get; set; }
        public List<string> SearchTerms { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public FilterType FilterType { get; set; }
        public bool HasLinkAction { get; set; }
        public BoolValue BoolValue { get; set; }
    }
}
