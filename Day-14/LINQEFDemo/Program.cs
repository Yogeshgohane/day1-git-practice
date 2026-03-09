using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var _context = new CrmContext();
var customers = _context.Customers.ToList();

public class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CrmDb;Trusted_Connection=True;");
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}