using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

// Build config
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

var connectionString = builder.Build()
    .GetConnectionString("DefaultConnection");


// Create MySQL connection
using var connection = new MySqlConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Connected to MySQL successfully.");

    // Uncomment what you want to test

    ExecuteReader(connection);
    // ExecuteScalar(connection);
    // ExecuteNonQuery(connection);
    // SqlInjectionDemo(connection);
    // ParameterizedQueryDemo(connection);

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    connection.Close();
}


// ------------------ METHODS ------------------ //

void ExecuteReader(MySqlConnection connection)
{
    var query = "SELECT * FROM Customers WHERE Age > 25";

    using var command = new MySqlCommand(query, connection);
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine(
            $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
}


void ExecuteScalar(MySqlConnection connection)
{
    var query = "SELECT COUNT(*) FROM Customers";

    using var command = new MySqlCommand(query, connection);

    var count = Convert.ToInt32(command.ExecuteScalar());

    Console.WriteLine($"Total customers: {count}");
}


void ExecuteNonQuery(MySqlConnection connection)
{
    var query =
        "INSERT INTO Customers (Name, Age) VALUES ('Danny', 30)";

    using var command = new MySqlCommand(query, connection);

    var rows = command.ExecuteNonQuery();

    Console.WriteLine($"Rows inserted: {rows}");
}


void SqlInjectionDemo(MySqlConnection connection)
{
    var userInput = "1 OR 1=1";

    var query =
        $"SELECT * FROM Customers WHERE Id = {userInput}";

    using var command = new MySqlCommand(query, connection);

    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine(
            $"Id: {reader["Id"]}, Name: {reader["Name"]}");
    }
}


void ParameterizedQueryDemo(MySqlConnection connection)
{
    var query =
        "SELECT * FROM Customers WHERE Name LIKE @name";

    using var command = new MySqlCommand(query, connection);

    var name = "%John%";

    command.Parameters.AddWithValue("@name", name);

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine(
            $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
    else
    {
        Console.WriteLine("No record found.");
    }
}
