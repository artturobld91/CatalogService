using CatalogService.Domain.Models;
using CatalogService.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _context;

        public CategoryService()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.First(category => category.Id == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category categoryToDelete = _context.Categories.FirstOrDefault(category => category.Id == id);
            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
