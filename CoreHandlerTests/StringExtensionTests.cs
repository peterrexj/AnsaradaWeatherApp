using CoreHandler.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreHandlerTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void String_Convert_ToDecimal()
        {
            Assert.IsTrue(StringEx.AsDouble("45.34") == 45.34);
        }
    }
}
