using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRR
{
    public partial class CreateStudents : Form
    {
        public CreateStudents()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.StudentModel New = new Models.StudentModel()
                {
                    StudentName = txtStudentName.Text,
                    Address = txtAddress.Text,
                    MobileNo = txtMobileNo.Text,
                    RollNo = int.Parse(txtRollNo.Text),
                    ClassID = int.Parse(cmbClass.SelectedValue.ToString()),
                    BranchID = int.Parse(cmbBranch.SelectedValue.ToString())
                };
                if (BusinessAccess.Student.InsertNewStudent(New) == 1) MessageBox.Show("New Student Registered Successfully!!!");
                else MessageBox.Show("Student Registration Failed!!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace + "\n\n" + ex.InnerException.Message + "\n\n" + ex.InnerException.Source + "\n\n" + ex.InnerException.StackTrace);
            }
        }

        private void CreateStudents_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessAccess.Class.LoadClasses(cmbClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
    }
}
