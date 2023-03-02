using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Product
    {
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("Product Name", DisplayType.Table)]
        public string ProductName { get; set; }

        [LinkAction]
        [Display("Supplier Id", DisplayType.Table)]
        public int SupplierId { get; set; }

        [Display("Unit Price", DisplayType.Table)]
        public decimal UnitPrice { get; set; }

        [Display("Package", DisplayType.Table)]
        public string Package { get; set; }

        [Display("Discontinued", DisplayType.Table)]
        public bool IsDiscontinued { get; set; }
    }
}
