using System;
using System.Data.SqlClient;

namespace SupermarketDBService
{
    internal class ProductDBService
    {
        public void CreateProduct(string name, decimal price, int category_id)
        {
            string command = $"INSERT INTO dbo.Product " +
                             $"(Product_Name, Price, category_id)" +
                             $" VALUES ('{name}', {price}, {category_id})";

            DAL.ExecuteNonQuery(command);

            Console.WriteLine("Data created successfully.");
        }

        public void ReadAllProducts()
        {
            string command = "SELECT * FROM dbo.Product";

            try
            {
                using(SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {   
                    connection.Open();   
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
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

        public void UpdateProduct(int id, string newName, decimal newPrice, int newcCategory_id)
        {
            string command = $" UPDATE dbo.Product " +
                    $" SET Product_Name = '{newName} ', " +
                    $" Price = {newPrice}, Category_Id = {newcCategory_id} " +
                    $" WHERE Id = {id} ;";

            DAL.ExecuteNonQuery(command);
        }

        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product" +
                    $" WHERE Id = {id}";

            DAL.ExecuteNonQuery(command);
        }

        public void GetProductById(int id)
        {
            string command = "SELECT * FROM Product  " +
                    $"WHERE Id = {id};";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
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

        public void GetProductByName(string name)
        {
            string command = " SELECT * FROM Product  " +
                    $" WHERE Product_Name = '{name}' ;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
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

        public void GetProductByPrice(decimal price, char character)
        {
            string command = "SELECT * FROM Product  " +
                    $" WHERE Price {character} {price};";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
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

        public void GetProductByCategory_Id(int id)
        {
            string command = "SELECT * FROM Product  " +
                             $"WHERE Category_Id = {id};";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
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

        private static void ReadProductsFromDataReader(SqlDataReader reader)
        {
            if (reader is null)
            {
                return;
            }

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3));

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object price = reader.GetValue(2);
                    object category_Id = reader.GetValue(3);

                    Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, price, category_Id);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("The table is empty.....");
            }
        }
    }
}
