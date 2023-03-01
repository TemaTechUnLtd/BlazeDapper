using BlazeDapper.DAL.Utilities;
using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;
using Microsoft.Extensions.Configuration;

namespace BlazeDapper.DAL
{
    public class TheRepository : ITheRepository
    {
        private readonly TheDataContext _context;
        private readonly IConfiguration _configuration;

        public TheRepository(TheDataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<PagedResultSet<List<Customer>>> GetCustomers(PagedDataRequest request)
        {
            //remove duplication
            try
            {
 var query = QueryGenerator.GetQuery<Customer>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection(_configuration.GetConnectionString("BlazeConnection")))
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Customer>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<PagedResultSet<List<OrderItem>>> GetOrderItems(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<OrderItem>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection(_configuration.GetConnectionString("BlazeConnection")))
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<OrderItem>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Order>>> GetOrders(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Order>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection(_configuration.GetConnectionString("BlazeConnection")))
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Order>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Product>>> GetProducts(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Product>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection(_configuration.GetConnectionString("BlazeConnection")))
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Product>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }

        public async Task<PagedResultSet<List<Supplier>>> GetSuppliers(PagedDataRequest request)
        {
            var query = QueryGenerator.GetQuery<Supplier>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = _context.CreateConnection(_configuration.GetConnectionString("BlazeConnection")))
            {
                var itemCollection = await QueryRunner.GetPagedDataAsync<Supplier>(query, connection, queryParams, request.Paging);
                return itemCollection;
            }
        }
    }
}
