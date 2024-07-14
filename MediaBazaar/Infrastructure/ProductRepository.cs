using Domain;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infrastructure
{
    public class ProductRepository:IProduct
    {
        string query = string.Empty;
        public void CreateProduct(Product product)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "INSERT INTO Product ([name],[brand],[price],[description],[category],[height],[width],[length],[weight],[shown],[stock])VALUES(@name,@brand,@price,@desc,@category,@height,@width,@length,@weight,@shown,@stock)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", product.name);
                    command.Parameters.AddWithValue("@brand", product.brand);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@desc", product.description);
                    command.Parameters.AddWithValue("@category", product.category);
                    command.Parameters.AddWithValue("@height", product.height);
                    command.Parameters.AddWithValue("@width", product.width);
                    command.Parameters.AddWithValue("@length", product.length);
                    command.Parameters.AddWithValue("@weight", product.weight);
                    command.Parameters.AddWithValue("@shown", product.shown);
                    command.Parameters.AddWithValue("@stock", product.stock);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        private static Product GetProductInfos(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string brand = reader.GetString(2);
            decimal price = reader.GetDecimal(3);
            string description = reader.GetString(4);
            string category = reader.GetString(5);
            int height = reader.GetInt32(6);
            int width = reader.GetInt32(7);
            int length = reader.GetInt32(8);
            int weight = reader.GetInt32(9);
            bool shown = reader.GetBoolean(10);
            int stock = reader.GetInt32(11);

            return new Product(id, name, brand, price, description, category, height, width, length, weight, stock, shown); 
        }

        public void DeleteProduct(int id)
        {
            query = "UPDATE SET Product shown = 0 WHERE productId = @id";
            using (SqlConnection conn = Connection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Product GetProduct(int id)
        {
            query = "SELECT * FROM Product WHERE productId = @id";
            using (SqlConnection conn = Connection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetProductInfos(reader);
                    }
                    return null;
                } ;
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "UPDATE [dbo].[Product] SET [name] = @name ,[brand] = @brand ,[price] = @price ,[description] = @desc ,[category] = @category ,[height] = @height ,[width] = @width ,[length] = @length ,[weight] = @weight ,[shown] = @shown ,[stock] = @stock WHERE productId=@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", product.productId);
                    command.Parameters.AddWithValue("@name", product.name);
                    command.Parameters.AddWithValue("@brand", product.brand);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@desc", product.description);
                    command.Parameters.AddWithValue("@category", product.category);
                    command.Parameters.AddWithValue("@height", product.height);
                    command.Parameters.AddWithValue("@width", product.width);
                    command.Parameters.AddWithValue("@length", product.length);
                    command.Parameters.AddWithValue("@weight", product.weight);
                    command.Parameters.AddWithValue("@shown", product.shown);
                    command.Parameters.AddWithValue("@stock", product.stock);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> ViewActiveProduct()
        {
            query = "SELECT * FROM Product WHERE shown=1";
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<Product> products = new List<Product>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(GetProductInfos(reader));
                    }
                    return products;
                };
            }
        }

        public List<Product> ViewAllProduct()
        {
            query = "SELECT * FROM Product";
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<Product> products = new List<Product>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(GetProductInfos(reader));
                    }
                    return products;
                };
            }
        }

        public List<string> GetCategories()
        {
            query = "SELECT DISTINCT category FROM Product";
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<string> categories = new List<string>();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       categories.Add(reader.GetString(0));
                    }
                    return categories;
                };
            }
        }
    }
}
