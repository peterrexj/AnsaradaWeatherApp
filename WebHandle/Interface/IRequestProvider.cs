using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebHandler.Interface;
using WebHandler.Models;

namespace WebHandler.Services
{
    public interface IRequestProvider
    {
        HeaderCollection Headers { get; }
        string JsonBody { get; }
        ParameterCollection PostParams { get; }
        ParameterCollection QueryParams { get; }
        Uri Uri { get; }

        IRequestProvider AddHeaders(HeaderCollection headers);
        IResponseProvider Get();
        Task<IResponseProvider> GetAsync();
        //IResponseService Post();
        //Task<IResponseService> PostAsync();
        Task<IResponseProvider> SendRequestAsync(HttpMethod httpMethod);
        //IRequestService SetContent(ParameterCollection parameters);
        //IRequestService SetJsonBody(string json);
        //IRequestService SetQueryParams(ParameterCollection values);
    }
}