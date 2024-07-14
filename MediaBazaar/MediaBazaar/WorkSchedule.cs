using Domain;
using Domain.EmployeeServices;
using Domain.WorkShiftServices;
using Infrastructure;
using Infrastructure.WorkShift;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace MediaBazaar
{
    public partial class WorkSchedule : Form
    {
        private readonly Home homepage;
        private WorkShiftServices workShiftServices;
        private EmployeeServices employeeServices;
        private DepartmentService departmentServices;
        private ShiftControl testControl;
        private List<Shift> selectedShifts;
        private BackgroundWorker backgroundWorker;
        public WorkSchedule(Home homepage)
        {
            InitializeComponent();
            try
            {
                employeeServices = new EmployeeServices(new EmployeeRepository());
                workShiftServices = new WorkShiftServices(new WorkShiftRepository());
                departmentServices = new DepartmentService(new DepartmentRepository());
                //DisplayWeeks(week);
                this.homepage = homepage;
                testControl = new ShiftControl(this, homepage);
                List<string> filters = departmentServices.GetDepartmentNames();
                //filters.Insert(0, "-");
                CbXDepartmentShiftFilter.DataSource = filters;
                dtpAuto.Value = DateTime.Now;

                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += BackgroundWorker_DoWork;
                backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                backgroundWorker.WorkerReportsProgress = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private int month = -1;
        private int year;
        private int week = 0;

        private void WorkSchedule_Load(object sender, EventArgs e)
        {
            BtnDepotManagement.Visible = false;
            DisplayWeeks(week);
            LoadingBar.Visible = false;
        }

        /* private void DisplayDays(int monthCheck)
         {
             flowLayoutPanel1.Controls.Clear();
             DateTime now = DateTime.Now;
             if (monthCheck == -1)
             {
                 month = now.Month;
                 year = now.Year;
             }

             if (monthCheck == 13)
             {
                 month = 1;
                 year++;
             }

             if (monthCheck == 0)
             {
                 month = 12;
                 year--;
             }

             string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
             string yearName = year.ToString();

             LbMonth.Text = monthName;
             LbYear.Text = yearName;

             DateTime startOfMonth = new DateTime(year, month, 1);

             int? days = DateTime.DaysInMonth(year, month);

             int? weeks = DateTime.DaysInMonth(year, month);

             int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));

             for (int i = 1; i <= dayOfTheWeek; i++)
             {
                 TestControl2 testBlank = new TestControl2();
                 flowLayoutPanel1.Controls.Add(testBlank);
             }

             for (int i = 1; i <= days; i++)
             {
                 TestControl testBlank = new TestControl();
                 testBlank.Days(i);
                 flowLayoutPanel1.Controls.Add(testBlank);
                 if (i == 7)
                 {
                     return;
                 }
             }

             for (int i = 1; i <= days; i++)
             {
                 TestControl testBlank = new TestControl();
                 testBlank.Days(i);
                 flowLayoutPanel1.Controls.Add(testBlank);
             }
         }*/


        private void BtnNextMonth_Click(object sender, EventArgs e)
        {
            week++;
            DisplayWeeks(week);
        }

        private void BtnPreviousMonth_Click(object sender, EventArgs e)
        {
            week--;
            DisplayWeeks(week);
        }

        private int WeekCalc(int week)
        {
            DateTime time = DateTime.Now;
            if (week != 0)
            {
                time = time.AddDays(week * 7);
            }


            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private void DisplayWeeks(int weekOffset)
        {
            flowLayoutPanel1.Controls.Clear();
            DateTime now = DateTime.Now.Date; // Use Date property to ignore time part

            // Calculate the start of the week
            int daysToSubtract = (int)now.DayOfWeek - (int)DayOfWeek.Sunday;
            DateTime startOfWeek = now.AddDays(-daysToSubtract + (7 * weekOffset));

            // Calculate the end of the week
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Update UI for month, year, and week number
            LbMonth.Text = startOfWeek.ToString("MMMM");
            LbYear.Text = startOfWeek.Year.ToString();
            LbWeek.Text = $"Week {WeekCalc(weekOffset)}";

            // Loop through each day of the week
            for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
            {
                ShiftControl testControl = new ShiftControl(this, homepage);
                testControl.Days(date.Day);

                if (selectedShifts != null)
                {
                    var dailyShifts = selectedShifts.Where(shift => shift.ShiftDate.Date == date.Date).ToList();

                    // Find the actual shift objects for each shift type
                    Shift morningShift = dailyShifts.FirstOrDefault(s => s.ShiftType == ShiftType.MorningShift);
                    Shift afternoonShift = dailyShifts.FirstOrDefault(s => s.ShiftType == ShiftType.AfternoonShift);
                    Shift eveningShift = dailyShifts.FirstOrDefault(s => s.ShiftType == ShiftType.EveningShift);

                    // Pass the shift objects to the TestControl
                    testControl.SetShiftData(morningShift, afternoonShift, eveningShift);
                }
                else
                {
                    // Pass default (null) shift data if no shifts are selected
                    testControl.SetShiftData(null, null, null);
                }

                if (date < now)
                {
                    testControl.GreyOut();
                }

                flowLayoutPanel1.Controls.Add(testControl);
            }
        }

        private (int onShift, int needed) ExtractShiftData(List<Shift> shifts, ShiftType shiftType)
        {
            // Check if shifts list is null
            if (shifts == null)
            {
                return (0, 0); // Return default values if shifts list is null
            }

            var shift = shifts.FirstOrDefault(s => s.ShiftType == shiftType);

            if (shift != null)
            {
                // Check if EmployeesOnShift is null
                int onShift = shift.EmployeesOnShift != null ? shift.EmployeesOnShift.Count : 0;
                int needed = shift.NrPeopleNeeded;
                return (onShift, needed);
            }

            return (0, 0); // Default value if no matching shift data is found
        }

        private void CbXDepartmentShiftFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbXDepartmentShiftFilter.Text != "-")
            {
                selectedShifts = workShiftServices.GetShifts(CbXDepartmentShiftFilter.Text);
            }
            DisplayWeeks(week);
        }

        private void buttonCreateShift_Click(object sender, EventArgs e)
        {
            AddingShifts addingShifts = new AddingShifts(homepage, this);
            addingShifts.ShowDialog();
        }

        private void BtnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
            homepage.Show();
        }

        private void WorkSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            //homepage.Show();
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            DisplayWeeks(0);
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeForm emp = new EmployeeForm(homepage);
            emp.Show();
        }

        private void BtnDepotManagement_Click(object sender, EventArgs e)
        {
            this.Close();
            DepotManagement emp = new DepotManagement(homepage);
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            DepartmentManagement emp = new DepartmentManagement(homepage);
            emp.Show();
        }

        /*private void btnAutomaticWorkshift_Click(object sender, EventArgs e)
        {
            string[] deps = departmentServices.GetDepartmentNames().ToArray();
            List<Employee> emps = new List<Employee>(employeeServices.GetActiveEmployees());
            DateTime shiftdate = dtpAuto.Value;
            int minimumNr = (int)nudMinimum.Value;

            workShiftServices.CreateWorkShiftAutomatically(emps, minimumNr, shiftdate, deps);

            MessageBox.Show("Workshift and Employees assigned");
            this.Close();
            new WorkSchedule(homepage).Show();
        }*/

        private void btnAutomaticWorkshift_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingBar.Visible = true;
                // Disable the button to prevent multiple executions
                btnAutomaticWorkshift.Enabled = false;

                // Start the background operation
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }

        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your time-consuming operation
            string[] deps = departmentServices.GetDepartmentNames().ToArray();
            List<Employee> emps = new List<Employee>(employeeServices.GetActiveEmployees());
            DateTime shiftdate = dtpAuto.Value;
            int minimumNr = (int)nudMinimum.Value;
            // Call your actual method
            workShiftServices.CreateWorkShiftAutomatically(emps, minimumNr, shiftdate, deps);

            int totalSteps = 300; // You may adjust this based on the actual steps
            for (int i = 0; i <= totalSteps; i++)
            {
                // Simulate progress (replace with actual work)
                Thread.Sleep(70);

                // Report progress to the UI thread
                backgroundWorker.ReportProgress((i * 100) / totalSteps);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update the progress bar with the value provided by the background thread
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable the button when the background operation is complete
            btnAutomaticWorkshift.Enabled = true;

            // Show your message and close the form or navigate to the next screen
            MessageBox.Show("Workshift and Employees assigned");
            this.Close();
            new WorkSchedule(homepage).Show();
        }
    }

    /*  private void FillDataGrid(Department department)
      {
          DgVActiveEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

          DgVActiveEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          DgVActiveEmployees.MultiSelect = false;

          DataTable dataTable = new DataTable();
          dataTable.Columns.Add("First Name");
          dataTable.Columns.Add("Last Name");
          dataTable.Columns.Add("Department");

          var employees = employeeServices.GetEmployeesByDepartmentAndActive(department);

                    var employeesBindingList = new BindingList<Employee>();

                      foreach (var employee in employees)
                      {
                          employeesBindingList.Add(new Employee(employee.firstName, employee.lastName, employee.department));
                      }

          foreach (var employee in employees)
          {
              DataRow row = dataTable.NewRow();
              row["First Name"] = employee.firstName;
              row["Last Name"] = employee.lastName;
              row["Department"] = employee.department;
              dataTable.Rows.Add(row);
          }

          var source = new BindingSource();
          source.DataSource = dataTable;
          DgVActiveEmployees.DataSource = source;
          DgVActiveEmployees.ScrollBars = ScrollBars.Both;
      }*/

    /*   private void LoadEnums()
       {
           foreach (var time in Enum.GetValues(typeof(ShiftType)))
           {
               CbXTypeShifts.Items.Add(time);
           }

           foreach (var department in Enum.GetValues(typeof(Department)))
           {
               CbXDepartment.Items.Add(department);
               CbXDepartmentShiftFilter.Items.Add(department);
           }
       }*/

    /*  private void BtnChooseEmployee_Click(object sender, EventArgs e)
      {
          if (CbXDepartment.SelectedItem == null)
          {
              MessageBox.Show("You have not selected an Item");
              return;
          }

          var department = CbXDepartment.SelectedItem.ToString();

          foreach (Department dep in Enum.GetValues(typeof(Department)))
          {
              if (department == dep.ToString())
              {
                  FillDataGrid(dep);
              }
          }

          BtnAddEmployeeToShift.Enabled = true;

      }*/

    /*    private void BtnAddEmployeeToShift_Click(object sender, EventArgs e)
        {
            if (DgVActiveEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have not selected an employee");
                return;
            }
        }*/



    /*  private void CbXDepartment_SelectedIndexChanged(object sender, EventArgs e)
      {
          // Initialize tuples with default values
          var morningShiftData = (onShift: 0, needed: 0);
          var afternoonShiftData = (onShift: 0, needed: 0);
          var eveningShiftData = (onShift: 0, needed: 0);

          // Ensure the department string matches an enum value
          if (Enum.TryParse(CbXDepartment.Text, out Department selectedDepartment))
          {
              List<Shift> Shifts = workShiftServices.GetShifts(selectedDepartment);

              foreach (Shift shift in Shifts)
              {
                  if (shift != null)
                  {
                      if (shift.ShiftType == ShiftType.MorningShift)
                      {
                          morningShiftData = (onShift: shift.EmployeesOnShift.Count, needed: shift.NrPeopleNeeded);
                      }
                      else if (shift.ShiftType == ShiftType.AfternoonShift)
                      {
                          afternoonShiftData = (onShift: shift.EmployeesOnShift.Count, needed: shift.NrPeopleNeeded);
                      }
                      else if (shift.ShiftType == ShiftType.EveningShift)
                      {
                          eveningShiftData = (onShift: shift.EmployeesOnShift.Count, needed: shift.NrPeopleNeeded);
                      }
                  }
              }  
          }
          DisplayWeeks(week, morningShiftData, afternoonShiftData, eveningShiftData);
      }*/

}
