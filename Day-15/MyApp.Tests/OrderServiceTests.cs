using Xunit;
using MyApp;

namespace MyApp.Tests;

public class MockOrderRepository : IOrderRepository
{
    public void Save(Order order) { }
}

public class MockEmailSender : IEmailSender
{
    public void Send(string email, string message) { }
}

public class OrderServiceTests
{
    [Fact]
    public void PlaceOrder_Returns10()
    {
        var repo = new MockOrderRepository();
        var email = new MockEmailSender();
        var service = new OrderService(repo, email);

        var result = service.PlaceOrder(new Order
        {
            Email = "test@gmail.com"
        });

        Assert.Equal(10, result);
    }
}