using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;

namespace BlazeDapper.CORE
{
    public interface ITheService
    {
        Task<PagedResultSet<List<Customer>>> GetCustomers(PagedDataRequest payload);
        Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest payload);
        Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest payload);
        Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest payload);
        Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest payload);
    }
}
