using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHandler.Interface
{
    public interface IHtmlDocument
    {
        IEnumerable<HtmlNode> Select(string xpath);
    }
}
