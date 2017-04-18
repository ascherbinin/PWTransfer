using Newtonsoft.Json;
using PWTransfer.Core.Exceptions;
using PWTransfer.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Services
{
    public class BaseDataService
    {
        protected async Task<T> GetAsync<T>(string url)
         where T : new()
        {
            HttpClient httpClient = HttpClientFactory.GetClient();
            T result;

            try
            {
                var response = await httpClient.GetStringAsync(url);
                result = JsonConvert.DeserializeObject<T>(response);
            }
            catch
            {
                result = new T();
            }

            return result;
        }

        protected async Task<T> PostAsync<T>(string url, object item)
            where T : new()
        {
            T result;
            using (var client = HttpClientFactory.GetClient())
            {
                var response = await client.PostAsync(url, JsonContentFactory.CreateJsonContent(item));
                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }

                result = JsonConvert.DeserializeObject<T>(content);
            }
            return result;
        }
    }
}
