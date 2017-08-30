using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FRR.BusinessAccess;

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

        private void CreateStudents_Load(object sender, EventArgs e)
        {
            try
            {
                Branch.LoadBranches(cmbBranch);
                Class.LoadClasses(cmbClass);
                cmbBranch.SelectedValue = GlobalData.BranchID;
                cmbClass.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string Msg = this.ValidateControls();
            if (!string.IsNullOrWhiteSpace(Msg))
                MessageBox.Show(Msg);
            else
                try
                {
                    Models.StudentModel New = new Models.StudentModel()
                    {
                        StudentName = txtStudentName.Text,
                        Address = txtAddress.Text,
                        MobileNo = txtMobileNo.Text,
                        RollNo = txtBranchRoll.Text + "-" + txtClassRoll.Text + (txtRollNo.Text.Length == 1 ? "0" + txtRollNo.Text : txtRollNo.Text),
                        ClassID = int.Parse(cmbClass.SelectedValue.ToString()),
                        BranchID = int.Parse(cmbBranch.SelectedValue.ToString())
                    };
                    if (Student.InsertNewStudent(New) == 1) MessageBox.Show("New Student Registered Successfully!!!");
                    else MessageBox.Show("Student Registration Failed!!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace + "\n\n" + ex.InnerException.Message + "\n\n" + ex.InnerException.Source + "\n\n" + ex.InnerException.StackTrace);
                }
        }

        private void cmbBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBranchRoll.Text = cmbBranch.SelectedIndex == 0 ? "" : cmbBranch.Text.Remove(4).Remove(1, 2);
        }

        private void cmbClass_SelectedValueChanged(object sender, EventArgs e)
        {
            txtClassRoll.Text = cmbClass.SelectedIndex == 0 ? "" : cmbClass.Text;
        }

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            (sender as TextBox).ValidateNumber(e, false);
        }
    }
}
