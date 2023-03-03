using System;

using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class MsgBox : Form
    {
        public MsgBox(string msgToDisplay = "Message")
        {
            InitializeComponent();
            lbMessage.Text = msgToDisplay;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
