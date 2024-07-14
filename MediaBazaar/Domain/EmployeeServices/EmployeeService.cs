using Domain.ErrorHandler;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.EmployeeServices
{
    public class EmployeeServices
    {
        IEmployeeDB employeeDB;

        public EmployeeServices(IEmployeeDB employeeDB)
        {
            this.employeeDB = employeeDB;
        }

        public void CreateEmployee(Employee employee)
        {
            employeeDB.CreateEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeDB.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeDB.RemoveEmployee(employee);
        }

        public void DeleteById(int id)
        {
            DeleteEmployee(GetEmployee(id));
        }

        public void UpdateEmployeeFromSite(Employee employee)
        {
            employeeDB.UpdateEmployeeSite(employee);
        }

        public IReadOnlyCollection<Employee> GetAllEmployees()
        {
          return employeeDB.ViewAllEmployees();
        }

        public IReadOnlyCollection<Employee> GetActiveEmployees()
        {
            return employeeDB.GetActiveEmployees();
        }

        public IReadOnlyCollection <Employee> GetEmployeesByDepartmentAndActive(Department department)
        {
            List<Employee> employees = employeeDB.GetActiveEmployees();
            List<Employee> activeEmloyee = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.department == department)
                {
                    activeEmloyee.Add(employee);
                }
            }
            return activeEmloyee;
        }

        public Employee GetEmployee(int id)
        {
           return employeeDB.ViewEmployeeById(id);
        }

        public bool ValidateInput(string email, string password, string[] phone, string BSN, out Dictionary<string, string> validationErrors, out string MessageString)
        {
            validationErrors = new Dictionary<string, string>();
            MessageString = string.Empty;
            Regex emailinput = new Regex("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+");
            Regex phoneinput = new Regex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
            Regex BSNinput = new Regex(@"^\d{8,10}$");
            Regex passinput = new Regex("^(?=.*\\d).{8,}$");
            Match emailmatch = emailinput.Match(email);
            Match phonematch = phoneinput.Match(phone[0]);
            Match contactmatch = phoneinput.Match(phone[1]);
            Match passmatch = passinput.Match(password);
            Match BSNMatch = BSNinput.Match(BSN);
            if (!emailmatch.Success)
            {
                validationErrors["TxtBxEmail"] = "Email address is invalid";
                validationErrors["TxtBxEditEmail"] = "Email address is invalid";
            }
            if (!phonematch.Success)
            { 
                validationErrors["TxtBxPhoneNumber"] = "Phone number is invalid";
                validationErrors["TxtBxEditPhoneNumber"] = "Phone number is invalid";
            }
            if (!BSNMatch.Success)
            {
                validationErrors["TxtBxBsn"] = "BSN is invalid (Needs to be all numbers and contains 8-10 characters)";
                validationErrors["TxtBxEditBsn"] = "BSN is invalid (Needs to be numbers and contains 8-10 characters)";
                MessageString = "\rBSN needs to be numbers\rand contains 8-10 characters";
            }
            if (!contactmatch.Success)
            {
                validationErrors["TxtBxEmergencyContact"] = "Phone number is invalid";
                validationErrors["TxtBxEditEmergencyContact"] = "Phone number is invalid";
            }
            if (!passmatch.Success)
            {
                validationErrors["TxtBxPassword"] = "Password is invalid (Needs to be at least 1 capital letter, 1 small letter, a special character, and 8 characters long)";
                validationErrors["TxtBxEditPassword"] = "Password is invalid (Needs to be at least 1 capital letter, 1 small letter, a special character, and 8 characters long)";
                
            }

            bool isValid = validationErrors.Count == 0;
            
            return isValid;
        }

        public bool TextBoxValidation(string[] strings)
        {
            if (strings.Any(x => string.IsNullOrEmpty(x.ToString())))
            {
                return false;
            }
            return true;
        }

        public string HashPassword(string password)
        {
            return PasswordHasher.HashPassword(password);
        }

        public bool VerifyPassword(string password, Employee employee)
        {
            return PasswordHasher.VerifyPassword(password, employee.password);
        }

        public Employee? GetEmployeeByEmailAndPassword(string email, string password)
        {
            Employee? employee = employeeDB.GetEmployeeByEmail(email);
            if (employee != null)
            {
                if (PasswordHasher.VerifyPassword(password, employee.password))
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public bool CheckEmail(string email)
        {
            return employeeDB.CheckEmail(email);
        }

        public bool UpdatePassword(string email, string password)
        {
            string hashedPassword = HashPassword(password);
            if (CheckEmail(email))
            {
                return employeeDB.UpdatePassword(email, hashedPassword);
            }
            return false;
        }
    }
}
