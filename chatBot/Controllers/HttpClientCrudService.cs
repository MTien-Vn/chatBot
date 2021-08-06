using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class HttpClientCrudService 
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly JsonSerializerOptions _options;

        public HttpClientCrudService()
        {
            _httpClient.BaseAddress = new Uri("https://graph.facebook.com/v2.6/me/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task PostMess(Object obj)
        {
            var objJson = JsonSerializer.Serialize(obj);
            var requestContent = new StringContent(objJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("messages",requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
