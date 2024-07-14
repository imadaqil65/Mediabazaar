using Domain;
using Domain.EmployeeServices;
using Domain.WorkShiftServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarSite.Pages
{
    [Authorize]
    public class ShiftDetailsModel : PageModel
    {
        private readonly EmployeeServices _EmployeeServices;
        private readonly WorkShiftServices _WorkShiftServices;
        private Employee employee {  get; set; }
        public List<Shift> shifts { get; private set; }
        public string Message { get; private set; }
        public int Date {  get; private set; }
        public ShiftDetailsModel(EmployeeServices employeeServices, WorkShiftServices workShiftServices)
        {
            _EmployeeServices = employeeServices;
            _WorkShiftServices = workShiftServices;
            shifts = new List<Shift>();
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

        public IActionResult OnGet(int date)
        {
            if (date <= 31)
            {
                Date = date;
            }
            else
            {
                Message = "Sorry this does not exist";
                return Page();
            }
            try
            {
                employee = _EmployeeServices.GetEmployee(Convert.ToInt32(CheckLoggedInUser()));
                shifts = _WorkShiftServices.GetEmployeeOnShift(employee);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            List<Shift> FilterShift = FilterShiftForSchedule(shifts, date);
            shifts = FilterShift;
            return Page();
        }

        private List<Shift> FilterShiftForSchedule(List<Shift> employeeShifts, int dayOfDate)
        {
            List<Shift> FilterShift = new List<Shift>();
            
            foreach (Shift shift in employeeShifts)
            {
                if (shift.ShiftDate.Day == dayOfDate)
                {
                    FilterShift.Add(shift);
                }
            }
            return FilterShift;
        }
    }
}
