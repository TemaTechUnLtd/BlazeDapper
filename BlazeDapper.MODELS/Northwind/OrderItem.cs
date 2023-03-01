using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class OrderItem
    {
        [LinkAction]
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }
     public int OrderId { get; set; }
     public int ProductId { get; set; }
     public decimal UnitPrice { get; set; }
     public int Quantity { get; set; }
    }
}
