using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quigley.LogAn
{
    public class LogAnalyzer
    {
        readonly IExtensionManager fileExtensionManager;
        readonly IWebService webservice;

        public LogAnalyzer()
        {
            fileExtensionManager = new FileExtensionManager();
        }

        public LogAnalyzer(IExtensionManager mgr )
        {
            fileExtensionManager = mgr;
         }

        public LogAnalyzer(IExtensionManager mgr, IWebService webService)
            :this(mgr)
        {
            webservice = webService;
        }

        public bool LastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var result = fileName.ToLower().EndsWith(".slf");
                LastFileNameValid = result;
                return result;
            }
            else
            {
                LastFileNameValid = false;
                throw new ArgumentException("No filename provided!");
            }
        }

        public bool IsValidLogFileNameFromSeam(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var result = fileExtensionManager.IsValid(fileName);
                LastFileNameValid = result;
                return result;

            }
            else
            {
                LastFileNameValid = false;
                throw new ArgumentException("No filename provided!");
            }
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                webservice.LogError($"filename is too short: {fileName}");
            }
        }
    }
}
