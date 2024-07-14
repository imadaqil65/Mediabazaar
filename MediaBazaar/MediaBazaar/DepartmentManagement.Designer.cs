namespace MediaBazaar
{
    partial class DepartmentManagement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnDepotManagement = new System.Windows.Forms.Button();
            this.BtnWorkShift = new System.Windows.Forms.Button();
            this.BtnEmployee = new System.Windows.Forms.Button();
            this.BtnBackToHome = new System.Windows.Forms.Button();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.tbxSearchFilter = new System.Windows.Forms.TextBox();
            this.BtDeleteProduct = new System.Windows.Forms.Button();
            this.BtnSendToEditProduct = new System.Windows.Forms.Button();
            this.dgv_Department = new System.Windows.Forms.DataGridView();
            this.departmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnAddProduct = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Brand = new System.Windows.Forms.Label();
            this.rTbxDesc = new System.Windows.Forms.RichTextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudId = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.rTbxEditDesc = new System.Windows.Forms.RichTextBox();
            this.tbxEditName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.BtnDepotManagement);
            this.groupBox1.Controls.Add(this.BtnWorkShift);
            this.groupBox1.Controls.Add(this.BtnEmployee);
            this.groupBox1.Controls.Add(this.BtnBackToHome);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(240, 630);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 176);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 65);
            this.button4.TabIndex = 11;
            this.button4.Text = "Department";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // BtnDepotManagement
            // 
            this.BtnDepotManagement.Location = new System.Drawing.Point(8, 249);
            this.BtnDepotManagement.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDepotManagement.Name = "BtnDepotManagement";
            this.BtnDepotManagement.Size = new System.Drawing.Size(224, 65);
            this.BtnDepotManagement.TabIndex = 10;
            this.BtnDepotManagement.Text = "Depot Management";
            this.BtnDepotManagement.UseVisualStyleBackColor = true;
            this.BtnDepotManagement.Click += new System.EventHandler(this.BtnDepotManagement_Click);
            // 
            // BtnWorkShift
            // 
            this.BtnWorkShift.Location = new System.Drawing.Point(8, 104);
            this.BtnWorkShift.Margin = new System.Windows.Forms.Padding(4);
            this.BtnWorkShift.Name = "BtnWorkShift";
            this.BtnWorkShift.Size = new System.Drawing.Size(224, 65);
            this.BtnWorkShift.TabIndex = 9;
            this.BtnWorkShift.Text = "WorkShift";
            this.BtnWorkShift.UseVisualStyleBackColor = true;
            this.BtnWorkShift.Click += new System.EventHandler(this.BtnWorkShift_Click);
            // 
            // BtnEmployee
            // 
            this.BtnEmployee.Location = new System.Drawing.Point(8, 32);
            this.BtnEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEmployee.Name = "BtnEmployee";
            this.BtnEmployee.Size = new System.Drawing.Size(224, 65);
            this.BtnEmployee.TabIndex = 8;
            this.BtnEmployee.Text = "Employee";
            this.BtnEmployee.UseVisualStyleBackColor = true;
            this.BtnEmployee.Click += new System.EventHandler(this.BtnEmployee_Click);
            // 
            // BtnBackToHome
            // 
            this.BtnBackToHome.Location = new System.Drawing.Point(8, 560);
            this.BtnBackToHome.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBackToHome.Name = "BtnBackToHome";
            this.BtnBackToHome.Size = new System.Drawing.Size(225, 62);
            this.BtnBackToHome.TabIndex = 0;
            this.BtnBackToHome.Text = "Home";
            this.BtnBackToHome.UseVisualStyleBackColor = true;
            this.BtnBackToHome.Click += new System.EventHandler(this.BtnBackToHome_Click);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.tabPage1);
            this.tabcontrol.Controls.Add(this.tabPage2);
            this.tabcontrol.Controls.Add(this.tabPage3);
            this.tabcontrol.Location = new System.Drawing.Point(263, 15);
            this.tabcontrol.Margin = new System.Windows.Forms.Padding(4);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(994, 635);
            this.tabcontrol.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearSearch);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.tbxSearchFilter);
            this.tabPage1.Controls.Add(this.BtDeleteProduct);
            this.tabPage1.Controls.Add(this.BtnSendToEditProduct);
            this.tabPage1.Controls.Add(this.dgv_Department);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(986, 597);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Departments";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(844, 85);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(127, 34);
            this.btnClearSearch.TabIndex = 12;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(709, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 34);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(714, 15);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(138, 25);
            this.label31.TabIndex = 10;
            this.label31.Text = "Search by name";
            // 
            // tbxSearchFilter
            // 
            this.tbxSearchFilter.Location = new System.Drawing.Point(710, 45);
            this.tbxSearchFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSearchFilter.Name = "tbxSearchFilter";
            this.tbxSearchFilter.Size = new System.Drawing.Size(260, 31);
            this.tbxSearchFilter.TabIndex = 7;
            // 
            // BtDeleteProduct
            // 
            this.BtDeleteProduct.BackColor = System.Drawing.Color.Red;
            this.BtDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtDeleteProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtDeleteProduct.Location = new System.Drawing.Point(710, 526);
            this.BtDeleteProduct.Margin = new System.Windows.Forms.Padding(4);
            this.BtDeleteProduct.Name = "BtDeleteProduct";
            this.BtDeleteProduct.Size = new System.Drawing.Size(261, 60);
            this.BtDeleteProduct.TabIndex = 2;
            this.BtDeleteProduct.Text = "Delete Department";
            this.BtDeleteProduct.UseVisualStyleBackColor = false;
            this.BtDeleteProduct.Click += new System.EventHandler(this.BtDeleteProduct_Click);
            // 
            // BtnSendToEditProduct
            // 
            this.BtnSendToEditProduct.Location = new System.Drawing.Point(710, 430);
            this.BtnSendToEditProduct.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSendToEditProduct.Name = "BtnSendToEditProduct";
            this.BtnSendToEditProduct.Size = new System.Drawing.Size(261, 60);
            this.BtnSendToEditProduct.TabIndex = 1;
            this.BtnSendToEditProduct.Text = "Edit";
            this.BtnSendToEditProduct.UseVisualStyleBackColor = true;
            this.BtnSendToEditProduct.Click += new System.EventHandler(this.BtnSendToEditProduct_Click);
            // 
            // dgv_Department
            // 
            this.dgv_Department.AutoGenerateColumns = false;
            this.dgv_Department.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Department.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentId,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dgv_Department.DataSource = this.departmentBindingSource;
            this.dgv_Department.Location = new System.Drawing.Point(8, 8);
            this.dgv_Department.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Department.Name = "dgv_Department";
            this.dgv_Department.RowHeadersWidth = 51;
            this.dgv_Department.RowTemplate.Height = 29;
            this.dgv_Department.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Department.Size = new System.Drawing.Size(694, 579);
            this.dgv_Department.TabIndex = 0;
            // 
            // departmentId
            // 
            this.departmentId.DataPropertyName = "depId";
            this.departmentId.HeaderText = "departmentId";
            this.departmentId.MinimumWidth = 8;
            this.departmentId.Name = "departmentId";
            this.departmentId.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(Domain.Department);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnAddProduct);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(986, 597);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Department";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.Location = new System.Drawing.Point(154, 540);
            this.BtnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(286, 46);
            this.BtnAddProduct.TabIndex = 3;
            this.BtnAddProduct.Text = "Add Department";
            this.BtnAddProduct.UseVisualStyleBackColor = true;
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Brand);
            this.groupBox2.Controls.Add(this.rTbxDesc);
            this.groupBox2.Controls.Add(this.tbxName);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(586, 524);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            // 
            // Brand
            // 
            this.Brand.AutoSize = true;
            this.Brand.Location = new System.Drawing.Point(9, 82);
            this.Brand.Name = "Brand";
            this.Brand.Size = new System.Drawing.Size(101, 25);
            this.Brand.TabIndex = 5;
            this.Brand.Text = "Dep. Name";
            // 
            // rTbxDesc
            // 
            this.rTbxDesc.Location = new System.Drawing.Point(140, 130);
            this.rTbxDesc.Name = "rTbxDesc";
            this.rTbxDesc.Size = new System.Drawing.Size(428, 189);
            this.rTbxDesc.TabIndex = 3;
            this.rTbxDesc.Text = "";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(140, 76);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(247, 31);
            this.tbxName.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.btnEditProduct);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(986, 597);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit Department";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudId);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.rTbxEditDesc);
            this.groupBox3.Controls.Add(this.tbxEditName);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(586, 525);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Basic Details";
            // 
            // nudId
            // 
            this.nudId.Enabled = false;
            this.nudId.Location = new System.Drawing.Point(140, 37);
            this.nudId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudId.Name = "nudId";
            this.nudId.Size = new System.Drawing.Size(107, 31);
            this.nudId.TabIndex = 12;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 123);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 25);
            this.label24.TabIndex = 8;
            this.label24.Text = "Description";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(101, 25);
            this.label27.TabIndex = 5;
            this.label27.Text = "Dep. Name";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 25);
            this.label29.TabIndex = 4;
            this.label29.Text = "Dep. Id";
            // 
            // rTbxEditDesc
            // 
            this.rTbxEditDesc.Location = new System.Drawing.Point(140, 123);
            this.rTbxEditDesc.Name = "rTbxEditDesc";
            this.rTbxEditDesc.Size = new System.Drawing.Size(422, 199);
            this.rTbxEditDesc.TabIndex = 3;
            this.rTbxEditDesc.Text = "";
            // 
            // tbxEditName
            // 
            this.tbxEditName.Location = new System.Drawing.Point(140, 77);
            this.tbxEditName.Name = "tbxEditName";
            this.tbxEditName.Size = new System.Drawing.Size(247, 31);
            this.tbxEditName.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "Demo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(154, 541);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(286, 45);
            this.btnEditProduct.TabIndex = 6;
            this.btnEditProduct.Text = "Edit Department";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // DepartmentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 665);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabcontrol);
            this.Name = "DepartmentManagement";
            this.Text = "DepartmentManagement";
            this.Load += new System.EventHandler(this.DepartmentManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabcontrol.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button4;
        private Button BtnDepotManagement;
        private Button BtnWorkShift;
        private Button BtnEmployee;
        private Button BtnBackToHome;
        private TabControl tabcontrol;
        private TabPage tabPage1;
        private Button btnClearSearch;
        private Button btnSearch;
        private Label label31;
        private TextBox tbxSearchFilter;
        private Button BtDeleteProduct;
        private Button BtnSendToEditProduct;
        private DataGridView dgv_Department;
        private TabPage tabPage2;
        private Button BtnAddProduct;
        private GroupBox groupBox2;
        private Label label4;
        private Label Brand;
        private RichTextBox rTbxDesc;
        private TextBox tbxName;
        private TabPage tabPage3;
        private GroupBox groupBox3;
        private Label label24;
        private Label label27;
        private Label label29;
        private RichTextBox rTbxEditDesc;
        private TextBox tbxEditName;
        private Button button2;
        private Button btnEditProduct;
        private NumericUpDown nudId;
        private BindingSource departmentBindingSource;
        private DataGridViewTextBoxColumn departmentId;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}