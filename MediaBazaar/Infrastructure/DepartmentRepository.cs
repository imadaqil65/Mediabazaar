using Domain;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Infrastructure
{
    public class DepartmentRepository : IDepartment
    {
        string query;

        private static Department MapToDepartment(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string description;
            if (!reader.IsDBNull(2))
            { description = reader.GetString(2); }
            else
            { description = null; }

            return new Department(id, name, description);
        }

        public void CreateDepartment(Department dep)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "INSERT INTO Department (departmentName, departmentDesc, active) VALUES (@name, @desc, 1)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", dep.Name);
                    command.Parameters.AddWithValue("@desc", dep.Description ?? string.Empty);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDepartment(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "UPDATE Department SET active = 0 WHERE departmentID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Department GetDepartment(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT * FROM Department WHERE departmentId = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToDepartment(reader);
                        }
                        return null;
                    }
                }
            }
        }

        public Department GetDepartment(string Name)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT * FROM Department WHERE departmentName = @Name";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("Name", Name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToDepartment(reader);
                        }
                        return null;
                    }
                }
            }
        }

        public List<string> GetDepartmentNames()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT DISTINCT departmentName FROM Department WHERE active = 1";
                List<string> list = new List<string>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["departmentName"].ToString());
                        }
                        return list;
                    }
                }
            }
        }

        public void UpdateDepartment(Department dep)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "UPDATE Department SET departmentName = @Name, departmentDesc = @desc WHERE departmentID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", dep.depId);
                    command.Parameters.AddWithValue("Name", dep.Name);
                    command.Parameters.AddWithValue("desc", dep.Description ?? null);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Department> ViewActiveDepartment()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT * FROM Department WHERE active = 1";
                List<Department> list = new List<Department>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToDepartment(reader));
                        }
                        return list;
                    }
                }
            }
        }

        public List<Department> ViewAllDepartment()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT * FROM Department";
                List<Department> list = new List<Department>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToDepartment(reader));
                        }
                        return list;
                    }
                }
            }
        }
    }
}
