using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_s
{
    public class RestockDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required, MaxLength(120)]
        public string Message { get; set; }
    }
}
