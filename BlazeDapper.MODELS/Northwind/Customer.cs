using BlazeDapper.MODELS.Utilities;

namespace BlazeDapper.MODELS
{
    public class Customer
    {        
        [Display("Item Id")]
        [OrderColumn(Descending: false)]
        public int Id { get; set; }

        [Display("First Name")]
        public string FirstName { get; set; }

        [Display("Last Name")]
        public string LastName { get; set; }

        [Display("City")]
        public string City { get; set; }

        [Display("Country")]
        public string Country { get; set; }

        [Display("Phone")]
        public string Phone { get; set; }
    }
}
