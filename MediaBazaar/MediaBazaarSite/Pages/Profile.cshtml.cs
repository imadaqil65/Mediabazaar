using Domain.EmployeeServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Domain.Converters;

namespace MediaBazaarSite.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UpdateUserDTO updateUser { get; set; }
        public Employee Employee { get; private set; }
        public string Message { get; private set; }
        public string FullName { get; private set; }
        private readonly EmployeeServices _EmployeeServices;
        private EmployeeConverter EmployeeConverter;

        public ProfileModel(EmployeeServices employeeServices)
        {
            _EmployeeServices = employeeServices;
            EmployeeConverter = new EmployeeConverter();
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
        public IActionResult OnGet()
        {
            Refresh();
            if (Employee == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        private void Refresh()
        {
            try
            {
                Employee = _EmployeeServices.GetEmployee(Convert.ToInt32(CheckLoggedInUser()));
                FullName = Employee.GetName();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        public IActionResult OnPost()
        {
            updateUser.employeeId = CheckLoggedInUser();
            Refresh();
            if (ModelState.IsValid)
            {
                updateUser.FillAdress(updateUser.street, updateUser.postalCode);
                Employee UpdatedEmployee = EmployeeConverter.ConvertToEmployee(updateUser, Employee.contract);
                _EmployeeServices.UpdateEmployeeFromSite(UpdatedEmployee);
                return RedirectToPage("Profile");
            }

            return Page();
        }
    }
}
