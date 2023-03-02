using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Customer
    {        
        [Display("Item Id", DisplayType.Table)]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("First Name", DisplayType.Table)]
        public string FirstName { get; set; }

        [Display("Last Name", DisplayType.Table)]
        public string LastName { get; set; }

        [Display("City", DisplayType.Table)]
        public string City { get; set; }

        [Display("Country", DisplayType.Table)]
        public string Country { get; set; }

        [Display("Phone", DisplayType.Table)]
        public string Phone { get; set; }
    }
}
