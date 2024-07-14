using Domain;
using Domain.EmployeeServices;
using Infrastructure;

namespace MediaBazaar
{
    public partial class DepartmentManagement : Form
    {
        private Home homepage;
        private DepartmentService departmentServices;
        public DepartmentManagement(Home home)
        {
            InitializeComponent();
            homepage = home;
            departmentServices = new DepartmentService(new DepartmentRepository());
            FillDataGrid();
        }

        private void FillDataGrid(List<Department> dep)
        {
            dgv_Department.DataSource = dep;
            dgv_Department.MultiSelect = false;
        }

        private void FillDataGrid()
        {
            FillDataGrid(departmentServices.ViewActiveDepartment());
        }
        private void FillEditDepartment(Department dep)
        {
            nudId.Value = dep.depId;
            tbxEditName.Text = dep.Name;
            rTbxEditDesc.Text = dep.Description;
        }

        private void ClearEditDepartment()
        {
            nudId.Value = 0;
            tbxEditName.Clear();
            rTbxEditDesc.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Department> dep;
            dep = departmentServices.ViewActiveDepartment().FindAll(x => x.Name.Contains(tbxSearchFilter.Text, (StringComparison)5));
            FillDataGrid(dep);
        }

        private void BtnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
            homepage.Show();
        }

        private void BtnSendToEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectedDep = dgv_Department.SelectedRows[0].DataBoundItem as Department;
                FillEditDepartment(SelectedDep);
                tabcontrol.SelectedTab = tabPage3;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudId.Value != 0)
                {
                    Department dep = new Department((int)nudId.Value, tbxEditName.Text, rTbxEditDesc.Text);
                    departmentServices.UpdateDepartment(dep);
                    MessageBox.Show("Department Edited");
                    ClearEditDepartment();
                    FillDataGrid();
                    tabcontrol.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxName.Text))
                {
                    Department dep = new Department(0, tbxName.Text, rTbxDesc.Text ?? string.Empty);
                    departmentServices.CreateDepartment(dep);
                    MessageBox.Show("Department Added");
                    FillDataGrid();
                    tabcontrol.SelectedTab = tabPage1;
                }
                else if (string.IsNullOrEmpty(tbxName.Text))
                {
                    MessageBox.Show("Department name is empty");
                }
                else
                {
                    MessageBox.Show("Added Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbxSearchFilter.Clear();
            FillDataGrid();
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeForm emp = new EmployeeForm(homepage);
            emp.Show();
        }

        private void BtnWorkShift_Click(object sender, EventArgs e)
        {
            this.Close();
            WorkSchedule emp = new WorkSchedule(homepage);
            emp.Show();
        }

        private void BtnDepotManagement_Click(object sender, EventArgs e)
        {
            this.Close();
            DepotManagement emp = new DepotManagement(homepage);
            emp.Show();
        }

        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            BtnDepotManagement.Visible = false;
        }

        private void BtDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show("Are you sure you want to delete? \rDeletion is permanent", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        DataGridViewRow selectedRow = dgv_Department.SelectedRows[0];
                        int id = (int)selectedRow.Cells["departmentId"].Value;
                        departmentServices.DeleteDepartment(id);
                        FillDataGrid();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }
    }
}
