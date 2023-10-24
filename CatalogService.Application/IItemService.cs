using CatalogService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application
{
    public interface IItemService
    {
        public IEnumerable<Item> GetItems();

        public Item GetItem(int id);

        public void AddItem(Item item);

        public void DeleteItem(int id);

        public void UpdateItem(Item item);
    }
}
