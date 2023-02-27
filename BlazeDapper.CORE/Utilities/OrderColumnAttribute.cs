namespace BlazeDapper.CORE.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OrderColumn : Attribute
    {
        public bool Descending { get; set; }

        public OrderColumn(bool Descending)
        {
            this.Descending = Descending;
        }

        public bool GetOrder()
        {
            return Descending;
        }
    }
}
