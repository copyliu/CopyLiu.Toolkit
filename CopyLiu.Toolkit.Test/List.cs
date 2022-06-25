using CopyLiu.Toolkit.Linq;

namespace CopyLiu.Toolkit.Test;

public class List
{
    [Fact]
    public void TestChunk()
    {
        var list = Enumerable.Range(0, 100).ToList();
        Assert.Throws<ArgumentException>(() =>
            // ReSharper disable once InvokeAsExtensionMethod
            Extensions.Chunk(list, -1).ToList()
        );

        // ReSharper disable once InvokeAsExtensionMethod
        var chunks = Extensions.Chunk(list, 5).ToList();
        Assert.Equal(20, chunks.Count);
        Assert.Equal(new List<int> { 0, 1, 2, 3, 4 }, chunks[0]);
        Assert.Equal(new List<int> { 50, 51, 52, 53, 54 }, chunks[10]);
    }
}