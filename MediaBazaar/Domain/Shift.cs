using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public int NrPeopleNeeded { get; set; }
        public ShiftType ShiftType { get; set; }
        public DateTime ShiftDate { get; set; }
        public List<Employee> EmployeesOnShift { get; set; }
        public string Department { get; set; }

        //Might need another fields depending on how you want to approach this.
        public Shift() { }
        public Shift(ShiftType shiftType, int NrPeopleNeeded, DateTime date, string department)
        {
            ShiftType = shiftType;
            this.NrPeopleNeeded = NrPeopleNeeded;
            ShiftDate = date;
            Department = department;
            EmployeesOnShift = new List<Employee>();

        }

        public Shift(int SHiftID, ShiftType shiftType, int NrPeopleNeeded, DateTime date, string department)
        {
            ShiftType = shiftType;
            this.NrPeopleNeeded = NrPeopleNeeded;
            ShiftDate = date;
            Department = department;
            EmployeesOnShift = new List<Employee>();
        }

        public Employee[] GetEmployees()
        {
            if(EmployeesOnShift.Count == 0  || EmployeesOnShift == null)
            {
                return new Employee[0];
            }
            else
            {
                return EmployeesOnShift.ToArray();
            }
        }

        public void removeEmployees(Employee employees)
        { EmployeesOnShift.Remove(employees); }
    }
}
