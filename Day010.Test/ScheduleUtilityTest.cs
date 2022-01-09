using System;
using System.Diagnostics;
using Xunit;

namespace Day010.Test;

public class ScheduleUtilityTest
{
    [Fact]
    public void Schedule_WithSetTimeSpan_ShouldExecuteAfterAtLeastTimeSpan()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        ScheduleUtility.Schedule(Console.WriteLine, new TimeSpan(0, 0, 1));
        stopwatch.Stop();

        var actual = stopwatch.Elapsed;

        Assert.True(actual >= new TimeSpan(0, 0, 1));
    }
}