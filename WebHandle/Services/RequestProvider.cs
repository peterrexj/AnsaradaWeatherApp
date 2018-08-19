using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Interface;
using WebHandler.Models;

namespace WebHandler.Services
{
    public class RequestProvider : IRequestProvider
    {
        public Uri Uri { get; private set; }
        public string JsonBody { get; private set; }
        public ParameterCollection QueryParams { get; private set; }
        public ParameterCollection PostParams { get; private set; }
        public HeaderCollection Headers { get; private set; }

        public RequestProvider(Uri baseUri, string path)
        {
            Init();
            InitUri(baseUri, path);
        }

        private void Init()
        {
            Headers = new HeaderCollection();
            QueryParams = new ParameterCollection();
            PostParams = new ParameterCollection();
        }
        private void InitUri(Uri baseUri, string path)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri needs to be specified");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                Uri = baseUri;
                return;
            }

            if (baseUri.AbsoluteUri.Contains('?'))
            {
                throw new ArgumentException("Cannot append a path when the base URI contains query parameters.");
            }

            Uri = new Uri(baseUri, path);
        }

        public virtual IRequestProvider AddHeaders(HeaderCollection headers)
        {
            Headers.AddRange(headers);
            return this;
        }

        public IResponseProvider Get()
        {
            return GetAsync().Result;
        }

        public virtual async Task<IResponseProvider> GetAsync()
        {
            return await SendRequestAsync(HttpMethod.Get);
        }

        public virtual async Task<IResponseProvider> PostAsync()
        {
            return await SendRequestAsync(HttpMethod.Post);
        }

        public async Task<IResponseProvider> SendRequestAsync(HttpMethod httpMethod)
        {
            var httpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = new CookieContainer(),
                UseCookies = true
            };

            var client = new HttpClient(httpClientHandler);
            HttpResponseMessage httpResponseMessage = null;

            if (httpMethod == HttpMethod.Post)
            {
                if (string.IsNullOrEmpty(JsonBody))
                {
                    var content = new FormUrlEncodedContent(PostParams.Select(kvp => new KeyValuePair<string, string>(kvp.Key, (string)kvp.Value)));
                    httpResponseMessage = await client.PostAsync(Uri.AbsoluteUri, content);
                }
                else
                {
                    var request = new HttpRequestMessage(httpMethod, Uri);
                    request.Content = new StringContent(JsonBody, Encoding.UTF8, "application/json");
                    httpResponseMessage = await client.SendAsync(request);
                }
            }
            else if (httpMethod == HttpMethod.Get)
            {
                httpResponseMessage = await client.GetAsync(Uri);
            }


            var schemeHostAndPortPart = Uri.GetLeftPart(UriPartial.Authority);
            var uri = new Uri(schemeHostAndPortPart);

            var result = await httpResponseMessage.Content.ReadAsStringAsync();

            return new ResponseProvider()
            {
                ResponseCode = httpResponseMessage.StatusCode,
                ResponseBody = new BodyProvider(result),
                HttpResponseMessage = httpResponseMessage,
            };
        }
    }
}
