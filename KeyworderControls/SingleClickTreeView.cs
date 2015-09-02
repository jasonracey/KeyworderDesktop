using System;
using System.Windows.Forms;

namespace KeyworderControls
{
    /// <summary>
    /// Prevents double-clicks from changing checkbox state on the TreeView control.
    /// </summary>
    public class SingleClickTreeView : TreeView
    {
        /* 
        See here for explanation:
        http://stackoverflow.com/questions/3174412/winforms-treeview-recursively-check-child-nodes-problem
        */
        protected override void WndProc(ref Message m)
        {
            // Suppress WM_LBUTTONDBLCLK
            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
            else base.WndProc(ref m);
        }
    };
}
