using ReactInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int? id);
        void CreateProduct(Product product);
        void DeleteProduct(int? id);
        void Update(int? id, Product product);
        ICollection<Product> GetProductsByCategory(int id);
    }
}
