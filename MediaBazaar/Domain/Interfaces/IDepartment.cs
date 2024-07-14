using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDepartment
    {
        void CreateDepartment(Department dep);
        void UpdateDepartment(Department dep);
        void DeleteDepartment(int id);
        Department GetDepartment(int id);
        Department GetDepartment(string Name);
        List<Department> ViewAllDepartment();
        List<Department> ViewActiveDepartment();
        List<string> GetDepartmentNames();
    }
}
