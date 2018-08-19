using System;
using System.Collections.Generic;
using System.Text;

namespace WebHandler.Interface
{
    public interface IHeaderProvider
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}
