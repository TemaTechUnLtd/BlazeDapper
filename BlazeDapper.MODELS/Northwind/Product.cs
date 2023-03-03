using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Product
    {
        [Display("Item Id")]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("Product Name")]
        public string ProductName { get; set; }

        [LinkAction]
        [Display("Supplier Id")]
        public int SupplierId { get; set; }

        [Display("Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display("Package")]
        public string Package { get; set; }

        [Display("Discontinued")]
        public bool IsDiscontinued { get; set; }
    }
}
