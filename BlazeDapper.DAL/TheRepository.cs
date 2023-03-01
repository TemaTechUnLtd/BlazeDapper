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
                var query = QueryGenerator.GetQuery<Customer>(request);

                Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

                using (var connection = _context.CreateConnection())
                {
                    var itemCollection = await QueryRunner.GetPagedDataAsync<Customer>(query, connection, queryParams, request.Paging);
                    return itemCollection;
                }
        }

        public async Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<OrderItem>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection())
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<OrderItem>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Order>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection())
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Order>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Product>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection())
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Product>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Supplier>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection())
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Supplier>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }
    }
}
