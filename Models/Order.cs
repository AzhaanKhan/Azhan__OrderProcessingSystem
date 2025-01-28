using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public void CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (var product in Products)
            {
                TotalPrice += product.Price;
            }
        }
    }
}
