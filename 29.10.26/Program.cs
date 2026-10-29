using System;
using System.Windows.Forms;

namespace _29._10._26
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Database.Initialize();
            Application.Run(new Form1());
        }
    }
}
