using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Supplier
    {
        [Display("Item Id")]
        [OrderColumn(Descending: false)] 
        public int Id { get; set; }

        [Display("Company Name")]
        public string CompanyName { get; set; }

        [Display("Contact Name")]
        public string ContactName { get; set; }

        [Display("Contact Title")]
        public string ContactTitle { get; set; }

        [Display("City")]
        public string City { get; set; }

        [Display("Country")]
        public string Country { get; set; }

        [Display("Phone")]
        public string Phone { get; set; }

        [Display("Fax")]
        public string Fax { get; set; }
    }
}
