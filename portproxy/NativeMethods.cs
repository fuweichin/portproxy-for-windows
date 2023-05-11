using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace portproxy
{
    internal class NativeMethods
    {
        /**
         * Notify the main window and activate it
         * Copied from https://stackoverflow.com/questions/19147/what-is-the-correct-way-to-create-a-single-instance-wpf-application#answer-522874
         */
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string message);

        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
    }
}
