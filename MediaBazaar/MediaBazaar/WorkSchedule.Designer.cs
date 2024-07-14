namespace MediaBazaar
{
    partial class WorkSchedule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnBackToHome = new System.Windows.Forms.Button();
            this.BtnDepotManagement = new System.Windows.Forms.Button();
            this.BtnEmployee = new System.Windows.Forms.Button();
            this.BtnWorkShift = new System.Windows.Forms.Button();
            this.buttonCreateShift = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.CbXDepartmentShiftFilter = new System.Windows.Forms.ComboBox();
            this.BtnNextMonth = new System.Windows.Forms.Button();
            this.BtnPreviousMonth = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LbMonth = new System.Windows.Forms.Label();
            this.LbYear = new System.Windows.Forms.Label();
            this.LbWeek = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNow = new System.Windows.Forms.Button();
            this.btnAutomaticWorkshift = new System.Windows.Forms.Button();
            this.dtpAuto = new System.Windows.Forms.DateTimePicker();
            this.nudMinimum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LoadingBar = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.LoadingBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.BtnBackToHome);
            this.groupBox1.Controls.Add(this.BtnDepotManagement);
            this.groupBox1.Controls.Add(this.BtnEmployee);
            this.groupBox1.Controls.Add(this.BtnWorkShift);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(240, 698);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 175);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 65);
            this.button4.TabIndex = 35;
            this.button4.Text = "Department";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnBackToHome
            // 
            this.BtnBackToHome.Location = new System.Drawing.Point(6, 628);
            this.BtnBackToHome.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.BtnBackToHome.Name = "BtnBackToHome";
            this.BtnBackToHome.Size = new System.Drawing.Size(226, 62);
            this.BtnBackToHome.TabIndex = 0;
            this.BtnBackToHome.Text = "Home";
            this.BtnBackToHome.UseVisualStyleBackColor = true;
            this.BtnBackToHome.Click += new System.EventHandler(this.BtnBackToHome_Click);
            // 
            // BtnDepotManagement
            // 
            this.BtnDepotManagement.Location = new System.Drawing.Point(8, 248);
            this.BtnDepotManagement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDepotManagement.Name = "BtnDepotManagement";
            this.BtnDepotManagement.Size = new System.Drawing.Size(224, 65);
            this.BtnDepotManagement.TabIndex = 34;
            this.BtnDepotManagement.Text = "Depot Management";
            this.BtnDepotManagement.UseVisualStyleBackColor = true;
            this.BtnDepotManagement.Click += new System.EventHandler(this.BtnDepotManagement_Click);
            // 
            // BtnEmployee
            // 
            this.BtnEmployee.Location = new System.Drawing.Point(8, 30);
            this.BtnEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEmployee.Name = "BtnEmployee";
            this.BtnEmployee.Size = new System.Drawing.Size(224, 65);
            this.BtnEmployee.TabIndex = 32;
            this.BtnEmployee.Text = "Employee";
            this.BtnEmployee.UseVisualStyleBackColor = true;
            this.BtnEmployee.Click += new System.EventHandler(this.BtnEmployee_Click);
            // 
            // BtnWorkShift
            // 
            this.BtnWorkShift.Location = new System.Drawing.Point(8, 103);
            this.BtnWorkShift.Margin = new System.Windows.Forms.Padding(4);
            this.BtnWorkShift.Name = "BtnWorkShift";
            this.BtnWorkShift.Size = new System.Drawing.Size(224, 65);
            this.BtnWorkShift.TabIndex = 33;
            this.BtnWorkShift.Text = "WorkShift";
            this.BtnWorkShift.UseVisualStyleBackColor = true;
            // 
            // buttonCreateShift
            // 
            this.buttonCreateShift.Location = new System.Drawing.Point(33, 46);
            this.buttonCreateShift.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonCreateShift.Name = "buttonCreateShift";
            this.buttonCreateShift.Size = new System.Drawing.Size(226, 62);
            this.buttonCreateShift.TabIndex = 29;
            this.buttonCreateShift.Text = "Create New Shift";
            this.buttonCreateShift.UseVisualStyleBackColor = true;
            this.buttonCreateShift.Click += new System.EventHandler(this.buttonCreateShift_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(281, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 25);
            this.label12.TabIndex = 28;
            this.label12.Text = "Department Filter";
            // 
            // CbXDepartmentShiftFilter
            // 
            this.CbXDepartmentShiftFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbXDepartmentShiftFilter.FormattingEnabled = true;
            this.CbXDepartmentShiftFilter.Location = new System.Drawing.Point(281, 80);
            this.CbXDepartmentShiftFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.CbXDepartmentShiftFilter.Name = "CbXDepartmentShiftFilter";
            this.CbXDepartmentShiftFilter.Size = new System.Drawing.Size(224, 33);
            this.CbXDepartmentShiftFilter.TabIndex = 25;
            this.CbXDepartmentShiftFilter.SelectedIndexChanged += new System.EventHandler(this.CbXDepartmentShiftFilter_SelectedIndexChanged);
            // 
            // BtnNextMonth
            // 
            this.BtnNextMonth.Location = new System.Drawing.Point(1253, 83);
            this.BtnNextMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnNextMonth.Name = "BtnNextMonth";
            this.BtnNextMonth.Size = new System.Drawing.Size(168, 47);
            this.BtnNextMonth.TabIndex = 5;
            this.BtnNextMonth.Text = "Next Week";
            this.BtnNextMonth.UseVisualStyleBackColor = true;
            this.BtnNextMonth.Click += new System.EventHandler(this.BtnNextMonth_Click);
            // 
            // BtnPreviousMonth
            // 
            this.BtnPreviousMonth.Location = new System.Drawing.Point(692, 83);
            this.BtnPreviousMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPreviousMonth.Name = "BtnPreviousMonth";
            this.BtnPreviousMonth.Size = new System.Drawing.Size(168, 47);
            this.BtnPreviousMonth.TabIndex = 6;
            this.BtnPreviousMonth.Text = "Previous Week";
            this.BtnPreviousMonth.UseVisualStyleBackColor = true;
            this.BtnPreviousMonth.Click += new System.EventHandler(this.BtnPreviousMonth_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(330, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sunday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(772, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tuesday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(541, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Monday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1205, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Thursday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(975, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wednesday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1440, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Friday";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(269, 175);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1578, 205);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // LbMonth
            // 
            this.LbMonth.AutoSize = true;
            this.LbMonth.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbMonth.Location = new System.Drawing.Point(988, 30);
            this.LbMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbMonth.Name = "LbMonth";
            this.LbMonth.Size = new System.Drawing.Size(124, 48);
            this.LbMonth.TabIndex = 15;
            this.LbMonth.Text = "month";
            // 
            // LbYear
            // 
            this.LbYear.AutoSize = true;
            this.LbYear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbYear.Location = new System.Drawing.Point(1292, 30);
            this.LbYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbYear.Name = "LbYear";
            this.LbYear.Size = new System.Drawing.Size(87, 48);
            this.LbYear.TabIndex = 16;
            this.LbYear.Text = "year";
            // 
            // LbWeek
            // 
            this.LbWeek.AutoSize = true;
            this.LbWeek.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbWeek.Location = new System.Drawing.Point(731, 30);
            this.LbWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbWeek.Name = "LbWeek";
            this.LbWeek.Size = new System.Drawing.Size(102, 48);
            this.LbWeek.TabIndex = 17;
            this.LbWeek.Text = "week";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(1650, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 32);
            this.label8.TabIndex = 30;
            this.label8.Text = "Saturday";
            // 
            // btnNow
            // 
            this.btnNow.Location = new System.Drawing.Point(963, 83);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(185, 47);
            this.btnNow.TabIndex = 31;
            this.btnNow.Text = "Current Week";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnAutomaticWorkshift
            // 
            this.btnAutomaticWorkshift.Location = new System.Drawing.Point(22, 167);
            this.btnAutomaticWorkshift.Name = "btnAutomaticWorkshift";
            this.btnAutomaticWorkshift.Size = new System.Drawing.Size(224, 62);
            this.btnAutomaticWorkshift.TabIndex = 32;
            this.btnAutomaticWorkshift.Text = "Automatically Assign Workshift";
            this.btnAutomaticWorkshift.UseVisualStyleBackColor = true;
            this.btnAutomaticWorkshift.Click += new System.EventHandler(this.btnAutomaticWorkshift_Click);
            // 
            // dtpAuto
            // 
            this.dtpAuto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuto.Location = new System.Drawing.Point(22, 68);
            this.dtpAuto.Name = "dtpAuto";
            this.dtpAuto.Size = new System.Drawing.Size(224, 31);
            this.dtpAuto.TabIndex = 33;
            // 
            // nudMinimum
            // 
            this.nudMinimum.Location = new System.Drawing.Point(22, 130);
            this.nudMinimum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinimum.Name = "nudMinimum";
            this.nudMinimum.Size = new System.Drawing.Size(224, 31);
            this.nudMinimum.TabIndex = 34;
            this.nudMinimum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Min Employee on Shift";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 25);
            this.label9.TabIndex = 36;
            this.label9.Text = "Date of Shift";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpAuto);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnAutomaticWorkshift);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudMinimum);
            this.groupBox2.Location = new System.Drawing.Point(269, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 246);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automatic Scheduling";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 30);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1531, 34);
            this.progressBar.TabIndex = 39;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCreateShift);
            this.groupBox3.Location = new System.Drawing.Point(574, 388);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 136);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual Scheduling";
            // 
            // LoadingBar
            // 
            this.LoadingBar.Controls.Add(this.progressBar);
            this.LoadingBar.Location = new System.Drawing.Point(269, 640);
            this.LoadingBar.Name = "LoadingBar";
            this.LoadingBar.Size = new System.Drawing.Size(1578, 76);
            this.LoadingBar.TabIndex = 40;
            this.LoadingBar.TabStop = false;
            this.LoadingBar.Text = "Loading...";
            // 
            // WorkSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1858, 732);
            this.Controls.Add(this.LoadingBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CbXDepartmentShiftFilter);
            this.Controls.Add(this.LbWeek);
            this.Controls.Add(this.LbYear);
            this.Controls.Add(this.LbMonth);
            this.Controls.Add(this.BtnPreviousMonth);
            this.Controls.Add(this.BtnNextMonth);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WorkSchedule";
            this.Text = "WorkSchedule";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkSchedule_FormClosed);
            this.Load += new System.EventHandler(this.WorkSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.LoadingBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CbXDepartmentShiftFilter_SelectedIndexChanged1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GroupBox groupBox1;
        private Button BtnBackToHome;
        private Button BtnNextMonth;
        private Button BtnPreviousMonth;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label LbMonth;
        private Label LbYear;
        private Label LbWeek;
        private Label label12;
        private ComboBox CbXDepartmentShiftFilter;
        private Button buttonCreateShift;
        private Label label8;
        private Button btnNow;
        private Button button4;
        private Button BtnDepotManagement;
        private Button BtnEmployee;
        private Button BtnWorkShift;
        private Button btnAutomaticWorkshift;
        private DateTimePicker dtpAuto;
        private NumericUpDown nudMinimum;
        private Label label1;
        private Label label9;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ProgressBar progressBar;
        private GroupBox LoadingBar;
    }
}