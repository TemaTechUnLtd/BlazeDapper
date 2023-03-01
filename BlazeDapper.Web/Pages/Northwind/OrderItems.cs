using BlazeDapper.COMPONENTS.PagedDataSet;
using BlazeDapper.CORE;
using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.WEB.Pages.Northwind
{
 
    public partial class OrderItems : PagedDataSetBase<OrderItem>
    {
        [Inject]
        protected ITheService TheService { get; set; }

        public async override Task<PagedResultSet<List<OrderItem>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return await TheService.GetOrderItems(pagedDataRequest);
        }
    }
}
