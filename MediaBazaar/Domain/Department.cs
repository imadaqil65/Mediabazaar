using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public int depId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Department(int id, string name)
        {
            depId = id;
            Name = name;
        }

        public Department(int id, string name, string description)
        {
            depId = id;
            Name = name;
            Description = description;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
