using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Utility;
using Newtonsoft.Json;

namespace PWTransfer.Core.Services
{
    class BaseRestService : IRestService
    {
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var address = string.Format("{0}{1}", UrlConstants.BaseApiURL, url);
                var response = await client.GetAsync(address);
                return response;
            }
          
        }

        public Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            var message = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(message);
            return content;
        }
    }
}
