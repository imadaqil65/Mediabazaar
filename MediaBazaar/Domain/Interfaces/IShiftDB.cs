using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShiftDB
    {
        public int CreateWorkShift(Shift shift);

        public List<Shift> GetWorkShift(string department);

        public Shift GetShiftById(int id);

        public void RemoveEmployeeFromShift(int employee, int ShiftID);

        public void DeleteWorkShift(Shift shift);

        public void AddEmployeeToShift(int shiftID, int newEmployee);

        public bool CheckIfShiftExisted(Shift shift);

        public void UpdateNumberPeopleNeeded(Shift shift);
        public List<ShiftType> EmployeesShiftonDay(int employeeId, DateTime date);
        public List<Shift> GetEmployeeOnShift(Employee employee);
        public List<Employee> GetAvailableEmployees(Shift shift);
    }
}
