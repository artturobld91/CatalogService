using CatalogService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();

        public Category GetCategory(int id);

        public void AddCategory(Category category);

        public void DeleteCategory(int id);

        public void UpdateCategory(Category category);
    }
}
