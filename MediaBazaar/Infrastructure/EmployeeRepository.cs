using Domain;
using Domain.EmployeeServices;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EmployeeRepository : IEmployeeDB
    {

        public void CreateEmployee(Employee employee)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                int employeeID;
                string query = "INSERT INTO Employee(firstName,lastName,passwordChar,email,phoneNumber,Street,PostalCode,nationality,dateOfBirth,emergencyContact,emergencyName,emergencyTypeRelationship,bsn,position,language,Department)" +
                    " values (@firstName,@lastName,@passwordChar,@email,@phoneNumber,@Street,@PostalCode,@nationality,@dateOfBirth,@emergencyContact,@emergencyName,@emergencyTypeRelationship,@bsn,@position,@language,@department); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@passwordChar", employee.password);
                    command.Parameters.AddWithValue("@email", employee.email);
                    command.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    command.Parameters.AddWithValue("@Street", employee.address[0]);
                    command.Parameters.AddWithValue("@PostalCode", employee.address[1]);
                    command.Parameters.AddWithValue("@nationality", employee.nationality);
                    command.Parameters.AddWithValue("@dateOfBirth", employee.dateOfBirth);
                    command.Parameters.AddWithValue("@emergencyContact", employee.emergencyContact);
                    command.Parameters.AddWithValue("@emergencyName", employee.emergencyName);
                    command.Parameters.AddWithValue("@emergencyTypeRelationship", employee.emergencyTypeRelationship);
                    command.Parameters.AddWithValue("@bsn", employee.bsn);
                    command.Parameters.AddWithValue("@position", employee.position);
                    command.Parameters.AddWithValue("@language", employee.language);
                    command.Parameters.AddWithValue("@department", employee.department.depId);
                    //command.ExecuteNonQuery();

                    employeeID = Convert.ToInt32(command.ExecuteScalar());
                }
                string query2 = "INSERT INTO Contract(FK_employeeID, startDate, endDate, contractType, terminationReason, Active) values(@FK_ID, @startDate, @endDate, @FTE, null, 1)";
                using (SqlCommand add = new SqlCommand(query2, conn))
                {
                    add.Parameters.AddWithValue("@FK_ID", employeeID);
                    add.Parameters.AddWithValue("@startDate", employee.contract.startDate);
                    add.Parameters.AddWithValue("@endDate", employee.contract.endDate);
                    add.Parameters.AddWithValue("@FTE", employee.contract.contractType);
                    //command.Parameters.AddWithValue("@terminationReason", employee.contract.terminationReason);
                    add.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "UPDATE Employee SET firstName=@firstName,lastName=@lastName,passwordChar=@passwordChar,email=@email,phoneNumber=@phoneNumber,Street=@Street,PostalCode=@postalCode,nationality=@nationality," +
                    "dateOfBirth=@dateOfBirth,emergencyContact=@emergencyContact,emergencyName=@emergencyName,emergencyTypeRelationship=@emergencyTypeRelationship,bsn=@bsn,position=@position,language=@language,Department=@department WHERE employeeID=@ID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ID", employee.employeeId);
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@passwordChar", employee.password);
                    command.Parameters.AddWithValue("@email", employee.email);
                    command.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    command.Parameters.AddWithValue("@Street", employee.address[0]);
                    command.Parameters.AddWithValue("@PostalCode", employee.address[1]);
                    command.Parameters.AddWithValue("@nationality", employee.nationality);
                    command.Parameters.AddWithValue("@dateOfBirth", employee.dateOfBirth);
                    command.Parameters.AddWithValue("@emergencyContact", employee.emergencyContact);
                    command.Parameters.AddWithValue("@emergencyName", employee.emergencyName);
                    command.Parameters.AddWithValue("@emergencyTypeRelationship", employee.emergencyTypeRelationship);
                    command.Parameters.AddWithValue("@bsn", employee.bsn);
                    command.Parameters.AddWithValue("@position", employee.position);
                    command.Parameters.AddWithValue("@language", employee.language);
                    command.Parameters.AddWithValue("@department", employee.department.depId);
                    command.ExecuteNonQuery();
                }
                query = "UPDATE Contract SET startDate=@startDate,endDate=@endDate,contractType=@contractType/*,terminationReason='@terminationReason'*/ WHERE FK_employeeID = @ID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ID", employee.employeeId);
                    command.Parameters.AddWithValue("@startDate", employee.contract.startDate);
                    command.Parameters.AddWithValue("@endDate", employee.contract.endDate);
                    command.Parameters.AddWithValue("@contractType", employee.contract.contractType);
                    //command.Parameters.AddWithValue("@terminationReason", employee.contract.terminationReason);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "UPDATE Contract SET Active = 0, terminationReason=@terminationReason WHERE FK_EmployeeID = @employeeID"; // 0 = Inactive (No contract/removed) 1 = Active. We cannot delete data! Be aware of this
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@employeeID", employee.employeeId);
                    command.Parameters.AddWithValue("@terminationReason", employee.contract.terminationReason);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> ViewAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT e.*,c.*,d.departmentName FROM Employee e INNER JOIN Contract c ON e.employeeID = c.FK_EmployeeID INNER JOIN Department d ON d.departmentID = e.Department";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(GetEmployeInfos(reader));
                    };
                    return employees;
                }
            }
        }

        public List<Employee> GetActiveEmployees()
        {
            List<Employee>? employees = new List<Employee>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT e.*,c.*,d.departmentName FROM Employee e INNER JOIN Contract c ON e.employeeID = c.FK_EmployeeID INNER JOIN Department d ON d.departmentID = e.Department WHERE c.Active=1";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(GetEmployeInfos(reader));
                    };
                    return employees;
                }
            }
        }

        private static Employee GetEmployeInfos(SqlDataReader reader)
        {
            Employee employee = null;

            int id = reader.GetInt32(reader.GetOrdinal("employeeID"));
            string firstname = reader.GetString(reader.GetOrdinal("firstName"));
            string lastname = reader.GetString(reader.GetOrdinal("lastName"));
            string password = reader.GetString(reader.GetOrdinal("passwordChar"));
            string email = reader.GetString(reader.GetOrdinal("email"));
            string phone = reader.GetString(reader.GetOrdinal("phoneNumber"));
            string street = reader.GetString(reader.GetOrdinal("Street"));
            string post = reader.GetString(reader.GetOrdinal("PostalCode"));
            string[] address = new[] { street, post };
            string nation = reader.GetString(reader.GetOrdinal("nationality"));
            DateTime dob = reader.GetDateTime(reader.GetOrdinal("dateOfBirth"));
            string emergencyContact = reader.GetString(reader.GetOrdinal("emergencyContact"));
            string emergencyName = reader.GetString(reader.GetOrdinal("emergencyName"));
            string emergencyRel = reader.GetString(reader.GetOrdinal("emergencyTypeRelationship"));
            int bsn = reader.GetInt32(reader.GetOrdinal("bsn"));
            string position = reader.GetString(reader.GetOrdinal("position"));
            bool language = reader.GetBoolean(reader.GetOrdinal("language"));
            //Department Data
            int depId = reader.GetInt32(reader.GetOrdinal("Department"));
            string depName = reader.GetString(reader.GetOrdinal("departmentName"));
            Department department = new Department(depId, depName);
            //Contract Data
            DateTime startdate = reader.GetDateTime(reader.GetOrdinal("startDate"));
            DateTime enddate = reader.GetDateTime(reader.GetOrdinal("endDate"));
            FTE contractType = (FTE)(reader.GetInt32(reader.GetOrdinal("contractType")));
            string? terminationReason; if (!reader.IsDBNull(reader.GetOrdinal("terminationReason")))
            { terminationReason = reader.GetString(reader.GetOrdinal("terminationReason")); }
            else { terminationReason = null; }

            Contract contract;
            if (terminationReason != null) { contract = new Contract(startdate, enddate, contractType, terminationReason); }
            else { contract = new Contract(startdate, enddate, contractType, null); }
            employee = (new Employee(id, firstname, lastname, password, email, phone, address, nation, dob, emergencyContact, emergencyName, emergencyRel, bsn, position, department, contract, language));

            return employee;
        }

        public Employee ViewEmployeeById(int id)
        {
            Employee employee = null;

            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT e.*,c.*,d.departmentName FROM Employee e INNER JOIN Contract c ON e.employeeID = c.FK_EmployeeID INNER JOIN Department d ON d.departmentID = e.Department WHERE employeeID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        employee = GetEmployeInfos(reader);
                    }
                }
                return employee;
            }
        }

        public Employee GetEmployeeByEmail(string email)
        {
            string query = "SELECT e.*,c.*,d.departmentName FROM Employee e INNER JOIN Contract c ON e.employeeID = c.FK_EmployeeID INNER JOIN Department d ON d.departmentID = e.Department WHERE e.email = @email";
            Employee employee = null;
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    using (SqlCommand customerGet = new SqlCommand(query, conn))
                    {
                        customerGet.Parameters.AddWithValue("@email", email);

                        SqlDataReader reader = customerGet.ExecuteReader();
                        if (reader.Read())
                        {
                            employee = GetEmployeInfos(reader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return employee;
        }

        public bool CheckEmail(string email)
        {
            string query = "SELECT COUNT(*) FROM Employee WHERE email = @email";
            using (SqlConnection conn = Connection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the user exists; otherwise, they don't.
                }
            }
        }

        public bool UpdatePassword(string email, string password)
        {
            string query = "UPDATE Employee SET passwordChar = @password WHERE Email = @email";
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    using (SqlCommand customerUpdate = new SqlCommand(query, conn))
                    {
                        customerUpdate.Parameters.AddWithValue("@password", password);
                        customerUpdate.Parameters.AddWithValue("@email", email);

                        int rowsAffected = customerUpdate.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateEmployeeSite(Employee employee)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "UPDATE Employee SET firstName=@firstName,lastName=@lastName,phoneNumber=@phoneNumber,Street=@Street,PostalCode=@postalCode,nationality=@nationality WHERE employeeID=@ID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ID", employee.employeeId);
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    command.Parameters.AddWithValue("@Street", employee.address[0]);
                    command.Parameters.AddWithValue("@PostalCode", employee.address[1]);
                    command.Parameters.AddWithValue("@nationality", employee.nationality);
                    /*command.Parameters.AddWithValue("@dateOfBirth", employee.dateOfBirth);*/
/*                    command.Parameters.AddWithValue("@emergencyContact", employee.emergencyContact);
                    command.Parameters.AddWithValue("@emergencyName", employee.emergencyName);
                    command.Parameters.AddWithValue("@emergencyTypeRelationship", employee.emergencyTypeRelationship);*/
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
