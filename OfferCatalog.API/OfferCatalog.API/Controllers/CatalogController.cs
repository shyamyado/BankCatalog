using Microsoft.AspNetCore.Mvc;
using OfferCatalog.API.Models;
using OfferCatalog.API.Services;
using OfferCatalog.API.ViewModels;
using System.Net;

namespace OfferCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {

        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ItemViewModel>>> GetAllCatalogItems([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var res = await _catalogService.GetAllItems(page, pageSize);
            if(res == null)
            {
                return NotFound("No item found.");
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ItemViewModel>> GetCatalogItemById([FromRoute] int id)
        {
            var res = await _catalogService.GetItemById(id);
            if (res == null)
            {
                return NotFound("Item not Found");
            }
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ItemViewModel>> AddCatalogItem(ItemCreate item)
        {
            if (item == null)
            {
                return BadRequest(new { message = "New Item cannot be null" });
            }
            var (newItem, error) = await _catalogService.AddItem(item);
            if (error != null)
            {
                return BadRequest(error);
            }
            return CreatedAtAction(nameof(GetCatalogItemById), new { id = newItem.Id }, newItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalogItem([FromBody] ItemUpdate item)
        {
            if (item == null)
            {
                return BadRequest(new { messgage = "Item cannot be null"});
            }
            var res = await _catalogService.UpdateItem(item);
            if (res == null)
            {
                return NotFound("Item not found");
            }
            return Ok(item);
        }




    }
}
