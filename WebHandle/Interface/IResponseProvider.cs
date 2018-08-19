using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Services;

namespace WebHandler.Interface
{
    public interface IResponseProvider
    {
        HttpResponseMessage HttpResponseMessage { get; set; }
        IBodyProvider ResponseBody { get; set; }
        HttpStatusCode ResponseCode { get; set; }
    }
}
