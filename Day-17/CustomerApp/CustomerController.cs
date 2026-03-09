using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer(CustomerDTO dto)
    {
        return Ok("Customer Created Successfully");
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCustomer(int id, CustomerDTO dto)
    {
        return Ok($"Customer {id} Updated");
    }

    [HttpPatch("{id:int}")]
    public IActionResult PatchCustomer(int id, CustomerDTO dto)
    {
        return Ok($"Customer {id} Patched");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCustomer(int id)
    {
        return Ok($"Customer {id} Deleted");
    }
}