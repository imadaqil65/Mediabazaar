using Domain;
using Domain.WorkShiftServices;
using Infrastructure.WorkShift;
using System.Data;

namespace MediaBazaar.ShiftStuff
{
    public partial class EditingShifts : Form
    {

        private Shift morningShift, afternoonShift, eveningShift;
        private WorkShiftServices workShiftServices;
        private WorkSchedule ws;
        private Home home;

        public EditingShifts(Shift MorningShift, Shift AfternoonShift, Shift EveningShift, WorkSchedule ws, Home home)
        {
            InitializeComponent();
            workShiftServices = new WorkShiftServices(new WorkShiftRepository());
            morningShift = MorningShift;
            afternoonShift = AfternoonShift;
            eveningShift = EveningShift;
            this.ws = ws;
            this.home = home;
        }

        private void EditingShifts_Load(object sender, EventArgs e)
        {
            InitializeShiftEditingControls();
            PopulateShiftSelectionComboBox(comboBoxShiftSelection);
            PopulateShiftSelectionComboBox(comboBoxTypeShift2);
            PopulateShiftSelectionComboBox(comboBoxShiftType3);
            //UpdateGrid();
        }

        private void InitializeShiftEditingControls()
        {
            morningShiftNumeric.Value = morningShift?.NrPeopleNeeded ?? 0;
            afternoonShiftNumeric.Value = afternoonShift?.NrPeopleNeeded ?? 0;
            eveningShiftNumeric.Value = eveningShift?.NrPeopleNeeded ?? 0;

            morningShiftNumeric.Enabled = morningShift != null;
            afternoonShiftNumeric.Enabled = afternoonShift != null;
            eveningShiftNumeric.Enabled = eveningShift != null;
        }

        private void PopulateShiftSelectionComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            if (morningShift != null)
                comboBox.Items.Add("Morning Shift");
            if (afternoonShift != null)
                comboBox.Items.Add("Afternoon Shift");
            if (eveningShift != null)
                comboBox.Items.Add("Evening Shift");

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        private void comboBoxShiftSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmployeesOnGrid(comboBoxShiftSelection);
        }

        private void comboBoxTypeShift2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAvailableEmployees(comboBoxTypeShift2);
        }

        private void comboBoxShiftType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmployeesOnGrid(comboBoxShiftType3);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!morningShiftNumeric.ReadOnly)
                {
                    UpdatePeopleNeeded();
                    morningShiftNumeric.ReadOnly = true;
                    afternoonShiftNumeric.ReadOnly = true;
                    eveningShiftNumeric.ReadOnly = true;
                }
                else
                {
                    morningShiftNumeric.ReadOnly = false;
                    afternoonShiftNumeric.ReadOnly = false;
                    eveningShiftNumeric.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        public void UpdatePeopleNeeded()
        {
            bool isUpdated = false; // Flag to check if any update is made

            if (morningShift != null)
            {
                morningShift.NrPeopleNeeded = (int)morningShiftNumeric.Value;
                workShiftServices.UpdateNumberPeopleNeeded(morningShift);
                isUpdated = true;
            }
            if (afternoonShift != null)
            {
                afternoonShift.NrPeopleNeeded = (int)afternoonShiftNumeric.Value;
                workShiftServices.UpdateNumberPeopleNeeded(afternoonShift);
                isUpdated = true;
            }
            if (eveningShift != null)
            {
                eveningShift.NrPeopleNeeded = (int)eveningShiftNumeric.Value;
                workShiftServices.UpdateNumberPeopleNeeded(eveningShift);
                isUpdated = true;
            }

            if (isUpdated)
            {
                MessageBox.Show("Shift information successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void GetEmployeesOnGrid(ComboBox cbx)
        {
            /*List<Employee> employees = index switch
            {
                0 => morningShift?.EmployeesOnShift ?? new List<Employee>(),
                1 => afternoonShift?.EmployeesOnShift ?? new List<Employee>(),
                2 => eveningShift?.EmployeesOnShift ?? new List<Employee>(),
                _ => new List<Employee>(),
            };*/
            List<Employee> employees = new List<Employee>();

            switch (cbx.Text)
            {
                case "Morning Shift":
                    employees = morningShift?.EmployeesOnShift;
                    break;
                case "Afternoon Shift":
                    employees = afternoonShift?.EmployeesOnShift;
                    break;
                case "Evening Shift":
                    employees = eveningShift?.EmployeesOnShift;
                    break;
            }

            UpdateGrid(dataGridEmployees, employees);
            UpdateGrid(dataGridView1, employees);
        }

        public void GetAvailableEmployees(ComboBox cbx)
        {
            /*List<Employee> employees = index switch
            {
                0 => workShiftServices.GetAvailableEmployees(morningShift),
                1 => workShiftServices.GetAvailableEmployees(afternoonShift),
                2 => workShiftServices.GetAvailableEmployees(eveningShift),
                _ => new List<Employee>(),
            };*/
            List<Employee> employees = new List<Employee>();

            switch (cbx.Text)
            {
                case "Morning Shift":
                    employees = workShiftServices.GetAvailableEmployees(morningShift);
                    break;
                case "Afternoon Shift":
                    employees = workShiftServices.GetAvailableEmployees(afternoonShift);
                    break;
                case "Evening Shift":
                    employees = workShiftServices.GetAvailableEmployees(eveningShift);
                    break;
            }

            UpdateGrid(dataGridViewAddEmployees, employees);
        }

        private void UpdateGrid(DataGridView dataGridView, List<Employee> employees)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.MultiSelect = false;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Department");

            foreach (var employee in employees)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = employee.employeeId;
                row["First Name"] = employee.firstName;
                row["Last Name"] = employee.lastName;
                row["Department"] = employee.department.Name;
                dataTable.Rows.Add(row);
            }

            var source = new BindingSource();
            source.DataSource = dataTable;
            dataGridView.DataSource = source;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Update()
        {
            this.Close();
            ws.Close();
            new WorkSchedule(home).Show();
        }

        private void buttonAddEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridViewAddEmployees.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                if (selectedRow != null)
                {
                    // Retrieve the employeeID from the selected row
                    int employeeID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                    // Determine the selected shift based on the combo box selection
                    string selectedText = comboBoxTypeShift2.Text; // Assuming comboBoxTypeShift2 is the combo box for selecting shifts

                    if (selectedText == "Morning Shift" && NrofPeopleMet(morningShift))
                    {
                        // Morning shift
                        MessageBox.Show(workShiftServices.AddEmployeeToShift(morningShift, employeeID));
                        Update();
                    }
                    else if (selectedText == "Afternoon Shift" && NrofPeopleMet(afternoonShift))
                    {
                        // Afternoon shift
                        MessageBox.Show(workShiftServices.AddEmployeeToShift(afternoonShift, employeeID));
                        Update();
                    }
                    else if (selectedText == "Evening Shift" && NrofPeopleMet(eveningShift))
                    {
                        // Evening shift
                        MessageBox.Show(workShiftServices.AddEmployeeToShift(eveningShift, employeeID));
                        Update();
                    }
                    else
                    {
                        // Handle the case where no shift is selected
                        MessageBox.Show("Cannot add Employee to Shift.");
                    }
                }
                else
                {
                    // Handle the case where no row is selected
                    MessageBox.Show("Please select an employee before adding.");
                }
                //UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private bool NrofPeopleMet(Shift shift)
        {
            return shift.EmployeesOnShift.Count() < shift.NrPeopleNeeded;
        }

        private void buttonRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                if (selectedRow != null)
                {
                    switch (MessageBox.Show(this, "Remove this employee from workshift?", "Remove Employee from shift", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            int employeeID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                            string selectedText = comboBoxShiftType3.Text;
                            Shift thisShift = null;
                            switch (selectedText)
                            {
                                case "Morning Shift":
                                    thisShift = morningShift;
                                    break;
                                case "Afternoon Shift":
                                    thisShift = afternoonShift;
                                    break;
                                case "Evening Shift":
                                    thisShift = eveningShift;
                                    break;
                            }
                            workShiftServices.RemoveEmmployeeFromShift(employeeID, thisShift.ShiftID);
                            MessageBox.Show("Employee Removed");
                            Update();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }
    }
}
