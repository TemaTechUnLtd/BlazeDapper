using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Supplier
    {
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)] 
        public int Id { get; set; }

        [Display("Company Name", DisplayType.Table)]
        public string CompanyName { get; set; }

        [Display("Contact Name", DisplayType.Table)]
        public string ContactName { get; set; }

        [Display("Contact Title", DisplayType.Table)]
        public string ContactTitle { get; set; }

        [Display("City", DisplayType.Table)]
        public string City { get; set; }

        [Display("Country", DisplayType.Table)]
        public string Country { get; set; }

        [Display("Phone", DisplayType.Table)]
        public string Phone { get; set; }

        [Display("Fax", DisplayType.Table)]
        public string Fax { get; set; }
    }
}
