using Microsoft.AspNetCore.Components;

namespace BlazeDapper.COMPONENTS.PagedDataSet
{
    public partial class DataItemRow<T> : ComponentBase
       where T : class
    {
        [Parameter]
        public object dataItem { get; set; }

        [CascadingParameter]
        public PagedDataSetBase<T> TopPage { get; set; }

        private bool HideSurplusRow = true;

        private void SetFilter(string columnHeader, string columnValue)
        {
            TopPage.SetFilter(columnHeader, columnValue);
        }

        private async Task LinkAction(string columnName)
        {
            await TopPage.HandleLinkAction<T>(columnName, dataItem);
        }

        private object GetSurplasDataValue(string propertyName)
        {
            return dataItem.GetType().GetProperty(propertyName)?.GetValue(dataItem, null);
        }

        private void ToggleSurplusRow()
        {
            HideSurplusRow = !HideSurplusRow;
            StateHasChanged();
        }

    }
}
