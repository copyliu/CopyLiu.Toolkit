using CopyLiu.Toolkit.DateTime;

namespace CopyLiu.Toolkit.Test;

public class DateTime
{
    [Fact]
    public void TestTrim()
    {
        Assert.Equal(new System.DateTime(2000, 1, 1),
            new System.DateTime(2000, 1, 1, 12, 31, 0).Trim(TimeSpan.TicksPerDay));
    }

    [Fact]
    public void TestDatetimeOffsetTrim()
    {
        Assert.Equal(new DateTimeOffset(new System.DateTime(2000, 1, 1), TimeSpan.Zero),
            new DateTimeOffset(2000, 1, 1, 12, 31, 0, TimeSpan.Zero).Trim(TimeSpan.TicksPerDay));
    }
}