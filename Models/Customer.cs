using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize to empty string
        public string Email { get; set; } = string.Empty; // Initialize to empty string
        public ICollection<Order> Orders { get; set; } = new List<Order>(); // Initialize to an empty list
    }
}
