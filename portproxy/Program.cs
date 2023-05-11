using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace portproxy
{
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Single instance
            Mutex mutex = new Mutex(true, "{08cefee5-b457-442a-978c-159bc8652b54}");
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Activate the main window of previous running process
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            mutex.ReleaseMutex();
        }

    }
}
