using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebHandler.Interface;
using Newtonsoft.Json;

namespace WebHandler.Services
{
    public class BodyProvider : IBodyProvider
    {
        private IHtmlDocument _htmlContent;
        private string _stringContent;

        public string StringContent
        {
            get
            {
                return _stringContent;
            }

            private set
            {
                if (_htmlContent != null)
                    _htmlContent = null;

                _stringContent = value;
            }
        }

        public IHtmlDocument HtmlContent
        {
            get
            {
                if (_htmlContent == null)
                    _htmlContent = new HtmlDoc(StringContent);

                return _htmlContent;
            }
        }

        public IEnumerable<string> FilterByXpathGetAll(string xpathExpression, string attributeToRetrive) => HtmlContent.Select(xpathExpression).Select(s => s.GetAttributeValue(attributeToRetrive, string.Empty));
        public string FilterByXpathAndGetInnerText(string xpathExpression) => HtmlContent.Select(xpathExpression).FirstOrDefault().InnerText;

        public BodyProvider(string content)
        {
            StringContent = content;
        }
    }
}
