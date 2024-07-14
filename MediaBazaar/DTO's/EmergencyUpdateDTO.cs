using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmergencyUpdateDTO
    {
        [Required]
        public string emergencyContact { get; set; }
        [Required]
        public string emergencyName { get; set; }
        [Required]
        public string emergencyTypeRelationship { get; set; }
    }
}
