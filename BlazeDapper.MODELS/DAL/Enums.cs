namespace BlazeDapper.MODELS.DAL
{
    public enum FilterType
    {
        Contains = 1,
        Excludes = 2,
        Before = 3,
        After = 4,
        Between = 5
    }

    public enum BoolValue
    {
        Select = -1,
        True = 1,
        False = 0,
    }
}
