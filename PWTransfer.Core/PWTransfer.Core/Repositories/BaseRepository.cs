using Newtonsoft.Json;
using PWTransfer.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Repositories
{
    public class BaseRepository
    {
        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
            where T : new()
        {
            HttpClient httpClient = CreateHttpClient();
            T result;

            try
            {
                var response = await httpClient.GetStringAsync(url);
                result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
            }
            catch
            {
                result = new T();
            }

            return result;
        }

        protected async Task<T> PostAsync<T>(string url, object item )
            where T : new()
        {
            T result;
            using (var client = HttpClientFactory.GetClient())
            {
                var response = await client.PostAsync(url, JsonContentFactory.CreateJsonContent(item));
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                }
                string content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(content);
            }
            return result;
        }
    }
}
