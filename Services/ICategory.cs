using ReactInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Services
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int? id);
        void  Create(Category category);
        void Delete(int? id);
        void Update(int? id, Category category);
        IEnumerable<Product> GetCategoryProducts(int? id);
    }
}
