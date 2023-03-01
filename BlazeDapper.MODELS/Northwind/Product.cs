using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Product
    {
        [LinkAction]
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
