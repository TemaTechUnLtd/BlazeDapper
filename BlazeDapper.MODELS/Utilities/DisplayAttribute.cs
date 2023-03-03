namespace BlazeDapper.MODELS.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Display : Attribute
    {
        private readonly string name;

        public Display(string Name)
        {
            this.name = Name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
