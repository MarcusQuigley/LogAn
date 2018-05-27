using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quigley.LogAn.Tests
{
    [TestClass]
    public class LogAnalyzerTests
    {
        private LogAnalyzer analyzer;

        [TestInitialize]
        public void Setup()
        {
            analyzer = new LogAnalyzer();
        }

        [TestMethod]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            var result = analyzer.IsValidLogFileName("e.slf");

            Assert.IsTrue(result, "filename not valid");
        }

        [TestMethod]
        public void IsValidFileName_validFileUpperCased_ReturnsTrue()
        {
            var result = analyzer.IsValidLogFileName("e.SLF");

            Assert.IsTrue(result, "filename not valid");
        }

        [TestCleanup]
        public void Cleanup()
        {
            analyzer = null;
        }
    }
}
