using BlazeDapper.MODELS.DAL;
using Dapper;
using System.Data;

namespace BlazeDapper.DAL.Utilities
{
    public static class QueryRunner
    {

        


        internal static async Task<PagedResultSet<List<T>>> GetPagedDataAsync<T>(string query, IDbConnection connection, Dictionary<string, object> queryParams, PagingRequest paging)
        {
            var reader = await connection.QueryMultipleAsync(query, new DynamicParameters(queryParams));

            int totalRecords = reader.Read<int>().FirstOrDefault();
            List<T> dataCollection = reader.Read<T>().ToList();

            var resultSet = new PagedResultSet<List<T>>(dataCollection, totalRecords, paging.PageNumber, paging.PageSize);

            return resultSet;
        }
    }
}
