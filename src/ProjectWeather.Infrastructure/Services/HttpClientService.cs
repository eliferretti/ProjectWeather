using System.Net.Http.Json;

namespace ProjectWeather.Infrastructure.Services
{
    public class HttpClientService
    {
        public IHttpClientFactory _clientFactory { get; set; }

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> Get<T>(string url)
        {
            var client = await _clientFactory.CreateClient().GetAsync(url);
            return await client.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Update<T>(string url, StringContent content)
        {
            var client = await _clientFactory.CreateClient().PutAsync(url, content);
            return await client.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> Delete(string url)
        {
            var client = await _clientFactory.CreateClient().DeleteAsync(url);
            return await client.Content.ReadAsStringAsync();
        }

        public async Task<string> Post(string url, StringContent content)
        {
            var client = await _clientFactory.CreateClient().PostAsync(url, content);
            return await client.Content.ReadAsStringAsync();
        }
    }
}
