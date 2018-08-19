using CoreHandler.Extensions;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHandler.Interface;

namespace WebHandler.Services
{
    public class HtmlDoc : IHtmlDocument
    {
        private HtmlDocument doc;

        public HtmlDoc(string htmlContent)
        {
            doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
        }

        public IEnumerable<HtmlNode> Select(string xpath)
        {
            return doc.DocumentNode.SelectNodes(xpath).EmptyIfNull();
        }
    }
}
