using BlazeDapper.COMPONENTS.PagedDataSet;
using BlazeDapper.CORE;
using BlazeDapper.MODELS.DAL;
using BlazeDapper.MODELS.DTO;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.WEB.Pages.Northwind
{
 
    public partial class Orders : PagedDataSetBase<Order>
    {
        [Inject]
        protected ITheService BlazeService { get; set; }

        public async override Task<PagedResultSet<List<Order>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return await BlazeService.GetOrders(pagedDataRequest);
        }
    }
}
