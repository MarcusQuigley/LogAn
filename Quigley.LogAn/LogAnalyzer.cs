using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quigley.LogAn
{
   public class LogAnalyzer
    {
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
    }
}
