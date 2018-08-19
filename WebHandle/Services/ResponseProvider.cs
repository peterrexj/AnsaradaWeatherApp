using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Interface;

namespace WebHandler.Services
{
    public class ResponseProvider : IResponseProvider
    {
        /// <summary>
        /// This is the body of the response
        /// </summary>
        public IBodyProvider ResponseBody { get; set; }

        /// <summary>
        /// The HTTP response code (eg 200 etc)
        /// </summary>
        public HttpStatusCode ResponseCode { get; set; }

        /// <summary>
        /// The underlying System.Net.HttpResponseMessage representation of the response. 
        /// This can be useful to obtain further information on the request if needed.
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public ResponseProvider()
        {

        }

        public ResponseProvider(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
        }
    }
}
