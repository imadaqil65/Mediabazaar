using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EmployeeServices
{
    public class DepartmentService
    {
        private readonly IDepartment department;
        public DepartmentService(IDepartment department)
        {
            this.department = department;
        }

        public void CreateDepartment(Department dep)
        {
            department.CreateDepartment(dep);
        }

        public void DeleteDepartment(int id)
        {
            department.DeleteDepartment(id);
        }

        public Department GetDepartment(int id)
        {
            return department.GetDepartment(id);
        }

        public Department GetDepartment(string name)
        {
            return department.GetDepartment(name);
        }

        public List<string> GetDepartmentNames()
        {
            return department.GetDepartmentNames();
        }

        public void UpdateDepartment(Department dep)
        {
            department.UpdateDepartment(dep);
        }

        public List<Department> ViewActiveDepartment()
        {
            return department.ViewActiveDepartment();   
        }

        public List<Department> ViewAllDepartment()
        {
            return department.ViewAllDepartment();
        }
    }
}
