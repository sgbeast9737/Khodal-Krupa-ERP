using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhodalKrupaERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Main mainForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new Main();
            Application.Run(mainForm);
        }

        public static void AddFormToTab(Form childForm,string tabName)
        {
            mainForm?.AddFormToTab(childForm, tabName);
        }
    }
}
