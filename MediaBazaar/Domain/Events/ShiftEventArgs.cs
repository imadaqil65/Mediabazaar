using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class ShiftEventArgs : EventArgs
    {
        public List<Shift> Shifts { get; }

        public ShiftEventArgs(List<Shift> shifts)
        {
            Shifts = shifts;
        }
    }
}
