using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using var context = new CrmContext();

            Console.WriteLine("Connected Successfully ✅");

            var customers = context.Customers
                .Where(c => c.Age > 20)
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"Id: {customer.Id}, Name: {customer.Name}, Age: {customer.Age}"
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ✅ Only database name changed (NEW DATABASE)
        string connectionString =
            "server=localhost;port=3306;database=crm_efcore_db;user=root;password=7719863765";

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
