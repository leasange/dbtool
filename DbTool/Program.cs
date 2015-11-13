using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DbTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new FrmMain());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception as Exception;
            if (ex != null)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            else
            {
                MessageBox.Show(Convert.ToString(e.Exception));
            }

        }
    }
}
