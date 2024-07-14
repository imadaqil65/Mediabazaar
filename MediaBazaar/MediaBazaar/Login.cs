using Domain;
using Domain.EmployeeServices;
using Infrastructure;

namespace MediaBazaar
{
    public partial class Login : Form
    {
        private EmployeeServices employeeServices;
        public Login()
        {
            InitializeComponent();
            employeeServices = new EmployeeServices(new EmployeeRepository());
            TxtBxPassword.UseSystemPasswordChar = true;
            showbutton(true);
        }

        private void showbutton(bool boolean)
        {
            button1.Visible = boolean;
            button2.Visible = boolean;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TxtBxEmail.Text;
                string password = TxtBxPassword.Text;
                Employee employee = employeeServices.GetEmployeeByEmailAndPassword(email, password);
                if (employee != null && (employee.department.depId == 1 || employee.department.depId == 4))
                {
                    this.Hide();
                    new Home(this, employee).Show();
                }
                else
                {
                    MessageBox.Show("Access Denied\rCheck your credentials");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Home(this, new Employee(1, "Tony", "Stark", new Department(1, "HR"))).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Home(this, new Employee(2, "William", "Wools", new Department(4, "Logistics"))).Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TxtBxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TxtBxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}