using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quigley.LogAn
{
   public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                return (fileName.ToLower().EndsWith(".slf"));
            }
            else
            {
                throw new ArgumentException("No filename provided!");
            }
        }
    }
}
