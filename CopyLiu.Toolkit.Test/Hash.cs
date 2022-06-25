using CopyLiu.Toolkit.Hash;
using CopyLiu.Toolkit.String;

namespace CopyLiu.Toolkit.Test;

public class Hash
{
    [Fact]
    public void TestHashs()
    {
        Assert.Equal("174727cb08d5433b7dfcb73ac9d26f92", HashHelper.MD5("CopyLiu").ToHexString().ToLower());
        Assert.Equal("6a0258fc349f8ae19a1ee9b39793e4ebd9bc9a30", HashHelper.SHA1("CopyLiu").ToHexString().ToLower());
        Assert.Equal("e3f97018ec22fda35ea6b7f85595a513f493b0571e27f31f43d321a3019f9493",
            HashHelper.SHA256("CopyLiu").ToHexString().ToLower());
        Assert.Equal("089b4943ea034acfa445d050c7913e55", HashHelper.MD5("中文测试").ToHexString().ToLower());
        Assert.Equal("cf8a8e8f68b4e267920dba0a5f3037180cc1afd9", HashHelper.SHA1("中文测试").ToHexString().ToLower());
        Assert.Equal("e350545d18735c5dd2dec50dcb971f3eb4cdda24b95a79bdb6b553f6a01ceb87",
            HashHelper.SHA256("中文测试").ToHexString().ToLower());
    }
}