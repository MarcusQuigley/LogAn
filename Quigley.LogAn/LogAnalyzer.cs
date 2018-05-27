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

        public LogAnalyzer()
        {
            fileExtensionManager = new FileExtensionManager();
        }

        public LogAnalyzer(IExtensionManager mgr)
        {
            fileExtensionManager = mgr;
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
    }
}
