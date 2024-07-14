using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeDB
    {
        public void CreateEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void RemoveEmployee(Employee employee);
        public List<Employee> ViewAllEmployees();
        public List<Employee> GetActiveEmployees();
        public Employee ViewEmployeeById(int id);
        public Employee GetEmployeeByEmail(string email);
        public bool CheckEmail(string email);
        public bool UpdatePassword(string email, string password);
        public void UpdateEmployeeSite(Employee employee);
    }
}
