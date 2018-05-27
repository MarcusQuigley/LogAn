using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quigley.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            if (fileName.Length < 5)
            {
                return false;
            }
            var result = fileName.ToLower().EndsWith(".slf");
             return result; 
        }
    }
}
