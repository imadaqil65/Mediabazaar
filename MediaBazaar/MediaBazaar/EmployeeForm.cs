using Domain;
using Domain.EmployeeServices;
using Domain.FormCounter;
using Infrastructure;

namespace MediaBazaar
{
    public partial class EmployeeForm : Form
    {
        private readonly Home homepage;
        private EmployeeServices employeeServices;
        private DepartmentService departmentServices;

        public EmployeeForm(Home homepage)
        {
            InitializeComponent();
            this.homepage = homepage;
            try
            {
                employeeServices = new EmployeeServices(new EmployeeRepository());
                departmentServices = new DepartmentService(new DepartmentRepository());
                FillDatagrid();
                FillComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillComboBoxes()
        {
            List<string> departments = new List<string>(departmentServices.GetDepartmentNames());
            CbXContract.DataSource = Enum.GetValues(typeof(FTE));
            CbXDepartment.DataSource = departments;
            CbXEditContract.DataSource = Enum.GetValues(typeof(FTE));
            CbXEditDepartment.DataSource = departments;
            departments.Insert(0, "-");
            cmbxFilter.DataSource = departments;
        }

        private void FillEditEmployee(Employee employee)
        {
            label41.Text = employee.employeeId.ToString();
            TxtBxEditFirstName.Text = employee.firstName;
            TxtBxEditLastName.Text = employee.lastName;
            TxtBxEditEmail.Text = employee.email;
            TxtBxEditPhoneNumber.Text = employee.phoneNumber;
            //TxtBxEditPassword.Text = employee.password;
            TxtBxEditStreet.Text = employee.address[0];
            TxtBxEditPostalCode.Text = employee.address[1];

            TxtBxEditNationality.Text = employee.nationality;
            TxtBxEditBsn.Text = employee.bsn.ToString();
            DtpEditDateOfBirth.Value = Convert.ToDateTime(employee.dateOfBirth);

            TxtBxEditPosition.Text = employee.position;
            CbXEditDepartment.Text = employee.department.Name;
            CbXEditContract.SelectedItem = employee.contract;
            ChkBxEditYes.Checked = employee.language;

            DtPStartDate.Value = Convert.ToDateTime(employee.contract.startDate);
            DtPEndDate.Value = Convert.ToDateTime(employee.contract.endDate);
            CbXContract.SelectedItem = employee.contract.contractType;

            TxtBxEditEmergencyName.Text = employee.emergencyName;
            TxtBxEditEmergencyContact.Text = employee.emergencyContact;
            CbXEditEmergencyRelationship.Text = employee.emergencyTypeRelationship;
        }

        private void ClearEditEmployee()
        {
            label41.Text = string.Empty;
            TxtBxEditFirstName.Clear();
            TxtBxEditLastName.Clear();
            TxtBxEditEmail.Clear();
            TxtBxEditPhoneNumber.Clear();
            TxtBxEditPassword.Clear();
            TxtBxEditStreet.Clear();
            TxtBxEditPostalCode.Clear();

            TxtBxEditNationality.Clear();
            TxtBxEditBsn.Clear();
            DtpEditDateOfBirth.Value = DateTime.Today;

            TxtBxEditPosition.Clear();
            CbXEditDepartment.SelectedIndex = 0;
            CbXEditContract.SelectedIndex = 0;
            ChkBxEditYes.Checked = false;

            DtPStartDate.Value = DateTime.Today;
            DtPEndDate.Value = DateTime.Today;
            CbXContract.SelectedIndex = 0;

            TxtBxEditEmergencyName.Clear();
            TxtBxEditEmergencyContact.Clear();
            CbXEditEmergencyRelationship.SelectedIndex = 0;
        }

        private void FillDatagrid()
        {
            FillDatagrid(employeeServices.GetActiveEmployees());
        }

        private void FillDatagrid(IEnumerable<Employee> list)
        {
            /*dgv_Employee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_Employee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Employee.MultiSelect = false;
            var source = new BindingSource();
            source.DataSource = list;
            dgv_Employee.DataSource = source;

            dgv_Employee.ScrollBars = ScrollBars.Both;*/
            /*dgv_Employee.Columns.Add("DepartmentName", "Department");
            foreach (Employee employee in list)
            {
                dgv_Employee.
            }*/

            dgv_Employee.MultiSelect = false;
            dgv_Employee.DataSource = list;
            dgv_Employee.CellFormatting += dgv_Employee_CellFormatting;

        }

        private void dgv_Employee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if it's the DepartmentName column and the current row is not the header
            if (e.ColumnIndex == dgv_Employee.Columns["department"].Index && e.RowIndex >= 0)
            {
                if (dgv_Employee.Rows[e.RowIndex].DataBoundItem is Employee employee)
                {
                    e.Value = employee.department.Name;
                    e.FormattingApplied = true;
                }
            }
            if (e.ColumnIndex == dgv_Employee.Columns["contract"].Index && e.RowIndex >= 0)
            {
                if (dgv_Employee.Rows[e.RowIndex].DataBoundItem is Employee employee)
                {
                    e.Value = employee.contract.GetContractTypeName();
                    e.FormattingApplied = true;
                }
            }
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string Fname = TxtBxFirstName.Text;
                string Lname = TxtBxLastName.Text;
                string email = TxtBxEmail.Text;
                string phone = TxtBxPhoneNumber.Text;
                string password = TxtBxPassword.Text;
                string[] address = new string[] { TxtBxStreet.Text, TxtBxPostalCode.Text };

                string nationality = TxtBxNationality.Text;
                string bsn = TxtBxBsn.Text;
                DateTime dob = Convert.ToDateTime(DtPDateOfBirth.Value);
                string position = TxtBxPosition.Text;
                Department department = departmentServices.GetDepartment(CbXDepartment.Text);
                FTE contracttype; Enum.TryParse<FTE>(CbXContract.SelectedValue.ToString(), out contracttype);
                Contract contract = new Contract(Convert.ToDateTime(DtPStartDate.Value), Convert.ToDateTime(DtPEndDate.Value), contracttype, null);
                bool language = (ChkBxAddYes.Checked == true) ? true : false;
                string emergencyname = TxtBxEmergencyName.Text;
                string emergencycontact = TxtBxEmergencyContact.Text;
                string emergencyrelationship = CbXEmergencyRelationship.Text;

                string[] TextboxStringCheck = new string[] { Fname, Lname, email, phone, password, address[0], address[1], nationality, bsn, emergencycontact, emergencyname, emergencyrelationship };
                string[] phoneValidate = new string[] { phone, emergencycontact };

                Dictionary<string, string> validationErrors;
                string MessageString;

                bool notEmpty = employeeServices.TextBoxValidation(TextboxStringCheck);
                bool isvalid = employeeServices.ValidateInput(email, password, phoneValidate, bsn, out validationErrors, out MessageString);
                if (isvalid && notEmpty)
                {
                    Employee employee = new Employee(Fname, Lname, employeeServices.HashPassword(password), email, phone, address, nationality, dob, emergencycontact, emergencyname, emergencyrelationship, int.Parse(bsn), position, department, contract, language);
                    employeeServices.CreateEmployee(employee);
                    errorProvider.Clear();
                    MessageBox.Show("Employee Added");
                    FillDatagrid();
                }
                else
                {
                    errorProvider.Clear();
                    MessageBox.Show($"Please check your inputs\r{MessageString}");
                    Dictionary<string, Control> controlsDictionary = new Dictionary<string, Control>();
                    controlsDictionary["TxtBxEmail"] = TxtBxEmail;
                    controlsDictionary["TxtBxPhoneNumber"] = TxtBxPhoneNumber;
                    controlsDictionary["TxtBxBsn"] = TxtBxBsn;
                    controlsDictionary["TxtBxEmergencyContact"] = TxtBxEmergencyContact;
                    controlsDictionary["TxtBxPassword"] = TxtBxPassword;
                    foreach (var error in validationErrors)
                    {
                        if (controlsDictionary.ContainsKey(error.Key))
                        {
                            Control control = controlsDictionary[error.Key];
                            errorProvider.SetError(control, error.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }
        private void BtnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(label41.Text);
                Employee emp = employeeServices.GetEmployee(id);
                string Fname = TxtBxEditFirstName.Text;
                string Lname = TxtBxEditLastName.Text;
                string email = TxtBxEditEmail.Text;
                string phone = TxtBxEditPhoneNumber.Text;
                string password = (string.IsNullOrEmpty(TxtBxEditPassword.Text)) ? emp.password : TxtBxEditPassword.Text;
                string[] address = new string[] { TxtBxEditStreet.Text, TxtBxEditPostalCode.Text };

                string nationality = TxtBxEditNationality.Text;
                string bsn = TxtBxEditBsn.Text;
                DateTime dob = Convert.ToDateTime(DtpEditDateOfBirth.Value);

                string position = TxtBxEditPosition.Text;
                Department department = departmentServices.GetDepartment(CbXEditDepartment.Text);
                FTE contracttype; Enum.TryParse<FTE>(CbXEditContract.SelectedValue.ToString(), out contracttype);
                Contract contract = new Contract(Convert.ToDateTime(DtPEditStartDate.Value), Convert.ToDateTime(DtPEditEndDate.Value), contracttype, null);
                bool language = (ChkBxEditYes.Checked == true) ? true : false;

                string emergencyname = TxtBxEditEmergencyName.Text;
                string emergencycontact = TxtBxEditEmergencyContact.Text;
                string emergencyrelationship = CbXEditEmergencyRelationship.Text;

                string[] TextboxStringCheck = new string[] { Fname, Lname, email, phone, password, address[0], address[1], nationality, bsn, emergencycontact, emergencyname, emergencyrelationship };
                string[] phoneValidate = new string[] { phone, emergencycontact };

                Dictionary<string, string> validationErrors;
                string MessageString;
                //Validate
                bool notEmpty = employeeServices.TextBoxValidation(TextboxStringCheck);
                bool isvalid = employeeServices.ValidateInput(email, password, phoneValidate, bsn, out validationErrors, out MessageString);
                if (isvalid && notEmpty)
                {
                    //Set Details
                    emp.firstName = Fname;
                    emp.lastName = Lname;
                    if (password != emp.password) 
                    { 
                        emp.setNewPassword(password); 
                    }
                    emp.setEmail(email);
                    emp.phoneNumber = phone;
                    emp.address = address;
                    emp.nationality = nationality;
                    emp.dateOfBirth = dob;
                    emp.emergencyContact = emergencycontact;
                    emp.emergencyName = emergencyname;
                    emp.emergencyTypeRelationship = emergencyrelationship;
                    emp.SetBSN(int.Parse(bsn));
                    emp.position = position;
                    emp.department = department;
                    emp.contract = contract;
                    emp.language = language;
                    //Update Details
                    employeeServices.UpdateEmployee(emp);
                    errorProvider.Clear();
                    MessageBox.Show("Employee Edited");
                    ClearEditEmployee();
                    FillDatagrid();
                    tabControl1.SelectedTab = tabPage1;
                }
                else // Validation error
                {
                    errorProvider.Clear();
                    MessageBox.Show($"Please check your inputs\r{MessageString}");
                    Dictionary<string, Control> controlsDictionary = new Dictionary<string, Control>();
                    controlsDictionary["TxtBxEditEmail"] = TxtBxEmail;
                    controlsDictionary["TxtBxEditPhoneNumber"] = TxtBxPhoneNumber;
                    controlsDictionary["TxtBxEditBsn"] = TxtBxBsn;
                    controlsDictionary["TxtBxEditEmergencyContact"] = TxtBxEmergencyContact;
                    controlsDictionary["TxtBxEditPassword"] = TxtBxEditPassword;
                    foreach (var error in validationErrors)
                    {
                        if (controlsDictionary.ContainsKey(error.Key))
                        {
                            Control control = controlsDictionary[error.Key];
                            errorProvider.SetError(control, error.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void setEditEmployee(Employee emp)
        {

        }

        private void BtnFireEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormCounter.Formcounter == 0)
                {
                    FormCounter.Formcounter++;

                    DataGridViewRow selectedRow = dgv_Employee.SelectedRows[0];
                    int id = (int)selectedRow.Cells["employeeId"].Value;
                    Employee employee = employeeServices.GetEmployee(id);
                    DeleteConfirmation delete = new DeleteConfirmation(employee, employeeServices, this);
                    delete.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void BtnSendToEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee;
                DataGridViewRow selectedRow = dgv_Employee.SelectedRows[0];
                int id = (int)selectedRow.Cells["employeeId"].Value;
                employee = employeeServices.GetEmployee(id);
                FillEditEmployee(employee);
                tabControl1.SelectedTab = tabPage3;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtBxFirstName.Text = "John";
            TxtBxLastName.Text = "Johnson";
            TxtBxEmail.Text = "j.jansen@mediabazaar.nl";
            TxtBxPhoneNumber.Text = "0654321789";
            TxtBxPassword.Text = "Password.999";
            TxtBxStreet.Text = "Den Boschweg 11";
            TxtBxPostalCode.Text = "4277PP";

            TxtBxNationality.Text = "Dutch";
            TxtBxBsn.Text = "212329014";
            DtPDateOfBirth.Value = Convert.ToDateTime("01/02/1988");

            TxtBxPosition.Text = "Cashier";
            CbXDepartment.SelectedIndex = 1;
            CbXContract.SelectedIndex = 1;
            ChkBxAddYes.Checked = false;

            TxtBxEmergencyName.Text = "Jullie Janeke";
            TxtBxEmergencyContact.Text = "0644619179";
            CbXEmergencyRelationship.Text = "Spouse";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string NameSearch = tbxSearchFilter.Text;

            // Create a new list to hold the filtered items
            List<Employee> filteredList = new List<Employee>();

            // Use the Where method to filter out the items that do not meet the criteria
            foreach (Employee emp in employeeServices.GetActiveEmployees())
            {
                if (string.IsNullOrEmpty(NameSearch) || emp.GetName().Contains(NameSearch, (StringComparison)5))
                {
                    if (cmbxFilter.Text == emp.department.Name)
                    {
                        filteredList.Add(emp);
                    }
                    else if (cmbxFilter.Text == "-")
                    { filteredList.Add(emp); }
                }
            }

            // Update datagrid
            FillDatagrid(filteredList);
        }

        private void unfilter_Click(object sender, EventArgs e)
        {
            FillDatagrid();
        }

        private void BtnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
            homepage.Show();
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //homepage.Show();
        }

        private void BtnDepotManagement_Click(object sender, EventArgs e)
        {
            this.Close();
            DepotManagement emp = new DepotManagement(homepage);
            emp.Show();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnWorkShift_Click(object sender, EventArgs e)
        {
            this.Close();
            WorkSchedule emp = new WorkSchedule(homepage);
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            DepartmentManagement emp = new DepartmentManagement(homepage);
            emp.Show();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            label41.Text = string.Empty;
            BtnDepotManagement.Visible = false;
            TxtBxPassword.UseSystemPasswordChar = true;
            TxtBxEditPassword.UseSystemPasswordChar = true;
        }

        private void showPassword(CheckBox chbx, TextBox tbx)
        {
            if (chbx.Checked)
            {
                tbx.UseSystemPasswordChar = false;
            }
            else
            {
                tbx.UseSystemPasswordChar = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showPassword(checkBox1, TxtBxPassword);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            showPassword(checkBox2, TxtBxEditPassword);
        }
    }
}
