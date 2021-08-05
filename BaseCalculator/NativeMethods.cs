using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalculator
{
    internal static class NativeMethods
    {
        public const string User32 = "User32.dll";

        [DllImport(User32, EntryPoint = "MessageBoxW", CharSet = CharSet.Unicode)]
        private static extern int MsgBox(IntPtr hWnd, string text, string caption, int options);

        public static DialogResult ErrorMessage(IWin32Window owner, string text, string caption = "Error") =>
            (DialogResult)MsgBox(owner.Handle, text, caption, (int)MessageBoxButtons.OK | (int)MessageBoxIcon.Error);
    }
}
