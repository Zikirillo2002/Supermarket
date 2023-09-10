using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDBService
{
    internal static class DAL
    {
        public const string Connection_string =
            "Data Source=HP-PAVILION-550;Initial Catalog=Supermarket;Integrated Security=True";

        public static void ExecuteNonQuery(string command)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of rows affected: {affectedRows}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
        }
    }
}
