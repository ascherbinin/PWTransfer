using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Helpers
{
    public static class HttpClientFactory
    {
		private static string _accessToken = "";

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlConstants.BaseApiURL());

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
			if (!String.IsNullOrEmpty(_accessToken))
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _accessToken);
			}

            return client;
        }


		public static string AccessToken
		{
			get { return _accessToken; }
			set { _accessToken = value;}
		}

    }
}
