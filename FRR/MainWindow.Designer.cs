namespace FRR
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateStudents = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAllStudents = new System.Windows.Forms.Button();
            this.btnStudentDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFeesDetails = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateStudents
            // 
            this.btnCreateStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateStudents.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateStudents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateStudents.Location = new System.Drawing.Point(21, 31);
            this.btnCreateStudents.Name = "btnCreateStudents";
            this.btnCreateStudents.Size = new System.Drawing.Size(119, 29);
            this.btnCreateStudents.TabIndex = 0;
            this.btnCreateStudents.Text = "Create Students";
            this.btnCreateStudents.UseVisualStyleBackColor = true;
            this.btnCreateStudents.Click += new System.EventHandler(this.btnCreateStudents_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFeesDetails);
            this.groupBox1.Controls.Add(this.btnAllStudents);
            this.groupBox1.Controls.Add(this.btnStudentDetails);
            this.groupBox1.Controls.Add(this.btnCreateStudents);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Students";
            // 
            // btnAllStudents
            // 
            this.btnAllStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllStudents.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllStudents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAllStudents.Location = new System.Drawing.Point(21, 66);
            this.btnAllStudents.Name = "btnAllStudents";
            this.btnAllStudents.Size = new System.Drawing.Size(119, 29);
            this.btnAllStudents.TabIndex = 1;
            this.btnAllStudents.Text = "All Students";
            this.btnAllStudents.UseVisualStyleBackColor = true;
            this.btnAllStudents.Click += new System.EventHandler(this.btnAllStudents_Click);
            // 
            // btnStudentDetails
            // 
            this.btnStudentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentDetails.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStudentDetails.Location = new System.Drawing.Point(21, 101);
            this.btnStudentDetails.Name = "btnStudentDetails";
            this.btnStudentDetails.Size = new System.Drawing.Size(119, 29);
            this.btnStudentDetails.TabIndex = 1;
            this.btnStudentDetails.Text = "Student Details";
            this.btnStudentDetails.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(482, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFeesDetails
            // 
            this.btnFeesDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeesDetails.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeesDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFeesDetails.Location = new System.Drawing.Point(21, 136);
            this.btnFeesDetails.Name = "btnFeesDetails";
            this.btnFeesDetails.Size = new System.Drawing.Size(119, 29);
            this.btnFeesDetails.TabIndex = 2;
            this.btnFeesDetails.Text = "Fees Details";
            this.btnFeesDetails.UseVisualStyleBackColor = true;
            this.btnFeesDetails.Click += new System.EventHandler(this.btnFeesDetails_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(514, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateStudents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStudentDetails;
        private System.Windows.Forms.Button btnAllStudents;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFeesDetails;
    }
}

