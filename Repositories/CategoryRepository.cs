using Microsoft.EntityFrameworkCore;
using ReactInventorySystem.Data;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Category category)
        {
            context.Set<Category>().Add(category);
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = context.Set<Category>().Find(id);
            context.Set<Category>().Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories() => context.Set<Category>().ToList();


        public Category GetCategory(int? id)
        {
            var entity = context.Set<Category>().Find(id);
            return entity;
        }

        public IEnumerable<Product> GetCategoryProducts(int? id) =>context.Set<Product>().Where(x => x.CategoryId == id).ToList();


        public void Update(int? id, Category category)
        {
            context.Entry<Category>(context.Categories.FirstOrDefault(x => x.Id == id)).CurrentValues.SetValues(category);
            context.SaveChanges();
        }
    }
}
