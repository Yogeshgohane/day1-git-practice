namespace MyApp;

public class Order
{
    public string Email { get; set; } = "";
}

public interface IOrderRepository
{
    void Save(Order order);
}

public interface IEmailSender
{
    void Send(string email, string message);
}

public class OrderService
{
    private readonly IOrderRepository _repo;
    private readonly IEmailSender _email;

    public OrderService(IOrderRepository repo, IEmailSender email)
    {
        _repo = repo;
        _email = email;
    }

    public int PlaceOrder(Order order)
    {
        _repo.Save(order);
        _email.Send(order.Email, "Order Placed");

        return 10;
    }
}