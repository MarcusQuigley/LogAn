using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quigley.LogAn.Tests
{
    [TestClass]
    public class LogAnalyzerTests
    {
        [TestMethod]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var result = analyzer.IsValidLogFileName("e.SLF");

            Assert.IsTrue(result, "filename not valid");
        }
    }
}
