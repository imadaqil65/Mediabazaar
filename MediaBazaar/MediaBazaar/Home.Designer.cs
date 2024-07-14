namespace MediaBazaar
{
    partial class Home
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
            this.BtnEmployee = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.BtnDepotManagement = new System.Windows.Forms.Button();
            this.BtnWorkShift = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEmployee
            // 
            this.BtnEmployee.Location = new System.Drawing.Point(8, 44);
            this.BtnEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEmployee.Name = "BtnEmployee";
            this.BtnEmployee.Size = new System.Drawing.Size(272, 65);
            this.BtnEmployee.TabIndex = 0;
            this.BtnEmployee.Text = "Employee";
            this.BtnEmployee.UseVisualStyleBackColor = true;
            this.BtnEmployee.Click += new System.EventHandler(this.BtnEmployee_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDepartment);
            this.groupBox1.Controls.Add(this.BtnDepotManagement);
            this.groupBox1.Controls.Add(this.BtnWorkShift);
            this.groupBox1.Controls.Add(this.BtnEmployee);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(288, 532);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnDepartment
            // 
            this.btnDepartment.Location = new System.Drawing.Point(8, 189);
            this.btnDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(272, 65);
            this.btnDepartment.TabIndex = 3;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // BtnDepotManagement
            // 
            this.BtnDepotManagement.Location = new System.Drawing.Point(8, 262);
            this.BtnDepotManagement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDepotManagement.Name = "BtnDepotManagement";
            this.BtnDepotManagement.Size = new System.Drawing.Size(272, 65);
            this.BtnDepotManagement.TabIndex = 2;
            this.BtnDepotManagement.Text = "Depot Management";
            this.BtnDepotManagement.UseVisualStyleBackColor = true;
            this.BtnDepotManagement.Click += new System.EventHandler(this.BtnDepotManagement_Click);
            // 
            // BtnWorkShift
            // 
            this.BtnWorkShift.Location = new System.Drawing.Point(8, 117);
            this.BtnWorkShift.Margin = new System.Windows.Forms.Padding(4);
            this.BtnWorkShift.Name = "BtnWorkShift";
            this.BtnWorkShift.Size = new System.Drawing.Size(272, 65);
            this.BtnWorkShift.TabIndex = 1;
            this.BtnWorkShift.Text = "WorkShift";
            this.BtnWorkShift.UseVisualStyleBackColor = true;
            this.BtnWorkShift.Click += new System.EventHandler(this.BtnWorkShift_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(525, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(451, 482);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(272, 65);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.button5_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "S";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnEmployee;
        private GroupBox groupBox1;
        private Button btnDepartment;
        private Button BtnDepotManagement;
        private Button BtnWorkShift;
        private Label label1;
        private Button btnLogOut;
    }
}