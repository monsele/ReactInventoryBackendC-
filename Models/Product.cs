using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
