using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contract
    {
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public FTE contractType { get; private set; }
        public string? terminationReason { get; private set; }

        /*public Contract(DateTime startDate, DateTime endDate, FTE contractType)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.contractType = contractType;
        }*/
            public Contract(DateTime startDate, DateTime endDate, FTE contractType, string? terminationReason)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.contractType = contractType;
            this.terminationReason = terminationReason;
        }

        public string GetContractTypeName()
        {
            return this.contractType.ToString();
        }

/*        public void SetTerminationReason(string terminationreason)
        {
            terminationReason = terminationreason;
        }*/
    }
}
