using System.Collections.Generic;
using WebHandler.Interface;

namespace WebHandler.Interface
{
    public interface IBodyProvider
    {
        IHtmlDocument HtmlContent { get; }
        string StringContent { get; }

        IEnumerable<string> FilterByXpathGetAll(string xpathExpression, string attributeToRetrive);
        string FilterByXpathAndGetInnerText(string xpathExpression);
    }
}