using Domain;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Infrastructure.WorkShift
{
    public class WorkShiftRepository : IShiftDB
    {

        public int CreateWorkShift(Shift shift)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "INSERT INTO Shift(shiftType, peopleNeeded, shiftDate, FK_DepartmentID) OUTPUT INSERTED.ShiftID VALUES (@ShiftTYpe, @people,@date, (SELECT departmentID FROM Department WHERE departmentName = @departmentName));";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@shiftType", shift.ShiftType.ToString());
                    command.Parameters.AddWithValue("@people", shift.NrPeopleNeeded);
                    command.Parameters.AddWithValue("@date", shift.ShiftDate);
                    command.Parameters.AddWithValue("@departmentName", shift.Department);

                    shift.ShiftID = (int)command.ExecuteScalar();
                }

                string query2 = "INSERT INTO ShiftConnection (FK_EmployeeId, FK_ShiftId) VALUES (@employeeId,@shiftID)";
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    foreach (var employee in shift.EmployeesOnShift)
                    {
                        command.Parameters.AddWithValue("@employeeId", employee.employeeId);
                        command.Parameters.AddWithValue("@shiftid", shift.ShiftID);
                        command.ExecuteNonQuery();
                    }
                }
                //shift.EmployeesOnShift = GetEmployeesOnShift(shift.ShiftID);
                return shift.ShiftID;
            }
        }

        /*public void UpdateWorkShift(Department department, Employee newEmployee)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query2 = "INSERT INTO ShiftConnection (FK_EmployeeId, FK_ShiftId) VALUES (@employeeId, (SELECT s.shiftID FROM Shift as s INNER JOIN Department as d ON s.FK_DepartmentID = d.departmentID WHERE d.departmentName = @departmentName)";
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                        command.Parameters.AddWithValue("@employeeId", newEmployee.employeeId);
                        command.Parameters.AddWithValue("@departmentName", department.ToString());

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                }
            }
        }*/

        public Shift GetShiftById(int id)
        {
            Shift shift = new Shift();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT s.*, d.departmentName FROM Shift s INNER JOIN Department d ON s.FK_DepartmentID = d.departmentID WHERE ShiftID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shift = new Shift
                            {
                                ShiftID = Convert.ToInt32(reader["shiftID"]),
                                NrPeopleNeeded = Convert.ToInt32(reader["peopleNeeded"]),
                                ShiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["ShiftType"].ToString()),
                                ShiftDate = Convert.ToDateTime(reader["shiftDate"]),
                                Department = reader["departmentName"].ToString(),
                                EmployeesOnShift = new List<Employee>()
                            };
                            shift.EmployeesOnShift = GetEmployeesOnShift(shift.ShiftID);
                        }
                    }
                }
            }
            return shift;
        }

        private Department GetDepartment(string name)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Department WHERE departmentName = @name";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string description;
                            if (!reader.IsDBNull(2))
                                description = reader.GetString(2);
                            else description = null;

                            return new Department(id, name, description);
                        }
                        return null;
                    }
                }
            }
        }

        public List<Shift> GetWorkShift(string department)
        {
            List<Shift> shifts = new List<Shift>();

            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Shift WHERE FK_DepartmentID = (SELECT departmentId FROM Department WHERE departmentName = @departmentName)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@departmentName", department);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shift shift = new Shift
                            {
                                ShiftID = Convert.ToInt32(reader["shiftID"]),
                                NrPeopleNeeded = Convert.ToInt32(reader["peopleNeeded"]),
                                ShiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["ShiftType"].ToString()),
                                ShiftDate = Convert.ToDateTime(reader["shiftDate"]),
                                Department = department,
                                EmployeesOnShift = new List<Employee>()
                            };

                            // Fetch employees on this shift
                            shift.EmployeesOnShift = GetEmployeesOnShift(shift.ShiftID);

                            shifts.Add(shift);
                        }
                    }
                }
            }
            return shifts;
        }

        private List<Employee> GetEmployeesOnShift(int shiftId)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT e.employeeID, e.firstName, e.lastName, e.department, d.departmentName FROM Employee e INNER JOIN ShiftConnection sc on sc.FK_EmployeeId = e.employeeID LEFT JOIN Department d ON d.departmentID = e.department INNER JOIN Shift s on s.shiftID = sc.FK_ShiftId WHERE s.shiftID = @shiftID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@shiftID", shiftId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            (
                                Convert.ToInt32(reader["employeeID"]),
                                reader["firstName"].ToString(),
                                reader["lastName"].ToString(),
                                new Department((int)reader["department"], reader["departmentName"].ToString())
                            );

                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        public List<ShiftType> EmployeesShiftonDay(int employeeId, DateTime date)
        {
            List<ShiftType> shifts = new List<ShiftType>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT s.shiftType FROM Shift s INNER JOIN ShiftConnection c ON s.shiftID = c.FK_ShiftId WHERE c.FK_employeeId = @id AND s.ShiftDate = @date";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", employeeId);
                    command.Parameters.AddWithValue("date", date);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shifts.Add((ShiftType)Enum.Parse(typeof(ShiftType), reader["ShiftType"].ToString()));
                        }
                    }
                }
            }
            return shifts;
        }

        public List<Shift> GetEmployeeOnShift(Employee employee)
        {
            List<Shift> shifts = new List<Shift>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select * FROM Shift as s INNER JOIN ShiftConnection as sC ON s.ShiftId = sC.FK_ShiftId WHERE sC.FK_EmployeeId = @employeeId;";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@employeeId", employee.employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shift shift = new Shift();
                            shift.ShiftDate = reader.GetDateTime(reader.GetOrdinal("shiftDate"));
                            string shiftTypeValue = Convert.ToString(reader["shiftType"]);
                            if (Enum.TryParse<ShiftType>(shiftTypeValue, out ShiftType shiftType))
                            {
                                shift.ShiftType = shiftType;
                            }
                            shifts.Add(shift);
                        }
                    }
                }
            }
            return shifts;
        }


        public void RemoveEmployeeFromShift(int employee, int ShiftID)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query2 = "DELETE FROM ShiftConnection WHERE FK_EmployeeID = @id AND FK_ShiftId = @shift";
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("@id", employee);
                    command.Parameters.AddWithValue("@shift", ShiftID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteWorkShift(Shift shift)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query2 = @"DELETE FROM Shift WHERE shiftID = @id;" +
                                "DELETE FROM ShiftConnection WHERE shiftID = @id";
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("@id", shift.ShiftID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddEmployeeToShift(int shiftID, int employeeID)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query2 = "INSERT INTO ShiftConnection (FK_EmployeeId, FK_ShiftId) VALUES (@employeeId, @shiftID)";
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeID);
                    command.Parameters.AddWithValue("@shiftID", shiftID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckIfShiftExisted(Shift shift)
        {
            using (SqlConnection con = Connection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Shift WHERE ShiftDate = @date AND FK_DepartmentID = @dep AND shiftType = @shiftType";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@date", shift.ShiftDate);
                    cmd.Parameters.AddWithValue("@shiftType", shift.ShiftType.ToString());
                    cmd.Parameters.AddWithValue("@dep", GetDepartment(shift.Department).depId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public void UpdateNumberPeopleNeeded(Shift shift)
        {
            using (SqlConnection con = Connection.GetConnection())
            {
                string query = "UPDATE Shift SET peopleNeeded = @peopleNeeded WHERE ShiftID = @shiftID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@peopleNeeded", shift.NrPeopleNeeded);
                    command.Parameters.AddWithValue("@ShiftID", shift.ShiftID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAvailableEmployees(Shift shift)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = Connection.GetConnection())
            {
                string query = "SELECT DISTINCT e.employeeID, e.firstName, e.lastName, e.department, d.departmentName FROM Employee e LEFT JOIN ShiftConnection s ON s.FK_EmployeeId = e.employeeID LEFT JOIN Department d ON d.departmentID = e.department INNER JOIN Contract c ON c.FK_EmployeeID = e.employeeID WHERE (s.FK_ShiftId IS NULL OR s.FK_ShiftId <> @ShiftID) AND e.department = @dep AND c.Active = 1;"
                    /*"SELECT e.employeeID, e.firstName, e.lastName, e.department, d.departmentName FROM Employee e LEFT JOIN ShiftConnection s ON s.FK_EmployeeId = e.employeeID INNER JOIN Department d ON d.departmentID = e.department WHERE (s.FK_ShiftId IS NULL OR s.FK_ShiftId != @ShiftID) AND e.department = @dep AND e.employeeID NOT IN (SELECT FK_EmployeeId FROM ShiftConnection GROUP BY FK_EmployeeId HAVING COUNT(FK_ShiftId) > 1);"*/
                    /*"SELECT e.employeeID, e.firstName, e.lastName, e.department, d.departmentName FROM Employee e LEFT JOIN ShiftConnection s ON s.FK_EmployeeId = e.employeeID INNER JOIN Department d ON d.departmentID = e.department WHERE (s.FK_ShiftId IS NULL OR s.FK_ShiftId != @ShiftID) AND e.department = @dep AND (e.employeeID NOT IN (SELECT FK_EmployeeId FROM ShiftConnection WHERE FK_ShiftId = @ShiftID GROUP BY FK_EmployeeId HAVING COUNT(FK_ShiftId) > 1) OR @ShiftID IS NULL);"*/;
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ShiftID", shift.ShiftID);
                    command.Parameters.AddWithValue("@dep", GetDepartment(shift.Department).depId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int employeeId = reader.GetInt32(reader.GetOrdinal("employeeID"));
                            string firstName = reader.GetString(reader.GetOrdinal("firstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("lastName"));
                            int depID = reader.GetInt32(reader.GetOrdinal("department"));
                            string depName = reader.GetString(reader.GetOrdinal("departmentName"));
                            Department department = new Department(depID, depName);

                            Employee employee = new Employee(employeeId, firstName, lastName, department);
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
    }
}
