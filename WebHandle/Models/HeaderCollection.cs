using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Services;

namespace WebHandler.Models
{
    public class HeaderCollection : List<HeaderProvider>
    {
        public HeaderCollection()
        {

        }

        public HeaderCollection(IEnumerable<HeaderProvider> headers)
            : base(headers)
        {

        }
    }
}
