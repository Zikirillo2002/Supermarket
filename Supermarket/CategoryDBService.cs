using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDBService
{
    internal class CategoryDBService
    {
        public void CreateCategory(string name)
        {
            string command = $"INSERT INTO dbo.Category (Category_Name)" +
                                 $" VALUES ('{name}');";

            DAL.ExecuteNonQuery(command);
        }

        public void ReadAllCategory()
        {
            string command = "SELECT * FROM dbo.Category";

            try
            {
                using(SqlConnection connection =  new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using(SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategoryFromDataReader(reader); 
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }

        public void UpdateCategory(int id, string newName)
        {
            string command = $"UPDATE dbo.Category" +
                    $" SET Category_Name = '{newName}'" +
                    $" WHERE Id = {id};";

            DAL.ExecuteNonQuery(command);
        }

        public void DeleteCategory(int id)
        {
            string command = $"DELETE dbo.Category WHERE Id = {id}";

            DAL.ExecuteNonQuery(command);
        }

        public void GetCategoryById(int id)
        {
            string command = "SELECT * FROM Category  " +
                    $"WHERE Id = {id};";

            try
            {
                using(SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command,connection);

                    using(SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategoryFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }

        public void GetCategoryByName(string name)
        {
            string command = "SELECT * FROM Category  " +
                    $" WHERE Category_Name = '{name}' ;";
            try
            {
                using(SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand( command,connection);

                    using( SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategoryFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }

        public void GetByCountProducts(int count)
        {
            string command = "SELECT c.Category_Name, COUNT(p.Id) AS 'Number of products' " +
                    " FROM Product p " +
                    " INNER JOIN Category c ON p.Category_Id = c.Id " +
                    " GROUP BY c.Category_Name " +
                    $" HAVING COUNT(p.Id) > {count} ;";

            try
            {
                using( SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command,connection);

                    using(SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategoryFromDataReader((SqlDataReader)reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }

        private static void ReadCategoryFromDataReader(SqlDataReader reader)
        {
            if(reader is null)
            {
                return;
            }

            if(reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}",
                    reader.GetName(0),
                    reader.GetName(1));

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object category_Name = reader.GetValue(1);

                    Console.WriteLine("{0} \t{1} ", id, category_Name);
                }
                reader.Close();
            }
        }
    }
}
