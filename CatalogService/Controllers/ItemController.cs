using CatalogService.Application;
using CatalogService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private IItemService _itemService;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
            _itemService = new ItemService();
        }

        [HttpGet("GetItems")]
        public IEnumerable<Item> GetItems()
        {
            return _itemService.GetItems();
        }

        [HttpGet("GetItem/{id}")]
        public Item GetItem([FromQuery] int id)
        {
            return _itemService.GetItem(id);
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem([FromBody] Item item)
        {
            _itemService.AddItem(item);
            return Ok();
        }

        [HttpPost("RemoveItem")]
        public IActionResult RemoveItem([FromQuery] int id)
        {
            _itemService.DeleteItem(id);
            return NoContent();
        }

        [HttpPost("UpdateItem")]
        public IActionResult UpdateItem([FromBody] Item item)
        {
            _itemService.UpdateItem(item);
            return NoContent();
        }
    }
}
