namespace BlazeDapper.DAL
{
    using BlazeDapper.DAL.Utilities;
    using BlazeDapper.MODELS;
    using BlazeDapper.MODELS.DAL;

    public class TheRepository : ITheRepository
    {
        private readonly TheDataContext _context;

        public TheRepository(TheDataContext context)
        {
            _context = context;
        }

        public async Task<PagedResultSet<List<Customer>>> GetCustomers(PagedDataRequest request)
        {
            return await QueryRunner.GetEntityCollection<Customer>(request, _context);
        }

        public async Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest request)
        {
            return await QueryRunner.GetEntityCollection<OrderItem>(request, _context);
        }

        public async Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest request)
        {
            return await QueryRunner.GetEntityCollection<Order>(request, _context);
        }

        public async Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest request)
        {
            return await QueryRunner.GetEntityCollection<Product>(request, _context);
        }

        public async Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest request)
        {
            return await QueryRunner.GetEntityCollection<Supplier>(request, _context);
        }
    }
}
