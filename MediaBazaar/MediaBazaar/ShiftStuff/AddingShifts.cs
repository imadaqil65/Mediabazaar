using Domain;
using Domain.WorkShiftServices;
using Infrastructure.WorkShift;
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
    public partial class AddingShifts : Form
    {
        private Home home;
        private WorkSchedule ws;
        private WorkShiftServices workShiftServices;
        public AddingShifts(Home home, WorkSchedule ws)
        {
            InitializeComponent();
            workShiftServices = new WorkShiftServices(new WorkShiftRepository());
            this.home = home;
            this.ws = ws;   
        }

        private void buttonAddShift_Click(object sender, EventArgs e)
        {
            try
            {
                string validationMessage = ValidateShiftInput();
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    MessageBox.Show(validationMessage);
                    return;
                }

                // Parse and set the required shift information
                int peopleNeeded = (int)nudPeopleNeeded.Value;
                DateTime shiftDate = monthCalendar1.SelectionRange.Start;
                string department = comboBoxDepartment.Text;
                ShiftType shiftType = (ShiftType)Enum.Parse(typeof(ShiftType), comboBoxShiftType.Text);

                // Create the Shift object
                Shift newShift = new Shift(shiftType, peopleNeeded, shiftDate, department);

                if (!workShiftServices.CheckIfShiftExisted(newShift))
                {
                    workShiftServices.CreateWorkShift(newShift);

                    ClearFormFields();

                    MessageBox.Show("Shift created successfully!");
                    this.Close();
                    ws.Close();
                    new WorkSchedule(home).Show();
                }
                else
                {
                    MessageBox.Show("Workshift already existed");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private string ValidateShiftInput()
        {
            if (nudPeopleNeeded.Value == 0/*!int.TryParse(textBoxPeopleNeeded.Text, out int peopleNeeded) || peopleNeeded <= 0*/)
            {
                return "Number of people needed must be above 0.";
            }

            if (monthCalendar1.SelectionRange.Start < DateTime.Now.Date)
            {
                return "Cannot select a date in the past.";
            }

            if (comboBoxDepartment.Text == "Department")
            {
                return "Please select a department.";
            }

            if (comboBoxShiftType.Text == "ShiftType")
            {
                return "Please select a shift type.";
            }

            return null; // All validations passed
        }

        private void textBoxPeopleNeeded_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void ClearFormFields()
        {
            // Set NUD back to 0
            nudPeopleNeeded.Value = 0;

            // Reset the MonthCalendar to today's date
            monthCalendar1.SetDate(DateTime.Now);

            // Reset the ComboBoxes to their default state
            comboBoxDepartment.SelectedIndex = comboBoxDepartment.FindStringExact("Department");
            comboBoxShiftType.SelectedIndex = comboBoxShiftType.FindStringExact("ShiftType");
        }
    }
}
