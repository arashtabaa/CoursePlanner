using System.Windows.Forms;

namespace CoursePlanner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.txtPrerequisite = new System.Windows.Forms.TextBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.lstCourses = new System.Windows.Forms.ListView();
            this.colCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrerequisite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSortCourses = new System.Windows.Forms.Button();
            this.lstSortedCourses = new System.Windows.Forms.ListView();
            this.colSortedCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(83, 12);
            this.txtCourse.MaxLength = 30;
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(189, 20);
            this.txtCourse.TabIndex = 0;
            // 
            // txtPrerequisite
            // 
            this.txtPrerequisite.Location = new System.Drawing.Point(83, 38);
            this.txtPrerequisite.MaxLength = 30;
            this.txtPrerequisite.Name = "txtPrerequisite";
            this.txtPrerequisite.Size = new System.Drawing.Size(189, 20);
            this.txtPrerequisite.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(83, 68);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(100, 23);
            this.btnAddCourse.TabIndex = 2;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.BtnAddCourse_Click);
            // 
            // lstCourses
            // 
            this.lstCourses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCourse,
            this.colPrerequisite});
            this.lstCourses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstCourses.HideSelection = false;
            this.lstCourses.Location = new System.Drawing.Point(13, 97);
            this.lstCourses.MultiSelect = false;
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Scrollable = false;
            this.lstCourses.Size = new System.Drawing.Size(259, 95);
            this.lstCourses.TabIndex = 1;
            this.lstCourses.UseCompatibleStateImageBehavior = false;
            this.lstCourses.View = System.Windows.Forms.View.Details;
            // 
            // colCourse
            // 
            this.colCourse.Text = "Course";
            this.colCourse.Width = 120;
            // 
            // colPrerequisite
            // 
            this.colPrerequisite.Text = "Prerequisite";
            this.colPrerequisite.Width = 120;
            // 
            // btnSortCourses
            // 
            this.btnSortCourses.Location = new System.Drawing.Point(83, 198);
            this.btnSortCourses.Name = "btnSortCourses";
            this.btnSortCourses.Size = new System.Drawing.Size(100, 23);
            this.btnSortCourses.TabIndex = 4;
            this.btnSortCourses.Text = "Sort Courses";
            this.btnSortCourses.UseVisualStyleBackColor = true;
            this.btnSortCourses.Click += new System.EventHandler(this.BtnSortCourses_Click);
            // 
            // lstSortedCourses
            // 
            this.lstSortedCourses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSortedCourse});
            this.lstSortedCourses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSortedCourses.HideSelection = false;
            this.lstSortedCourses.Location = new System.Drawing.Point(13, 229);
            this.lstSortedCourses.MultiSelect = false;
            this.lstSortedCourses.Name = "lstSortedCourses";
            this.lstSortedCourses.Scrollable = false;
            this.lstSortedCourses.Size = new System.Drawing.Size(259, 95);
            this.lstSortedCourses.TabIndex = 1;
            this.lstSortedCourses.UseCompatibleStateImageBehavior = false;
            this.lstSortedCourses.View = System.Windows.Forms.View.Details;
            // 
            // colSortedCourse
            // 
            this.colSortedCourse.Text = "Sorted Courses";
            this.colSortedCourse.Width = 240;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Prerequisite:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Course:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSortedCourses);
            this.Controls.Add(this.btnSortCourses);
            this.Controls.Add(this.lstCourses);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.txtPrerequisite);
            this.Controls.Add(this.txtCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Planner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.TextBox txtPrerequisite;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.ListView lstCourses;
        private System.Windows.Forms.ColumnHeader colCourse;
        private System.Windows.Forms.ColumnHeader colPrerequisite;
        private System.Windows.Forms.Button btnSortCourses;
        private System.Windows.Forms.ListView lstSortedCourses;
        private System.Windows.Forms.ColumnHeader colSortedCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private void lstCourses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstCourses.Columns[e.ColumnIndex].Width;
        }
        private void lstSortedCourses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstCourses.Columns[e.ColumnIndex].Width;
        }
    }
}
