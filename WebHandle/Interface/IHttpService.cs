using System;
using WebHandler.Models;
using WebHandler.Services;

namespace WebHandler.Interface
{
    public interface IHttpService
    {
        HeaderCollection CommonHeaders { get; set; }
        Uri EnvironmentUri { get; }

        IRequestProvider PrepareRequest(string path = "");
        IHttpService SetEnvironment(string environment);
    }
}