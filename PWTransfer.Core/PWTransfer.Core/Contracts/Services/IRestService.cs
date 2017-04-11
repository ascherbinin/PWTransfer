using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Services
{
    public interface IRestService
    {
        Task<T> ReadContentAsync<T>(HttpResponseMessage response);
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
