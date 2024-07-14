using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class Request
    {
        public int RequestId { get; init; }
        public int EmployeeId { get; private set;}
        public string Message { get; set; }
        public Request(int id, int employeeId, string Message)
        {
            RequestId = id;
            EmployeeId = employeeId;
            this.Message = Message;
        }
        public Request(int EmployeeId, string Message)
        {
            this.EmployeeId = EmployeeId;
            this.Message = Message;
        }
    }
}
