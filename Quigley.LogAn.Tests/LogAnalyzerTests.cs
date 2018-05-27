using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing =  Microsoft.VisualStudio.TestTools.UnitTesting;
using Quigley.LogAn.Tests.Stubs;

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

        #region Basic Tests Chapter 2

        [TestCategory("Chapter 2")]
        [TestMethod]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            var result = analyzer.IsValidLogFileName("e.slf");

            Assert.IsTrue(result, "filename not valid");
        }

        [TestCategory("Chapter 2")]
        [TestMethod]
        public void IsValidFileName_validFileUpperCased_ReturnsTrue()
        {
            var result = analyzer.IsValidLogFileName("e.SLF");

            Assert.IsTrue(result, "filename not valid");
        }
        [TestCategory("Chapter 2")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Emptyfilename_throws_argumentexception()
        {
            analyzer.IsValidLogFileName(string.Empty);
        }

        /// <summary>
        /// State based test. I examine the state of the class under test.
        /// In this case a property of LogAnalyzer.
        /// </summary>
        [TestCategory("Chapter 2")]
        [TestMethod]
        public void IsValidFileName_validfile_rememberstrue()
        {
            analyzer.IsValidLogFileName("somefile.slf");

            Assert.IsTrue(analyzer.LastFileNameValid);
        }

        #endregion

        #region Stubs and Dependencies Chapter 3

        [TestMethod]
        [TestCategory("Chapter 3")]
        public void IsValidFileName_shorterthan5chars_butsupportedextension_returnsfalse()
        {
            StubFileExtensionManager stub = new StubFileExtensionManager()
            {
                ShouldExtensionBeValid = false
            };
            LogAnalyzer log = new LogAnalyzer(stub);

            log.IsValidLogFileNameFromSeam("d.edf");

            Assert.IsFalse(stub.ShouldExtensionBeValid,
                "File name with less than 5 chars should have failed the method, " +
                "even if the extension is supported");
        }

        #endregion
        [TestCleanup]
        public void Cleanup()
        {
            analyzer = null;
        }
    }
}
