namespace MediaBazaar.ShiftStuff
{
    partial class EditingShifts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button buttonRemoveEmployee;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxShiftSelection = new System.Windows.Forms.ComboBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.eveningShiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.afternoonShiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.morningShiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.dataGridEmployees = new System.Windows.Forms.DataGridView();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddEmployees = new System.Windows.Forms.Button();
            this.dataGridViewAddEmployees = new System.Windows.Forms.DataGridView();
            this.comboBoxTypeShift2 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxShiftType3 = new System.Windows.Forms.ComboBox();
            buttonRemoveEmployee = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eveningShiftNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afternoonShiftNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.morningShiftNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddEmployees)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRemoveEmployee
            // 
            buttonRemoveEmployee.Location = new System.Drawing.Point(666, 60);
            buttonRemoveEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            buttonRemoveEmployee.Size = new System.Drawing.Size(107, 38);
            buttonRemoveEmployee.TabIndex = 6;
            buttonRemoveEmployee.Text = "Remove Employee";
            buttonRemoveEmployee.UseVisualStyleBackColor = true;
            buttonRemoveEmployee.Click += new System.EventHandler(this.buttonRemoveEmployee_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 977);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboBoxShiftSelection);
            this.tabPage1.Controls.Add(this.buttonEdit);
            this.tabPage1.Controls.Add(this.eveningShiftNumeric);
            this.tabPage1.Controls.Add(this.afternoonShiftNumeric);
            this.tabPage1.Controls.Add(this.morningShiftNumeric);
            this.tabPage1.Controls.Add(this.dataGridEmployees);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(788, 939);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Shift";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Shift Type";
            // 
            // comboBoxShiftSelection
            // 
            this.comboBoxShiftSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftSelection.FormattingEnabled = true;
            this.comboBoxShiftSelection.Location = new System.Drawing.Point(364, 49);
            this.comboBoxShiftSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxShiftSelection.Name = "comboBoxShiftSelection";
            this.comboBoxShiftSelection.Size = new System.Drawing.Size(185, 33);
            this.comboBoxShiftSelection.TabIndex = 4;
            this.comboBoxShiftSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxShiftSelection_SelectedIndexChanged);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(78, 181);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(267, 38);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit Number People Needed";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // eveningShiftNumeric
            // 
            this.eveningShiftNumeric.Location = new System.Drawing.Point(174, 140);
            this.eveningShiftNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eveningShiftNumeric.Name = "eveningShiftNumeric";
            this.eveningShiftNumeric.ReadOnly = true;
            this.eveningShiftNumeric.Size = new System.Drawing.Size(171, 31);
            this.eveningShiftNumeric.TabIndex = 2;
            // 
            // afternoonShiftNumeric
            // 
            this.afternoonShiftNumeric.Location = new System.Drawing.Point(174, 85);
            this.afternoonShiftNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.afternoonShiftNumeric.Name = "afternoonShiftNumeric";
            this.afternoonShiftNumeric.ReadOnly = true;
            this.afternoonShiftNumeric.Size = new System.Drawing.Size(171, 31);
            this.afternoonShiftNumeric.TabIndex = 2;
            // 
            // morningShiftNumeric
            // 
            this.morningShiftNumeric.Location = new System.Drawing.Point(174, 21);
            this.morningShiftNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.morningShiftNumeric.Name = "morningShiftNumeric";
            this.morningShiftNumeric.ReadOnly = true;
            this.morningShiftNumeric.Size = new System.Drawing.Size(171, 31);
            this.morningShiftNumeric.TabIndex = 2;
            // 
            // dataGridEmployees
            // 
            this.dataGridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmployees.Location = new System.Drawing.Point(0, 229);
            this.dataGridEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridEmployees.Name = "dataGridEmployees";
            this.dataGridEmployees.RowHeadersWidth = 62;
            this.dataGridEmployees.RowTemplate.Height = 25;
            this.dataGridEmployees.Size = new System.Drawing.Size(780, 701);
            this.dataGridEmployees.TabIndex = 1;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(Domain.Employee);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Evening Shift:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Afternoon Shift:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Morning Shift:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.buttonAddEmployees);
            this.tabPage2.Controls.Add(this.dataGridViewAddEmployees);
            this.tabPage2.Controls.Add(this.comboBoxTypeShift2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(788, 939);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Employees";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Shift Type";
            // 
            // buttonAddEmployees
            // 
            this.buttonAddEmployees.Location = new System.Drawing.Point(666, 60);
            this.buttonAddEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddEmployees.Name = "buttonAddEmployees";
            this.buttonAddEmployees.Size = new System.Drawing.Size(107, 38);
            this.buttonAddEmployees.TabIndex = 3;
            this.buttonAddEmployees.Text = "Add Employee";
            this.buttonAddEmployees.UseVisualStyleBackColor = true;
            this.buttonAddEmployees.Click += new System.EventHandler(this.buttonAddEmployees_Click);
            // 
            // dataGridViewAddEmployees
            // 
            this.dataGridViewAddEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddEmployees.Location = new System.Drawing.Point(0, 108);
            this.dataGridViewAddEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewAddEmployees.Name = "dataGridViewAddEmployees";
            this.dataGridViewAddEmployees.RowHeadersWidth = 62;
            this.dataGridViewAddEmployees.RowTemplate.Height = 25;
            this.dataGridViewAddEmployees.Size = new System.Drawing.Size(784, 822);
            this.dataGridViewAddEmployees.TabIndex = 2;
            // 
            // comboBoxTypeShift2
            // 
            this.comboBoxTypeShift2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeShift2.FormattingEnabled = true;
            this.comboBoxTypeShift2.Location = new System.Drawing.Point(0, 60);
            this.comboBoxTypeShift2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTypeShift2.Name = "comboBoxTypeShift2";
            this.comboBoxTypeShift2.Size = new System.Drawing.Size(208, 33);
            this.comboBoxTypeShift2.TabIndex = 1;
            this.comboBoxTypeShift2.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeShift2_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(buttonRemoveEmployee);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.comboBoxShiftType3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(788, 939);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remove Employees";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shift Type";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 108);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(784, 822);
            this.dataGridView1.TabIndex = 5;
            // 
            // comboBoxShiftType3
            // 
            this.comboBoxShiftType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftType3.FormattingEnabled = true;
            this.comboBoxShiftType3.Location = new System.Drawing.Point(0, 60);
            this.comboBoxShiftType3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxShiftType3.Name = "comboBoxShiftType3";
            this.comboBoxShiftType3.Size = new System.Drawing.Size(204, 33);
            this.comboBoxShiftType3.TabIndex = 4;
            this.comboBoxShiftType3.SelectedIndexChanged += new System.EventHandler(this.comboBoxShiftType3_SelectedIndexChanged);
            // 
            // EditingShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 977);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditingShifts";
            this.Text = "EditingShifts";
            this.Load += new System.EventHandler(this.EditingShifts_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eveningShiftNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afternoonShiftNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.morningShiftNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddEmployees)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridEmployees;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private NumericUpDown eveningShiftNumeric;
        private NumericUpDown afternoonShiftNumeric;
        private NumericUpDown morningShiftNumeric;
        private Button buttonEdit;
        private ComboBox comboBoxShiftSelection;
        private Button buttonAddEmployees;
        private DataGridView dataGridViewAddEmployees;
        private ComboBox comboBoxTypeShift2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private ComboBox comboBoxShiftType3;
        private Label label4;
        private Label label6;
        private Label label5;
        private BindingSource employeeBindingSource;
    }
}