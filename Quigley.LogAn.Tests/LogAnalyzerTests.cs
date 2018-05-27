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


        #region Interaction Testing Chapter 3
        //Interaction testing is testing how an object sends input to or receives input from other objects
        
        //A mock object is a fake object in the system that decides whether the unit test has passed or failed

        [TestMethod]
        [TestCategory("Chapter 4")]
        public void Analyze_filenametooshort_callwebservice()
        {
            var mock = new MockWebService();
            LogAnalyzer log = new LogAnalyzer(null, mock);
            var filename  = "er.slf";
            log.Analyze(filename);

            Assert.AreEqual(mock.LastError, $"filename is too short: {filename}");

        }

        #endregion
        [TestCleanup]
        public void Cleanup()
        {
            analyzer = null;
        }
    }
}
