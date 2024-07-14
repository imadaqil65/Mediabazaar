using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class ShiftRequest : Request
    {
        public DateTime date { get; set; }
        public ShiftType shiftType { get; set; }
        public ShiftRequest(int EmployeeId, string Message, DateTime date, ShiftType shiftType) : base(EmployeeId, Message)
        {
            this.date = date;
            this.shiftType = shiftType;
        }

        public ShiftRequest(int id, int employeeId, string Message, DateTime date, ShiftType shiftType) : base(id, employeeId, Message)
        {
            this.date = date;
            this.shiftType = shiftType;
        }
    }
}
