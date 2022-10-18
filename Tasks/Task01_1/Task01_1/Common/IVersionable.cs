using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    interface IVersionable
    {
        public Version GetVersion();

        public void SetVersion(string version);
    }
}
