using Domain.EmployeeServices;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkShiftServices
{
    public class WorkShiftServices
    {
        private IShiftDB ShiftDB;
        private readonly Random rnd = new Random();

        public WorkShiftServices(IShiftDB shiftDB)
        {
            ShiftDB = shiftDB;
        }

        public void CreateWorkShift(Shift shift)
        {
            ShiftDB.CreateWorkShift(shift);
        }

        public int CreateAndGetWorkshift(Shift shift)
        {
            return ShiftDB.CreateWorkShift(shift);
        }

        public Shift GetShiftById(int id)
        {
            return ShiftDB.GetShiftById(id);
        }

        public string AddEmployeeToShift(Shift shift, int employee)
        {
            string Validation;
            List<ShiftType> types = ShiftDB.EmployeesShiftonDay(employee, shift.ShiftDate);
            if (types.Count == 0 || ValidateAddingEmployee(types, shift, out Validation))
            { 
                ShiftDB.AddEmployeeToShift(shift.ShiftID, employee);
                return "Employee Succesfully added to shift";
            }
            else
            {
                return $"Adding Failed.\r{Validation}";
            }
        }

        public List<ShiftType> EmployeesShiftonDate(Employee emp, DateTime date)
        {
            return ShiftDB.EmployeesShiftonDay(emp.employeeId, date);
        }

        private bool ValidateAddingEmployee(List<ShiftType> types, Shift shift, out string ValidationMessage)
        {
            ValidationMessage = string.Empty;
            if (types.Count == 2)
            {
                ValidationMessage = "Employee cannot work more than 2 shifts a day";
                return false;
            }
            else if (shift.ShiftType == ShiftType.MorningShift && types.Contains(ShiftType.EveningShift))
            {
                ValidationMessage = "Employee's shifts needs to be next to each other";
                return false;
            }
            else if(shift.ShiftType == ShiftType.EveningShift && types.Contains(ShiftType.MorningShift))
            {
                ValidationMessage = "Employee's shifts needs to be next to each other";
                return false;
            }
            return true;
        }

        public void RemoveEmmployeeFromShift(int employee, int ShiftID)
        {
            ShiftDB.RemoveEmployeeFromShift(employee, ShiftID);
        }

        public List<Shift> GetShifts(string department)
        {
            return ShiftDB.GetWorkShift(department);
        }

        public bool CheckIfShiftExisted(Shift shift)
        {
            return ShiftDB.CheckIfShiftExisted(shift);
        }

        public void UpdateNumberPeopleNeeded(Shift shift)
        {
            ShiftDB.UpdateNumberPeopleNeeded(shift);
        }

        public List<Shift> GetEmployeeOnShift(Employee employee)
        {
            return ShiftDB.GetEmployeeOnShift(employee);
        }

        public List<Employee> GetAvailableEmployees(Shift shift)
        {
            return ShiftDB.GetAvailableEmployees(shift);
        }

        public void CreateWorkShiftAutomatically(List<Employee> emps, int minimumNr, DateTime shiftdate, string[] departments)
        {
            foreach (ShiftType shiftType in (ShiftType[])Enum.GetValues(typeof(ShiftType)))
            {
                foreach (string dep in departments)
                {
                    Shift newShift = CreateShift(emps, minimumNr, shiftdate, dep, shiftType);
                    if (!CheckIfShiftExisted(newShift))
                    {
                        int shiftID = CreateAndGetWorkshift(newShift);
                        AssignEmployeesToShifts(emps, dep, shiftdate, shiftID);
                    }
                }
            }
        }

        private Shift CreateShift(List<Employee> emps, int minimumNr, DateTime shiftdate, string dep, ShiftType shiftType)
        {
            int employeeCount = emps.Count(x => x.department.Name == dep);
            int shiftSize = (employeeCount <= minimumNr && employeeCount!=0) ? employeeCount - 1 : minimumNr;

            return new Shift(shiftType, shiftSize, shiftdate, dep);
        }

        private void AssignEmployeesToShifts(List<Employee> emps, string dep, DateTime shiftdate, int shiftID)
        {
            var newList = emps.FindAll(x => x.department.Name == dep).OrderBy(x => rnd.Next());

            foreach (var emp in newList)
            {
                Shift thisShift = GetShiftById(shiftID);
                if (EmployeesShiftonDate(emp, shiftdate).Count() < 2 &&
                    thisShift.EmployeesOnShift.Count() < thisShift.NrPeopleNeeded)
                {
                    AddEmployeeToShift(thisShift, emp.employeeId);
                }
            }
        }
    }
}
