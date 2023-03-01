namespace BlazeDapper.DAL.Utilities
{
    using BlazeDapper.MODELS.DAL;
    using Dapper;

    public static class QueryRunner
    {
        internal static async Task<PagedResultSet<List<T>>> GetEntityCollection<T>(PagedDataRequest request, TheDataContext context)
        {
            var query = QueryGenerator.GetQuery<T>(request);

            Dictionary<string, object> queryParams = QueryGenerator.GetQueryParams(request);

            using (var connection = context.CreateConnection())
            {
                var reader = await connection.QueryMultipleAsync(query, new DynamicParameters(queryParams));

                int totalRecords = reader.Read<int>().FirstOrDefault();
                List<T> dataCollection = reader.Read<T>().ToList();
                var itemCollection = new PagedResultSet<List<T>>(dataCollection, totalRecords, request.Paging.PageNumber, request.Paging.PageSize);
                               
                return itemCollection;
            }
        }       
    }
}
