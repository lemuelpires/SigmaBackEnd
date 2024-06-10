using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class CorreiosService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public CorreiosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = "6cqgqsYiMISl2p3bCfT2qTFQSAhtrGAUekjFiNmc"; // Substitua pela sua chave de acesso
    }

    public async Task<JObject> GetAddressByZipCode(string zipCode)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.correios.com.br/v1/cep/{zipCode}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JObject.Parse(content);
    }
}
