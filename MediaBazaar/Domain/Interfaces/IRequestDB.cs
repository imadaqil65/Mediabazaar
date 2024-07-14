using Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRequestDB
    {
        void CreateRequest(Request request);
        void DeleteRequest(int id);
        Request GetRequestById(int id);
        List<Request> GetRequestByEmployeeId(int id);
        List<RestockRequest> GetRestockRequest();
        List<ShiftRequest> GetShiftRequest();
    }
}
