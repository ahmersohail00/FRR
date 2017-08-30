using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FRR
{
    public partial class AllStudents : Form
    {
        public AllStudents()
        {
            InitializeComponent();
        }



        private void AllStudents_Load(object sender, EventArgs e)
        {
            GlobalData.SendMessage(txtSearch.Handle, GlobalData.EM_SETCUEBANNER, 0, "Search By Name");
            List<Models.StudentModel> Students = GlobalData.AllStudents.Where(s => s.IsActive = true).ToList();
            foreach (var Student in Students)
            {
                int i = dgvStudents.Rows.Add();
                dgvStudents.Rows[i].Cells["StudentID"].Value = Student.StudentID;
                dgvStudents.Rows[i].Cells["StudentName"].Value = Student.StudentName;
                dgvStudents.Rows[i].Cells["Address"].Value = Student.Address;
                dgvStudents.Rows[i].Cells["MobileNo"].Value = Student.MobileNo;
                dgvStudents.Rows[i].Cells["RollNo"].Value = Student.RollNo;
                dgvStudents.Rows[i].Cells["Class"].Value = BusinessAccess.Class.LoadClassByID(Student.ClassID);
                dgvStudents.Rows[i].Cells["Branch"].Value = BusinessAccess.Branch.LoadBranchByID(Student.BranchID);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            GlobalData.AllStudents.Where(s => s.IsActive = true).ToList().ToExcel(@"D:\D.xls");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).SearchBox(dgvStudents, "StudentName");
        }

        
    }
}
