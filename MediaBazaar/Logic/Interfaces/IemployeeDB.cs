using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEmployeeDB
    {
        public void CreateEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void RemoveEmployee(Employee employee);
        public List<Employee> ViewAllEmployees();
        public Employee ViewEmployeeById(int id);
    }
}
