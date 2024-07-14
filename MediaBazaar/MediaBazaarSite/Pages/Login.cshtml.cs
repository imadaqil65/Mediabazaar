using Domain;
using Domain.EmployeeServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using DTO;

namespace MediaBazaarSite.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO loginDTO { get; set; }
        private Employee Employee { get; set; }
        public string Message { get; private set; }
        private readonly EmployeeServices _EmployeeServices;
        public LoginModel(EmployeeServices employeeServices)
        {
            _EmployeeServices = employeeServices;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee = _EmployeeServices.GetEmployeeByEmailAndPassword(loginDTO.Email, loginDTO.Password);
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }

                if (Employee == null)
                {
                    Message = "Invalid username/password";
                    return Page();
                }

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, Employee.email));
                claims.Add(new Claim("Id", Employee.employeeId.ToString()));

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity))
                    .GetAwaiter()
                    .GetResult();

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
