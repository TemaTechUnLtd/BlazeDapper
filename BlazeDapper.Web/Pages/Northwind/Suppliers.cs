using BlazeDapper.COMPONENTS.PagedDataSet;
using BlazeDapper.CORE;
using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;
using Microsoft.AspNetCore.Components;

namespace BlazeDapper.WEB.Pages.Northwind
{

    public partial class Suppliers : PagedDataSetBase<Supplier>
    {
        [Inject]
        protected ITheService BlazeService { get; set; }

        public async override Task<PagedResultSet<List<Supplier>>> GetItems(PagedDataRequest pagedDataRequest)
        {
            return await BlazeService.GetSuppliers(pagedDataRequest);
        }
    }
}
