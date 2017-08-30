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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateStudents_Click(object sender, EventArgs e)
        {
            CreateStudents S = new CreateStudents();
            S.ShowDialog();
        }

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            AllStudents S = new AllStudents();
            S.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(new DateTime(1991, 12, 28).Age());
        }

        private void btnFeesDetails_Click(object sender, EventArgs e)
        {
            FeesDetails f = new FeesDetails();
            f.ShowDialog();

            
        }
    }
}
