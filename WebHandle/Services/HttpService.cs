using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Interface;
using WebHandler.Models;

namespace WebHandler.Services
{
    public class HttpService : IHttpService
    {
        public Uri EnvironmentUri { get; private set; }
        public HeaderCollection CommonHeaders { get; set; }

        public IHttpService SetEnvironment(string environment)
        {
            EnvironmentUri = new Uri(environment);
            return this;
        }

        public HttpService()
        {
            CommonHeaders = new HeaderCollection {
                new HeaderProvider("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36"),
                new HeaderProvider("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"),
                new HeaderProvider("Accept-Encoding", "gzip, deflate"),
                new HeaderProvider("Accept-Language", "en,el;q=0.8")
            };
        }

        public IRequestProvider PrepareRequest(string path = "")
        {
            var request = new RequestProvider(EnvironmentUri, path);
            request.AddHeaders(CommonHeaders);
            return request;
        }
    }
}
