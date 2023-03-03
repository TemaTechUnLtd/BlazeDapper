using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Order
    {
        [Display("Item Id")]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("Order Date")]
        public DateTime OrderDate { get; set; }

        [Display("Order Number")]
        public string OrderNumber { get; set; }

        [LinkAction]
        [Display("Customer Id")]
        public int CustomerId { get; set; }

        [Display("Total Amount")]
        public decimal TotalAmount { get; set; }
    }
}
