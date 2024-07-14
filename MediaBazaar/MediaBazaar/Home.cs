using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar
{
    public partial class Home : Form
    {
        Login login;
        Employee employee;
        public Home(Login login, Employee employee)
        {
            InitializeComponent();
            this.login = login;
            this.employee = employee;
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EmployeeForm(this).Show();
        }

        private void BtnDepotManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepotManagement(this).Show();
        }

        private void BtnWorkShift_Click(object sender, EventArgs e)
        {
            this.Hide();
            new WorkSchedule(this).Show();
        }
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepartmentManagement(this).Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if(employee.department.depId == 1)
            {
                BtnDepotManagement.Visible = false;
            }
            else if(employee.department.depId == 4)
            {
                BtnEmployee.Visible = false;
                btnDepartment.Visible = false;
                BtnWorkShift.Visible = false;
            }
        }
    }
}
