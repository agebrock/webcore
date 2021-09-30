using Microsoft.VisualStudio.TestTools.UnitTesting;
using jarowa;
using jarowa.Api.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jarowa.Tests
{
    [TestClass()]
    public class PhoneNumberTests
    {
        [TestMethod()]
        public void RemoveWhitespacesTest()
        {
            Assert.AreEqual("+123", new PhoneNumber().RemoveWhitespaces(" +123 "));
            Assert.AreEqual("+123", new PhoneNumber().RemoveWhitespaces(" +  1 2 3 "));
        }

        [TestMethod()]
        public void GetCountryCodeTest()
        {
            Assert.AreEqual("+12", new PhoneNumber().GetCountryCode("+123"));
        }

        [TestMethod()]
        public void GetLocalNumberTest()
        {
            Assert.AreEqual("3456789", new PhoneNumber().GetLocalNumber("+123456789"));
            Assert.AreEqual("123", new PhoneNumber().GetLocalNumber("0123"));
        }

        [TestMethod()]
        public void CleanLocalNumberTest()
        {
            Assert.AreEqual("0792573115", new PhoneNumber().CleanLocalNumber("(0)79 / 257 - 31 - 15"));
        }

        [TestMethod()]
        public void ValidateTest()
        {
            // functional testing 
            Assert.AreEqual("+41792573115", new PhoneNumber().Validate("(0)79 / 257 - 31 - 15", "+41"));
            // use the provided countrycode if it exists 
            Assert.AreEqual("+49792573115", new PhoneNumber().Validate("+49 (0)79 / 257 - 31 - 15", "+41"));
            Assert.ThrowsException<Exception>(() => new PhoneNumber().Validate("+ 49 414 11", "+41"));

        }
    }
}