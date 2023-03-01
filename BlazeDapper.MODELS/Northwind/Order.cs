using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Order
    {
        [LinkAction]
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
