using BlazeDapper.COMPONENTS.PagedDataSet;
using BlazeDapper.CORE;
using BlazeDapper.MODELS.DAL;
using BlazeDapper.MODELS.DTO;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.WEB.Pages.Northwind
{
 
    public partial class Customers : PagedDataSetBase<Customer>
    {
        [Inject]
        protected ITheService theService { get; set; }

        public async override Task<PagedResultSet<List<Customer>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return await theService.GetCustomers(pagedDataRequest);
        }
    }
}
