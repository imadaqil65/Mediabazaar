using Domain;
using Domain.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarSite.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public Employee Employee { get; private set; }
        private EmployeeServices _EmployeeServices;
        public string BDayMessage {  get; private set; }

        public IndexModel(EmployeeServices employeeServices)
        {
            _EmployeeServices = employeeServices;
            Employee = new Employee("Connection error", "Please try again later");
        }

        public IActionResult OnGet()
        {
            try
            {
                Employee = _EmployeeServices.GetEmployee(Convert.ToInt32(CheckIfSignedIn()));
                CheckBirthday();
            }
            catch (Exception ex)
            {
                BDayMessage = ex.Message;
            }
            return Page();
        }

        private void CheckBirthday()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            if (Employee.dateOfBirth.HasValue &&
                Employee.dateOfBirth.Value.Day == today.Day &&
                Employee.dateOfBirth.Value.Month == today.Month)
            {
                BDayMessage =  "Happy Birthday!";
            }
        }

        private string CheckIfSignedIn()
        {
            var userClaim = User.FindFirst("Id");
            if (userClaim == null)
            {
                return string.Empty;
            }
            return userClaim.Value;
        }

        public IActionResult OnPost()
        {

            return Page();
        }
    }
}