using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalData.BranchID = 2;
            GlobalData.AllBranches = BusinessAccess.Branch.LoadAllBranches();
            GlobalData.AllClasses = BusinessAccess.Class.LoadAllClasses();
            GlobalData.AllStudents = BusinessAccess.Student.LoadAllStudents();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
