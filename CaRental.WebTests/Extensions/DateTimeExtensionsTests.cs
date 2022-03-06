using CaRental.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaRental.Web.Extensions.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void IsBetweenTest()
        {
            var now = DateTime.Now;
            var tests = new[] {
                (now, now.AddMinutes(-5), now.AddMinutes(5), true),
                (now, now.AddMinutes(5), now.AddMinutes(-5), true),
                (now, now.AddMinutes(-20), now.AddMinutes(-10), false),
                (now, now.AddMinutes(10), now.AddMinutes(20), false),
                (now, now, now.AddMinutes(5), true),
                (now, now.AddMinutes(5), now, true),
                (now, now.AddMinutes(-5), now, true),
                (now, now, now.AddMinutes(-5), true)
            };

            foreach (var test in tests)
            {
                var (input, min, max, expected) = test;
                IsBetweenSubtest(input, min, max, expected);
            }
        }

        private void IsBetweenSubtest(DateTime input, DateTime min, DateTime max, bool expected)
        {
            var actual = input.IsBetween(min, max);
            Assert.AreEqual(expected, actual);
        }
    }
}
