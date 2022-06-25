using System.Text;
using CopyLiu.Toolkit.Crypt;
using CopyLiu.Toolkit.String;

namespace CopyLiu.Toolkit.Test;

public class Crypt
{
    [Fact]
    public void TestAES()
    {
        Assert.Equal(
            "CnlgZGbQnq4uaSY+MYp1bQ==",
            AESCBC.Base64Encrypt("CopyLiu Test", Encoding.ASCII.GetBytes("1234567890ABCDEF"),
                Encoding.ASCII.GetBytes("ABCDEF1234567890"))
        );

        Assert.Equal(
            "CopyLiu Test",
            AESCBC.Base64Decrypt("CnlgZGbQnq4uaSY+MYp1bQ==", Encoding.ASCII.GetBytes("1234567890ABCDEF"),
                Encoding.ASCII.GetBytes("ABCDEF1234567890"),
                Encoding.UTF8)
        );
    }

    [Fact]
    public void TestDES()
    {
        Assert.Equal(
            "urmtE1LTQCtv6BnL8Slpmg==",
            DESCBC.Base64Encrypt("CopyLiu Test", Encoding.ASCII.GetBytes("123456789012345678901234"),
                "1234567890abcdef".AsByteArray())
        );

        Assert.Equal(
            "CopyLiu Test",
            DESCBC.Base64Decrypt("urmtE1LTQCtv6BnL8Slpmg==", Encoding.ASCII.GetBytes("123456789012345678901234"),
                "1234567890abcdef".AsByteArray(),
                Encoding.UTF8)
        );
    }
}