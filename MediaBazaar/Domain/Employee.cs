using Domain.ErrorHandler;

namespace Domain
{
    public class Employee
    {
        public int employeeId { get; private set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; private set; }
        public string email { get; private set; }
        public string phoneNumber { get; set; }
        public string[] address { get; set; } // street, postal code
        public string nationality { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string emergencyContact { get; set; }
        public string emergencyName { get; set; }
        public string emergencyTypeRelationship { get; set; }
        public int bsn { get; private set; }
        public string position { get; set; }
        public Department department { get; set; }
        public Contract contract { get; set; }
        public bool language { get; set; }

        public Employee(string firstName, string lastName, string password, string email, string phoneNumber, string[] address, string nationality, DateTime? date, string emergencyContact, string emergencyName, string emergencyTypeRelationship, int bsn, string position, Department department, Contract contract, bool language)
        { 
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.nationality = nationality;
            this.dateOfBirth = date;
            this.emergencyContact = emergencyContact;
            this.emergencyName = emergencyName;
            this.emergencyTypeRelationship = emergencyTypeRelationship;
            this.bsn = bsn;
            this.position = position;
            this.department = department;
            this.contract = contract;
            this.language = language;
        }

        public Employee(int employeeId, string firstName, string lastName, string password, string email, string phoneNumber, string[] address, string nationality, DateTime? date, string emergencyContact, string emergencyName, string emergencyTypeRelationship, int bsn, string position, Department department, Contract contract, bool language)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.nationality = nationality;
            this.dateOfBirth = date;
            this.emergencyContact = emergencyContact;
            this.emergencyName = emergencyName;
            this.emergencyTypeRelationship = emergencyTypeRelationship;
            this.bsn = bsn;
            this.position = position;
            this.department = department;
            this.contract = contract;
            this.language = language;
        }

        public Employee(int employeeId, string firstName, string lastName, Department department)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
        }

        public Employee(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Employee(string firstName, string lastName, string[] adress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = adress;
        }

        public void SetNewContract(Contract contract)
        {
            this.contract = contract;
        }

        public string GetName()
        { return this.firstName+this.lastName; }

        public void setNewPassword(string password)
        {
            this.password = PasswordHasher.HashPassword(password);
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void SetBSN(int bsn)
        {
            this.bsn = bsn;
        }
    }
}