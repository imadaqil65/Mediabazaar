using Domain.EmployeeServices;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarSite.Pages
{
    public class ForgotPasswordPageModel : PageModel
    {
        private readonly EmployeeServices EmployeeServices;
        [BindProperty]
        public LoginDTO PasswordChanger { get; set; }
        public string Message { get; private set; }

        public ForgotPasswordPageModel(EmployeeServices employeeServices)
        {
            EmployeeServices = employeeServices;
            PasswordChanger = new LoginDTO();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(EmployeeServices.UpdatePassword(PasswordChanger.Email, PasswordChanger.Password))
                {
                    Message = "PasswordUpdateSuccessfull";
                    return Page();
                }
            }
            Message = "Invalid email/password";
            return Page();
        }
    }
}
