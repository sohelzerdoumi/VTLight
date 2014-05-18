using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VTLight;

namespace UnitTestVTLight
{
    [TestClass]
    public class TestServiceVirusTotal
    {
        [TestMethod]
        public void TestReport()
        {
            VTReport report = ServiceVirusTotal.GetReport("52d3df0ed60c46f336c131bf2ca454f73bafdc4b04dfa2aea80746f5ba9e6d1c");
            Assert.AreNotEqual(0, report.Total);
            Assert.AreNotEqual(0, report.Positive);
            Assert.AreEqual(44, report.Positive);

            Assert.AreEqual("VBCrypt.AWJ", report.Results["AVG"].Result);
            Assert.AreEqual("Trojan.Win32.VB", report.Results["Ikarus"].Result);
        }
    }
}
