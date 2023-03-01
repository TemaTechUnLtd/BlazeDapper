namespace BlazeDapper.MODELS.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Display : Attribute
    {
        private readonly string name;
        private readonly DisplayType displayType;

        public Display(string Name, DisplayType displayType)
        {
            this.name = Name;
            this.displayType = displayType;
        }

        public string GetName()
        {
            return name;
        }

        public DisplayType GetDisplayType()
        {
            return displayType;
        }
    }

    public enum DisplayType
    {
        Table,
        Surplus
    }
}
