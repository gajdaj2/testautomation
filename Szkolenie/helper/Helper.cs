using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Szkolenie.helper
{
    public class Helper
    {
        public static void Pause(int seconds = 3000)
        {
            Thread.Sleep(seconds);
        }
    }
}
