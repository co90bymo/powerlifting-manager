public class GameTime
{
    public int Year { get; set; }
    public int Week { get; set; }

    public GameTime()
    {
        Year = 1;
        Week = 1;
    }

    public void ProgressTime()
    {
        Week++;

        if (Week > 52)
        {
            Week = 1;
            Year++;
        }
    }

    public string GetTimeDisplayString()
    {
        return $"Year {Year} - Week {Week}";
    }
}