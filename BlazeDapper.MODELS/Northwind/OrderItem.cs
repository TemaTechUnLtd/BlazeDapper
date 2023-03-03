using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class OrderItem
    {
        [Display("Item Id")]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [LinkAction]
        [Display("Order Id")]
        public int OrderId { get; set; }

        [LinkAction]
        [Display("Product Id")]
        public int ProductId { get; set; }

        [Display("Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display("Quantity")]
        public int Quantity { get; set; }
    }
}
