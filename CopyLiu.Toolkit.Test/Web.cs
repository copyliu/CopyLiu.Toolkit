using CopyLiu.Toolkit.Web;

namespace CopyLiu.Toolkit.Test;

public class Web
{
    [Fact]
    public void TestUrlEncode()
    {
        var dict = new Dictionary<string, int>
        {
            { "test", 1 },
            { "a/b", 2 }
        };
        var result = dict.UrlEncode();
        Assert.Equal("test=1&a%2fb=2", result);
    }
}