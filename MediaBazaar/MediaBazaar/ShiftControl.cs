using Domain;
using Domain.Events;
using Domain.WorkShiftServices;
using Infrastructure.WorkShift;
using MediaBazaar.ShiftStuff;
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
    public partial class ShiftControl : UserControl
    {
        private WorkSchedule ws;
        private Home home;
        private Shift morningShift;
        private Shift afternoonShift;
        private Shift eveningShift;
        public DateTime Date { get; private set; }

        public ShiftControl(WorkSchedule ws, Home home)
        {
            InitializeComponent();
            this.ws = ws;
            this.home = home;
        }

        public void SetShiftData(Shift morning, Shift afternoon, Shift evening)
        {
            morningShift = morning;
            afternoonShift = afternoon;
            eveningShift = evening;
            
            UpdateUI();
        }

        public void Days(int numDay)
        {
            LabelDays.Text = numDay.ToString();
            Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, numDay);
            UpdateUI();
        }

        private void UpdateUI()
        {
            UpdateLabelForShift(ShiftName.Morning, morningShift);
            UpdateLabelForShift(ShiftName.Afternoon, afternoonShift);
            UpdateLabelForShift(ShiftName.Evening, eveningShift);
        }
        public enum ShiftName
        {
            Morning,
            Afternoon,
            Evening
        }
        public void GreyOut()
        {
            // Set the background color to grey (or any other style changes)
            this.BackColor = Color.LightGray;

            LBAfternoon.Visible = false;
            LBMorning.Visible = false;
            LBEvening.Visible = false;
            BtnViewShift.Visible = false;
        }

        private void UpdateLabelForShift(ShiftName shiftName, Shift shift)
        {
            Label targetLabel = GetTargetLabel(shiftName);

            if (shift == null)
            {
                targetLabel.Text = "There is no shift created";
                targetLabel.ForeColor = Color.Gray; // Gray maybe? idk im bad at colors 
            }
            else
            {
                int onShift = shift.EmployeesOnShift?.Count ?? 0;
                int needed = shift.NrPeopleNeeded;

                string labelText = $"{shiftName} Shift - {onShift}/{needed}";
                Color labelColor = GetLabelColor(onShift, needed);

                targetLabel.Text = labelText;
                targetLabel.ForeColor = labelColor;
            }
        }

        private Color GetLabelColor(int onShift, int needed)
        {
            if (onShift == 0) return Color.Red;
            return onShift < needed ? Color.Orange : Color.Green;
        }

        private Label GetTargetLabel(ShiftName shiftName)
        {
            return shiftName switch
            {
                ShiftName.Morning => LBMorning,
                ShiftName.Afternoon => LBAfternoon,
                ShiftName.Evening => LBEvening,
                _ => throw new ArgumentException("Invalid shift name", nameof(shiftName)),
            };
        }

        private void BtnViewShift_Click(object sender, EventArgs e)
        {
            EditingShifts editingShifts = new EditingShifts(morningShift, afternoonShift, eveningShift, ws, home);
            editingShifts.Show();
        }

    }
}
