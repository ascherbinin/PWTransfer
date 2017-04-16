using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Helpers
{
    public static class JsonContentFactory
    {
        public static StringContent CreateJsonContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return content;
        }
    }
}
