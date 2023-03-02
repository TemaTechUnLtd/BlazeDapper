using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class OrderItem
    {
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [LinkAction]
        [Display("Order Id", DisplayType.Table)]
        public int OrderId { get; set; }

        [LinkAction]
        [Display("Product Id", DisplayType.Table)]
        public int ProductId { get; set; }

        [Display("Unit Price", DisplayType.Table)]
        public decimal UnitPrice { get; set; }

        [Display("Quantity", DisplayType.Table)]
        public int Quantity { get; set; }
    }
}
