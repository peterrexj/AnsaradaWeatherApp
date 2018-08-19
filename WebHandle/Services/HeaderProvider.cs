using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Interface;

namespace WebHandler.Services
{
    public class HeaderProvider : IHeaderProvider
    {
        public HeaderProvider(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
