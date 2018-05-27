using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quigley.LogAn.Tests.Stubs
{
    class StubFileExtensionManager : IExtensionManager
    {
        public bool ShouldExtensionBeValid { get; set; }

        public bool IsValid(string fileName)
        {
            return ShouldExtensionBeValid;
        }
    }
}
