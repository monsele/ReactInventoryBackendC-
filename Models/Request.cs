using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Models
{
    public class Request
    {
        public int id { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public int AmountRequested { get; set; }
        public bool isAccept { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
