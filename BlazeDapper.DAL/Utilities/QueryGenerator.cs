using BlazeDapper.MODELS;
using BlazeDapper.MODELS.DAL;
using System.Text;

namespace BlazeDapper.DAL.Utilities
{
    public static class QueryGenerator
    {
        public static string GetQuery<T>(PagedDataRequest request)
        {
            string columns = GetColumns<T>();
            var sourceTable = GetSourceTable<T>();

            var transactLevel = @"SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ";
            var selectionSubQuery = @"SELECT " + columns + " FROM " + sourceTable + " ";

            var filterSubQuery = GetFilterQuery(request);
            var orderSubQuery = GetOrderQuery(request.Paging);
            var pagingSubQuery = GetPagingQuery(request.Paging);

            var countSubQuery = @"SELECT COUNT(*) FROM " + sourceTable + " " + filterSubQuery;

            StringBuilder sb = new(transactLevel);
            sb.Append(countSubQuery);
            sb.Append(selectionSubQuery);
            sb.Append(filterSubQuery);
            sb.Append(orderSubQuery);
            sb.Append(pagingSubQuery);

            return sb.ToString();
        }

        private static string GetColumns<T>()
        {
            StringBuilder sb = new StringBuilder();

            var proprties = typeof(T).GetProperties();

            for (int i = 0; i < proprties.Length; i++)
            {
                sb.Append(" " + proprties[i].Name + " ");

                if (i != proprties.Length - 1)
                {
                    sb.Append(", ");
                }
                else
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        public static Dictionary<string, object> GetQueryParams(PagedDataRequest request)
        {
            var filters = request.FilterSet;
            var queryParams = new Dictionary<string, object>();

            foreach (var filter in filters)
            {
                if (filter.ColumnType == TypeCode.DateTime && (filter.FromDate != null || filter.ToDate != null))
                {
                    switch (filter.FilterType)
                    {
                        case FilterType.Between:
                            queryParams.Add("@" + filter.ColumnName + "1", filter.FromDate);
                            queryParams.Add("@" + filter.ColumnName + "2", filter.ToDate);
                            break;
                        case FilterType.After:
                            queryParams.Add("@" + filter.ColumnName, filter.FromDate);
                            break;
                        case FilterType.Before:
                            queryParams.Add("@" + filter.ColumnName, filter.ToDate);
                            break;
                    }
                }
                else if (filter.SearchTerms == null || !filter.SearchTerms.Where(s => !string.IsNullOrWhiteSpace(s)).Any())
                {
                    continue;
                }
                else if (filter.ColumnType != TypeCode.DateTime)
                {
                    int searchTermINdex = 0;

                    foreach (var searchTerm in filter.SearchTerms)
                    {
                        queryParams.Add("@" + filter.ColumnName + (searchTermINdex > 0 ? searchTermINdex.ToString() : ""), searchTerm);

                        searchTermINdex++;
                    }
                }
            }
            return queryParams;
        }

        private static string GetFilterQuery(PagedDataRequest request)
        {
            var filters = request.FilterSet;

            if (!filters.Any())
                return "";

            StringBuilder sb = new(" WHERE ");
            var stringLength = sb.Length;

            foreach (var filter in filters)
            {
                var columnName = filter.ColumnName;

                if (filter.SearchTerms.Any())
                {
                    var searchTerms = filter.SearchTerms.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                    if (searchTerms.Any())
                    {
                        if (sb.Length != stringLength)
                            sb.Append(" AND ");

                        int searchTermIndex = 0;

                        sb.Append(" ( ");

                        foreach (var searchTerm in searchTerms)
                        {
                            if (searchTermIndex > 0)
                            {
                                sb.Append(" OR ");
                            }

                            switch (filter.ColumnType)
                            {
                                case TypeCode.String:
                                    sb.Append(columnName + " like '%' + @" + columnName + (searchTermIndex > 0 ? searchTermIndex.ToString() : "") + " + '%' ");
                                    break;

                                case TypeCode.Boolean:
                                    sb.Append(columnName + " = @" + columnName + " ");
                                    break;

                                case TypeCode.Int32:
                                    sb.Append(columnName + " = @" + columnName + " ");
                                    break;
                            }
                            searchTermIndex++;
                        }

                        sb.Append(" ) ");
                    }
                }

                if (filter.ColumnType == TypeCode.DateTime && (filter.FromDate != null || filter.ToDate != null))
                {
                    if (sb.Length != stringLength)
                        sb.Append(" AND ");

                    sb.Append(GetDateFilterQuery(filter));
                }
            }

            if (sb.Length == stringLength)
                return "";
            else
                return sb.ToString();
        }

        private static string GetDateFilterQuery(QueryFilter queryFilter)
        {
            if (queryFilter.ColumnType != TypeCode.DateTime)
                return "";

            var queryString = "";

            switch (queryFilter.FilterType)
            {
                case FilterType.After:
                    queryString = queryFilter.ColumnName + " > @" + queryFilter.ColumnName + " ";
                    break;
                case FilterType.Before:
                    queryString = queryFilter.ColumnName + " < @" + queryFilter.ColumnName + " ";
                    break;
                case FilterType.Between:
                    queryString = queryFilter.ColumnName + " BETWEEN @" + queryFilter.ColumnName + "1 AND @" + queryFilter.ColumnName + "2 ";
                    break;
            }
            return queryString;
        }

        private static string GetOrderQuery(PagingRequest request)
        {
            if (string.IsNullOrEmpty(request.OrderColumn))
                return "";

            StringBuilder sb = new StringBuilder(" ORDER BY " + request.OrderColumn + " ");

            if (request.OrderDescending)
                sb.Append(" DESC ");

            return sb.ToString();
        }

        private static string GetPagingQuery(PagingRequest paging)
        {
            return string.Format("OFFSET ({0} - 1)*{1} ROWS FETCH NEXT {1} ROWS ONLY", paging.PageNumber, paging.PageSize);
        }

        private static string GetSourceTable<T>()
        {
            var tableName = string.Empty;
            var moduleType = typeof(T);

            switch (moduleType.Name)
            {
                case nameof(Customer):
                    tableName = SQLConstants.CustomerTable;
                    break;
                case nameof(Order):
                    tableName = SQLConstants.OrderTable;
                    break;
                case nameof(OrderItem):
                    tableName = SQLConstants.OrderItemTable;
                    break;
                case nameof(Product):
                    tableName = SQLConstants.ProductTable;
                    break;
                case nameof(Supplier):
                    tableName = SQLConstants.SupplierTable;
                    break;
              
                default:
                    throw new ArgumentNullException(nameof(moduleType));
            }

            return tableName;
        }
    }
}
