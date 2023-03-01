namespace BlazeDapper.WEB.Pages.Northwind
{
    using BlazeDapper.COMPONENTS.PagedDataSet;
    using BlazeDapper.CORE;
    using BlazeDapper.MODELS;
    using BlazeDapper.MODELS.DAL;
    using Microsoft.AspNetCore.Components;

    public partial class Customers : PagedDataSetBase<Customer>
    {
        [Inject]
        protected ITheService theService { get; set; }

        public override async Task<PagedResultSet<List<Customer>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return await theService.GetCustomers(pagedDataRequest);
        }
    }
}
