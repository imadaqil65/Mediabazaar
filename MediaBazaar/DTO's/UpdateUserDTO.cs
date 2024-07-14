using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UpdateUserDTO
    {
        public string[] Adress { get; private set; } = new string[0];
        protected List<string> addressList = new List<string>();
        public string employeeId { get; set; } = string.Empty;
        [Required]
        public string firstName { get; set; } = string.Empty;
        [Required]
        public string lastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required, MinLength(8),MaxLength(12)]
        public string phoneNumber {  get; set; } = string.Empty;
        [Required]
        public string street {  get; set; } = string.Empty;
        [Required]
        public string postalCode {  get; set; } = string.Empty;

        [Required]
        public string nationality {  get; set; } = string.Empty;
        [Required, MaxLength(11)]
        public string bsn { get; set; } = string.Empty;
/*        [Required]
        public DateTime dateOfBirth { get; set; }*/

        public void FillAdress(string adress, string postal)
        {
            addressList.Add(adress);
            addressList.Add(postal);
            Adress = addressList.ToArray();
        }
/*        [Required, MinLength(10)]
        public string EmergencyContact { get; set; } = string.Empty;
        [Required]
        public string EmergencyName { get; set; } = string.Empty;
        [Required]
        public string EmergencyTypeRelationship { get; set; } = string.Empty;*/
    }
}
