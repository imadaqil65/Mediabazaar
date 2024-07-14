using Domain;
using Domain.EmployeeServices;
using Domain.Requests;
using Domain.WorkShiftServices;
using DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarSite.Pages
{
    [Authorize]
    public class ProductsModel : PageModel
    {
        private readonly EmployeeServices _EmployeeServices;
        private readonly ProductService _ProductServices;
        private readonly RequestService _RequestService;
        private Employee employee {  get; set; }
        public string Message { get; private set; }
        public List<Product> Products { get; private set; }
        [BindProperty]
        public RestockDTO Restock { get; set; }
        public ProductsModel(ProductService productServices, EmployeeServices employeeServices, RequestService requestService)
        {
            _ProductServices = productServices;
            _EmployeeServices = employeeServices;
            _RequestService = requestService;
            Products = new List<Product>();
            try
            {
                Products = new List<Product>(_ProductServices.ViewAllProduct());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        public void OnGet()
        {
            try
            {
                employee = _EmployeeServices.GetEmployee(Convert.ToInt32(CheckLoggedInUser()));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
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

        public IActionResult OnPost()
        {
            Restock.EmployeeId = Convert.ToInt32(CheckLoggedInUser());
            if (ModelState.IsValid)
            {
                RestockRequest restockRequest = new RestockRequest(Restock.EmployeeId, Restock.Message, Restock.ProductId, Restock.Stock);

                try
                {
                    _RequestService.CreateRequest(restockRequest);
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
                return RedirectToPage("Success");
            }
            return Page();
        }
    }
}
