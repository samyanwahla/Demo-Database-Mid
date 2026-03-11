using System;
using System.Windows.Forms;

namespace PhoneBook.UI
{
    // UI LAYER: Entry point for the Windows Forms application
    // Teaching Point 6: UI depends only on BL — it never references DAL directly
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPhoneBook());
        }
    }
}
