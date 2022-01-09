namespace Day010;

public static class ScheduleUtility
{
    public static void Schedule(Action action, TimeSpan waitTime)
    {
        Thread.Sleep(waitTime);
        action();
    }
}