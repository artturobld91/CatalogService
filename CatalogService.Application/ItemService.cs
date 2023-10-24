using CatalogService.Domain.Models;
using CatalogService.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application
{
    public class ItemService : IItemService
    {
        private ApplicationDbContext _context;

        public ItemService()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItem(int id)
        {
            return _context.Items.First(item => item.Id == id);
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Item itemToDelete = _context.Items.FirstOrDefault(item => item.Id == id);
            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
