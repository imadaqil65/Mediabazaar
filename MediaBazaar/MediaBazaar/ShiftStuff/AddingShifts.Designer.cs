namespace MediaBazaar
{
    partial class AddingShifts
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
            this.comboBoxShiftType = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddShift = new System.Windows.Forms.Button();
            this.nudPeopleNeeded = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleNeeded)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxShiftType
            // 
            this.comboBoxShiftType.FormattingEnabled = true;
            this.comboBoxShiftType.Items.AddRange(new object[] {
            "MorningShift",
            "AfternoonShift",
            "EveningShift"});
            this.comboBoxShiftType.Location = new System.Drawing.Point(179, 178);
            this.comboBoxShiftType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxShiftType.Name = "comboBoxShiftType";
            this.comboBoxShiftType.Size = new System.Drawing.Size(171, 33);
            this.comboBoxShiftType.TabIndex = 0;
            this.comboBoxShiftType.Text = "Shift Type";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(446, 90);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(13, 15, 13, 15);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Items.AddRange(new object[] {
            "HR",
            "CustomerService",
            "Security",
            "Logistics"});
            this.comboBoxDepartment.Location = new System.Drawing.Point(179, 248);
            this.comboBoxDepartment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(171, 33);
            this.comboBoxDepartment.TabIndex = 3;
            this.comboBoxDepartment.Text = "Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nr Of People Needed";
            // 
            // buttonAddShift
            // 
            this.buttonAddShift.Location = new System.Drawing.Point(39, 480);
            this.buttonAddShift.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddShift.Name = "buttonAddShift";
            this.buttonAddShift.Size = new System.Drawing.Size(313, 38);
            this.buttonAddShift.TabIndex = 5;
            this.buttonAddShift.Text = "Add Shift";
            this.buttonAddShift.UseVisualStyleBackColor = true;
            this.buttonAddShift.Click += new System.EventHandler(this.buttonAddShift_Click);
            // 
            // nudPeopleNeeded
            // 
            this.nudPeopleNeeded.Location = new System.Drawing.Point(179, 116);
            this.nudPeopleNeeded.Name = "nudPeopleNeeded";
            this.nudPeopleNeeded.Size = new System.Drawing.Size(141, 31);
            this.nudPeopleNeeded.TabIndex = 6;
            // 
            // AddingShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 562);
            this.Controls.Add(this.nudPeopleNeeded);
            this.Controls.Add(this.buttonAddShift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.comboBoxShiftType);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddingShifts";
            this.Text = "AddingShifts";
            ((System.ComponentModel.ISupportInitialize)(this.nudPeopleNeeded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxShiftType;
        private MonthCalendar monthCalendar1;
        private ComboBox comboBoxDepartment;
        private Label label1;
        private Button buttonAddShift;
        private NumericUpDown nudPeopleNeeded;
    }
}