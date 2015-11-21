using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
#if DEBUG
            Application.ThreadException += Application_ThreadException;
#endif
            Application.Run(new FrmMain());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception as Exception;
            if (ex != null)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("异常消息："+ex.Message);
                sb.AppendLine("调用堆栈：" + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    sb.AppendLine("内部异常消息：" + ex.InnerException.Message);
                    sb.AppendLine("内部异常堆栈：" + ex.InnerException.StackTrace);
                }

                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show(Convert.ToString(e.Exception));
            }

        }
    }
}
