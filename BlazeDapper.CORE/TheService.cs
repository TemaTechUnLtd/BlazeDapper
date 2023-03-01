using BlazeDapper.DAL;
using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;

namespace BlazeDapper.CORE
{
    public class TheService : ITheService
    {
        private readonly ITheRepository _blazeRepository;

        public TheService(ITheRepository blazeRepository)
        {
            _blazeRepository = blazeRepository;
        }

        public async Task<PagedResultSet<List<Customer>>> GetCustomers(PagedDataRequest payload)
        {
           return await _blazeRepository.GetCustomers(payload);
        }

        public async Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest payload)
        {
            return await _blazeRepository.GetOrderItems(payload);
        }

        public async Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest payload)
        {
            return await _blazeRepository.GetOrders(payload);
        }

        public async Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest payload)
        {
            return await _blazeRepository.GetProducts(payload);
        }

        public async Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest payload)
        {
            return await _blazeRepository.GetSuppliers(payload);
        }
    }
}