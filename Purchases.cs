namespace Payblast;

public interface IHttpTransport
{
    string Get(string path, string apiKey);
}

public sealed class Purchases
{
    private readonly string _baseUrl;
    private readonly IHttpTransport _http;
    private string _apiKey = "";
    private string _appUserId = "";

    public Purchases(string baseUrl, IHttpTransport http)
    {
        _baseUrl = baseUrl;
        _http = http;
    }

    public void Configure(string apiKey, string appUserId)
    {
        _apiKey = apiKey;
        _appUserId = appUserId;
    }

    public void LogIn(string appUserId) => _appUserId = appUserId;
    public void LogOut() => _appUserId = "$payblastAnon";
    public string GetOfferings() => _http.Get($"{_baseUrl}/v1/offerings", _apiKey);
    public string Purchase(string productId) => GetCustomerInfo();
    public string Restore() => GetCustomerInfo();
    public string GetCustomerInfo() => _http.Get($"{_baseUrl}/v1/customers/{_appUserId}", _apiKey);

    public string PresentPaywall(string document, IEnumerable<string> packageKeys)
        => document + " " + string.Join(" ", packageKeys);
}
