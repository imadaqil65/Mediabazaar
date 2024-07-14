using Domain;
using Domain.EmployeeServices;
using Domain.WorkShiftServices;
using MediaBazaarSite.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarSite.Pages
{
    [Authorize]
    public class WorkScheduleModel : PageModel
    {
        public List<string> Days { get; private set; }
        public List<string> DaysOfWeek { get; private set; }
        public int MonthNumber { get; private set; }
        public int YearNumber { get; private set; }
        public string MonthName { get; private set; }
        public string Year { get; private set; }
        private readonly EmployeeServices _EmployeeServices;
        private readonly WorkShiftServices _WorkShiftServices;
        private Employee employee;
        public List<Shift> shifts { get; private set; }
        public string Message { get; private set; }

        public WorkScheduleModel(EmployeeServices employeeServices, WorkShiftServices workShiftServices)
        {
            _WorkShiftServices = workShiftServices;
            _EmployeeServices = employeeServices;
            shifts = new List<Shift>();
            Refresh();
        }

        private string CheckLoggedInUser()
        {
            var userClaim = User.FindFirst("Id");
            if (userClaim == null)
            {
                return null;
            }
            return userClaim.Value;
        }

        public void OnGet()
        {
            try
            {
                employee = _EmployeeServices.GetEmployee(Convert.ToInt32(CheckLoggedInUser()));
                shifts = _WorkShiftServices.GetEmployeeOnShift(employee);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Refresh();
        }

        private void Refresh()
        {
            Days = LayoutHelper.Days;
            DaysOfWeek = LayoutHelper.DaysOfWeek;
            MonthName = LayoutHelper.MonthName;
            MonthNumber = LayoutHelper.MonthNumber;
            Year = LayoutHelper.Year;
            YearNumber = LayoutHelper.YearNumber;
        }

        public IActionResult OnPost()
        {
            MonthNumber += 1;
            if (MonthNumber == 13)
            {
                YearNumber += 1;
                MonthNumber = 1;
            }
            LayoutHelper.DaysCalc(YearNumber, MonthNumber);

            return RedirectToPage("WorkSchedule");
        }

        public IActionResult OnPostPrevious()
        {
            MonthNumber -= 1;
            if (MonthNumber == 0)
            {
                MonthNumber = 12;
                YearNumber -= 1;
            }
            LayoutHelper.DaysCalc(YearNumber,MonthNumber);
            return RedirectToPage("WorkSchedule");
        }
    }
}
