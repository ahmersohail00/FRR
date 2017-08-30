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
    public partial class FeesDetails : Form
    {
        public FeesDetails()
        {
            InitializeComponent();
        }
        List<Models.StudentModel> _Students;
        private void FeesDetails_Load(object sender, EventArgs e)
        {
            cmbClass.SelectedIndexChanged -= cmbClass_SelectedIndexChanged;
            BusinessAccess.Class.LoadClasses(cmbClass);
            cmbClass.SelectedIndexChanged += cmbClass_SelectedIndexChanged;
            cmbMonth.DataSource = Enum.GetValues(typeof(Month));
            cmbMonth.SelectedItem = DateTime.Today.Month;
            _Students = GlobalData.AllStudents;
            _Students.Insert(0, new Models.StudentModel() { StudentID = 0, StudentName = "Select Student" });

            cmbStudent.DataSource = _Students;
            cmbStudent.DisplayMember = "StudentName";
            cmbStudent.ValueMember = "StudentID";
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Students = GlobalData.AllStudents.Where(s => s.ClassID == int.Parse((sender as ComboBox).SelectedValue.ToString())).ToList();
            _Students.Insert(0, new Models.StudentModel() { StudentID = 0, StudentName = "Select Student" });
            cmbStudent.DataSource = _Students;
            cmbStudent.DisplayMember = "StudentName";
            cmbStudent.ValueMember = "StudentID";
            cmbStudent.SelectedIndex = 0;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFees.ValidateNumber(e, true);
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Msg = this.ValidateControls();
            if (!string.IsNullOrWhiteSpace(Msg))
                MessageBox.Show(Msg);
            else
            {
                int i = dgvStudents.Rows.Add();
                dgvStudents.Rows[i].Cells["StudentID"].Value = int.Parse(cmbStudent.SelectedValue.ToString());
                dgvStudents.Rows[i].Cells["StudentName"].Value = cmbStudent.Text;
                dgvStudents.Rows[i].Cells["Class"].Value = cmbClass.Text;
                dgvStudents.Rows[i].Cells["DateReceived"].Value = DateTime.Parse(txtDate.Value.ToShortDateString());
                dgvStudents.Rows[i].Cells["Fees"].Value = double.Parse(txtFees.Text);
                dgvStudents.Rows[i].Cells["FeesMonth"].Value = cmbMonth.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count > 0)
            {
                MessageBox.Show("Please Add Fees Data First");
                return;
            }
            else
            {

            }
        }
    }
}
