using BlazeDapper.MODELS.DAL;

namespace BlazeDapper.MODELS.Utilities
{
    public static class FilterColumns
    {
        public static void GetColumnHeadings<T>(PagingRequest pagingRequest, List<QueryFilter> columnHeaders)
        {
            var propertiesWithAttribute = typeof(T).GetProperties()
                // use projection to get properties with their attributes - 
                .Select(pi => new
                {
                    PropertyInfo = pi,
                    DisplayAttribute = pi.GetCustomAttributes(typeof(Display), true).FirstOrDefault() as Display,
                    LinkActionAttribute = pi.GetCustomAttributes(typeof(LinkAction), true).FirstOrDefault() as LinkAction,
                    OrderColumnAttribute = pi.GetCustomAttributes(typeof(OrderColumn), true).FirstOrDefault() as OrderColumn
                }
                    )
                // filter only properties with attributes
                .Where(x => x.DisplayAttribute != null && x.DisplayAttribute.GetType().Name == "Display")
               .ToList();
           

            foreach (var item in propertiesWithAttribute)
            {
                var queryFilter = new QueryFilter()
                {
                    ColumnName = item.PropertyInfo.Name,
                    ColumnType = Type.GetTypeCode(NullPropertyCheck(item.PropertyInfo.PropertyType)),
                    SearchTerms = new List<string> { "" },
                    DisplayName = item.DisplayAttribute != null ? item.DisplayAttribute.GetName() : item.PropertyInfo.Name,
                    HasLinkAction = item.LinkActionAttribute != null,
                    BoolValue = BoolValue.Select
                };

                columnHeaders.Add(queryFilter);

                if (item.OrderColumnAttribute != null)
                {
                    pagingRequest.OrderColumn = item.PropertyInfo.Name;
                    pagingRequest.OrderDescending = item.OrderColumnAttribute.GetOrder();
                }
            }
        }

        private static Type? NullPropertyCheck(Type propertyType)
        {
            var underlyingType = Nullable.GetUnderlyingType(propertyType);

            if (underlyingType != null)
                return underlyingType;

            return propertyType;
        }
    }
}
