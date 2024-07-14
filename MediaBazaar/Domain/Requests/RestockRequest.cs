using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class RestockRequest : Request
    {
        public int ProductId { get; set; }
        public int RestockNumber { get; set; }
        public RestockRequest(int EmployeeId, string Message, int ProductId, int RestockNumber) : base(EmployeeId, Message)
        {
            this.ProductId = ProductId;
            this.RestockNumber = RestockNumber;
        }

        public RestockRequest(int id, int employeeId, string Message, int ProductId, int RestockNumber) : base(id, employeeId, Message)
        {
            this.ProductId = ProductId;
            this.RestockNumber = RestockNumber;
        }
    }
}
