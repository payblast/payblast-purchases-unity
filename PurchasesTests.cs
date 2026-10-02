using Xunit;

namespace Payblast;

public class PurchasesTests
{
    [Fact]
    public void PresentPaywallRendersPackageLookupKeys()
    {
        var http = new FakeHttp();
        var purchases = new Purchases("http://127.0.0.1:4000", http);
        purchases.Configure("pk_test", "user-1");
        Assert.Contains("monthly", purchases.GetOfferings());
        var rendered = purchases.PresentPaywall("{}", new[] { "monthly", "annual" });
        Assert.Contains("monthly", rendered);
        Assert.Contains("annual", rendered);
        Assert.Equal("pk_test", http.ApiKey);
    }
}

file class FakeHttp : IHttpTransport
{
    public string ApiKey { get; private set; } = "";

    public string Get(string path, string apiKey)
    {
        ApiKey = apiKey;
        return "{\"packages\":[{\"lookup_key\":\"monthly\"}]}";
    }
}
