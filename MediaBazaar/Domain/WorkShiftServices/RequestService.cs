using Domain.Interfaces;
using Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkShiftServices
{
    public class RequestService
    {
        private readonly IRequestDB db;
        public RequestService(IRequestDB requestDB)
        {
            db = requestDB;
        }

        public void CreateRequest(Request request)
        {
            db.CreateRequest(request);
        }

        public void DeleteRequest(int id)
        {
            db.DeleteRequest(id);
        }

        public List<Request> GetRequestByEmployeeId(int id)
        {
            return db.GetRequestByEmployeeId(id);
        }

        public Request GetRequestById(int id)
        {
            return db.GetRequestById(id);
        }

        public List<RestockRequest> GetRestockRequests()
        {
            return db.GetRestockRequest();
        }

        public List<ShiftRequest> GetShiftRequests()
        {
            return db.GetShiftRequest();
        }
    }
}
