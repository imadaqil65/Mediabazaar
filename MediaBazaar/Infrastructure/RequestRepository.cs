using Domain;
using Domain.Interfaces;
using Domain.Requests;
using Microsoft.Data.SqlClient;


namespace Infrastructure
{
    public class RequestRepository : IRequestDB
    {
        string query;
        public void CreateRequest(Request request)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                switch (request)
                {
                    case RestockRequest:
                        query = "INSERT INTO Request(FK_EmployeeID, RequestType, Message, FK_ProductID, RestockNumber) VALUES (@EmployeeID, 1, @Msg, @productID, @Number)";
                        break;
                    case ShiftRequest:
                        query = "INSERT INTO Request(FK_EmployeeID, RequestType, Message, ShiftDate, ShiftType) VALUES (@EmployeeID, 2, @Msg, @Date, @Type)";
                        break;
                }

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmployeeID", request.EmployeeId);
                    command.Parameters.AddWithValue("@Msg", request.Message ?? null);
                    if (request is RestockRequest restock)
                    {
                        command.Parameters.AddWithValue("@ProductID", restock.ProductId);
                        command.Parameters.AddWithValue("@Number", restock.RestockNumber);
                    }
                    else if (request is ShiftRequest shift)
                    {
                        command.Parameters.AddWithValue("@Date", shift.date);
                        command.Parameters.AddWithValue("@Type", shift.shiftType.ToString());

                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRequest(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "DELETE FROM Request WHERE RequestID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Request> GetRequestByEmployeeId(int id)
        {
            List<Request> requests = new List<Request>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Request WHERE FK_EmployeeID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch ((int)reader["RequestType"])
                            {
                                case 1:
                                    requests.Add(MapToRestock(reader));
                                    break;
                                case 2:
                                    requests.Add(MapToShift(reader));
                                    break;
                            }
                        }
                    }
                }
            }
            return requests;
        }

        public Request GetRequestById(int id)
        {
            Request request = null;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Request WHERE RequestID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            switch ((int)reader["RequestType"])
                            {
                                case 1:
                                    request = MapToRestock(reader);
                                    break;
                                case 2:
                                    request = MapToShift(reader);
                                    break;
                            }
                        }
                    }
                }
            }
            return request;
        }

        public List<RestockRequest> GetRestockRequest()
        {
            List<RestockRequest> requests = new List<RestockRequest>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Request WHERE RequestType = 1";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requests.Add(MapToRestock(reader));

                        }
                    }
                }
            }
            return requests;
        }

        public List<ShiftRequest> GetShiftRequest()
        {
            List<ShiftRequest> requests = new List<ShiftRequest>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "SELECT * FROM Request WHERE RequestType = 2";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requests.Add(MapToShift(reader));
                        }
                    }
                }
            }
            return requests;
        }

        private RestockRequest MapToRestock(SqlDataReader reader)
        {
            return new RestockRequest
            (
                (int)reader["RequestID"],
                (int)reader["FK_EmployeeID"],
                reader["Message"].ToString(),
                (int)reader["FK_ProductID"],
                (int)reader["RestockNumber"]
            );
        }

        private ShiftRequest MapToShift(SqlDataReader reader)
        {
            return new ShiftRequest
            (
                (int)reader["RequestID"],
                (int)reader["FK_EmployeeID"],
                reader["Message"].ToString(),
                (DateTime)reader["ShiftDate"],
                (ShiftType)Enum.Parse(typeof(ShiftType), reader["ShiftType"].ToString())
            );
        }

    }
}
