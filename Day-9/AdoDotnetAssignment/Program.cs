using System;
using System.Data;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        try
        {
            // Connection String
            string connStr =
            "server=localhost;database=customerdb;user=root;password=7719863765;";

            using var conn = new MySqlConnection(connStr);

            Console.WriteLine("Connected Successfully");
            // SQL Query
            string query = "SELECT * FROM Customer";

            // Create Adapter
            MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

            // Create DataSet
            DataSet ds = new DataSet();

            // Fill DataSet
            adapter.Fill(ds, "CustomerTable");

            // Read Data
            Console.WriteLine("\nCustomer List:\n");

            foreach (DataRow row in ds.Tables["CustomerTable"].Rows)
            {
                Console.WriteLine(
                    $"ID: {row["CustomerId"]} | Name: {row["CustomerName"]}"
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
