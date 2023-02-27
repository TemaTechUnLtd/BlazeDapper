using BlazeDapper.MODELS.DAL;
using BlazeDapper.MODELS.DTO;

namespace BlazeDapper.DAL
{
    public interface ITheRepository
    {
        Task<PagedResultSet<List<Customer>>> GetCustomers(PagedDataRequest request);
        Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest request);
        Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest request);
        Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest request);
        Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest request);
    }
}
