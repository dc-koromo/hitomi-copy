using System;
using System.Runtime.InteropServices;

namespace Hitomi_Copy_3
{
    // https://stackoverflow.com/questions/5131534/how-to-get-windows-native-look-for-the-net-treeview
    public class NativeTreeView : System.Windows.Forms.TreeView
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                                string pszSubIdList);

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetWindowTheme(this.Handle, "explorer", null);
        }
    }
}
