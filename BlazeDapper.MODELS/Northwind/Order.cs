using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Order
    {
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("Order Date", DisplayType.Table)]
        public DateTime OrderDate { get; set; }

        [Display("Order Number", DisplayType.Table)]
        public string OrderNumber { get; set; }

        [LinkAction]
        [Display("Customer Id", DisplayType.Table)]
        public int CustomerId { get; set; }

        [Display("Total Amount", DisplayType.Table)]
        public decimal TotalAmount { get; set; }
    }
}
