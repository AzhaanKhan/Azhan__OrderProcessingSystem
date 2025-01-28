using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Serilog; // Added for logging
using OrderProcessingSystem.Models; // Add this line

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            return _context.Customers.ToList();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error retrieving customers");
            return StatusCode(500, "Internal server error");
        }
    }

    // Remove the duplicate GetCustomers method

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }
}
