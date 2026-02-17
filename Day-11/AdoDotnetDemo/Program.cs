using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        // Load appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        var config = builder.Build();

        // Get connection string
        var connectionString = config.GetConnectionString("customerdb");

        using var connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("✅ Connection opened successfully.");

            // Call demo methods (Enable only one at a time if needed)

            ParameterizedQueryDemo(connection);

            // ExecuteReader(connection);
            // ExecuteScalar(connection);
            // ExecuteNonQuery(connection);
            // InsertCustomerDemo(connection);
            // SqlDataAdapeterDemo(connection);
            // SqlInjectionDemo(connection);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error: " + ex.Message);
        }
        finally
        {
            connection.Close();
            Console.WriteLine("🔒 Connection closed.");
        }
    }

    // --------------------------------------------
    // Parameterized Query (Safe Query)
    // --------------------------------------------
    static void ParameterizedQueryDemo(MySqlConnection connection)
    {
        using var command = new MySqlCommand(
            "SELECT * FROM Customers WHERE Name LIKE @Name",
            connection);

        var name = "%John%";

        command.Parameters.AddWithValue("@Name", name);

        using MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }
    }

    // --------------------------------------------
    // SQL Injection Demo (Unsafe)
    // --------------------------------------------
    static void SqlInjectionDemo(MySqlConnection connection)
    {
        var userInput = "1 or 1=1";

        var query = $"SELECT * FROM Customers WHERE Id = {userInput}";

        using var command = new MySqlCommand(query, connection);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }

    // --------------------------------------------
    // Insert Demo
    // --------------------------------------------
    static void InsertCustomerDemo(MySqlConnection connection)
    {
        var query = "INSERT INTO Customers (Name, Age) VALUES (@Name, @Age)";

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Name", "New Customer");
        command.Parameters.AddWithValue("@Age", 25);

        var rows = command.ExecuteNonQuery();

        Console.WriteLine($"Inserted Rows: {rows}");
    }

    // --------------------------------------------
    // Data Adapter Demo
    // --------------------------------------------
    static void SqlDataAdapeterDemo(MySqlConnection connection)
    {
        var query = "SELECT * FROM Customers";

        using var command = new MySqlCommand(query, connection);

        using var adapter = new MySqlDataAdapter(command);

        var table = new DataTable();

        adapter.Fill(table);

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}");
        }
    }

    // --------------------------------------------
    // Execute Scalar
    // --------------------------------------------
    static void ExecuteScalar(MySqlConnection connection)
    {
        var query = "SELECT COUNT(*) FROM Customers";

        using var command = new MySqlCommand(query, connection);

        var count = Convert.ToInt32(command.ExecuteScalar());

        Console.WriteLine($"Total Customers: {count}");
    }

    // --------------------------------------------
    // Execute Reader
    // --------------------------------------------
    static void ExecuteReader(MySqlConnection connection)
    {
        var query = "SELECT * FROM Customers WHERE Age > 25";

        using var command = new MySqlCommand(query, connection);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }

    // --------------------------------------------
    // Execute NonQuery
    // --------------------------------------------
    static void ExecuteNonQuery(MySqlConnection connection)
    {
        var query = "INSERT INTO Customers (Name, Age) VALUES ('Danny', 30)";

        using var command = new MySqlCommand(query, connection);

        var rows = command.ExecuteNonQuery();

        Console.WriteLine($"Rows affected: {rows}");
    }
}
