using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Serilog; // Added for logging
using Microsoft.EntityFrameworkCore; // Added for Include method
using OrderProcessingSystem.Models; // Add this line


[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder([FromBody] Order order)
    {
        try
        {
            if (order == null || order.Products == null || !order.Products.Any())
            {
                return BadRequest("Order must have products.");
            }

            // Check if the customer has any unfulfilled orders
            var unfulfilledOrders = _context.Orders
                .Where(o => o.Customer.Id == order.Customer.Id && o.Products.Count > 0)
                .ToList();

            if (unfulfilledOrders.Any())
            {
                return BadRequest("Cannot place a new order while there are unfulfilled orders.");
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error creating order");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return _context.Orders.Include(o => o.Products).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        return order;
    }
}
