using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaRental.Web.Extensions.Tests
{
    [TestClass()]
    public class HashExtensionsTests
    {
        [DataTestMethod()]
        [DataRow("123456789", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225")]
        [DataRow("123asdb123askd12", "3083ac91806215006cc84e452d3052de26c07529cbe9a01f91a763c08eafeb82")]
        [DataRow("$asd@ASD!asd^&8", "bae3cdea1993d3d9c86eaa7e7bd88db091eb2617beda5cb5cece2419e253aabe")]
        [DataRow("0123&asda(1231", "74c905da9ccb58a680b14b0fafa9186576af25e5771d0d88d3c974dfaf83255b")]
        [DataRow("<>1231./,.;'/.,", "289f085768cc41a530e3df67a5dd2f89f525042899ba39442f177cd03d7581f4")]
        public void ConvertToSha256HashTest(string input, string expected)
        {
            var actual = input.ConvertToSha256Hash();
            Assert.AreEqual(expected, actual);
        }
    }
}