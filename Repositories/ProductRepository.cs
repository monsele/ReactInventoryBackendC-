using ReactInventorySystem.Data;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateProduct(Product product)
        {
            context.Set<Product>().Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int? id)
        {
            var entity = context.Set<Product>().Find(id);
            context.Set<Product>().Remove(entity);
            context.SaveChanges();
        }

        public Product GetProduct(int? id) => context.Set<Product>().FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetProducts() => context.Set<Product>().ToList();

        public ICollection<Product> GetProductsByCategory(int id)=>context.Set<Product>().Where(x => x.CategoryId == id).ToList();

        public void Update(int? id, Product product)
        {
            context.Entry<Product>(context.Products.FirstOrDefault(x => x.Id == id)).CurrentValues.SetValues(product);
            context.SaveChanges();
        }
    }
}
