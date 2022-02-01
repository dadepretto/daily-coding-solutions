namespace Day021;

public static class DateTimeUtility
{
    public static DateTime Max(params DateTime[] dateTimes)
    {
        return dateTimes.Max();
    }

    public static DateTime Min(params DateTime[] dateTimes)
    {
        return dateTimes.Min();
    }
}