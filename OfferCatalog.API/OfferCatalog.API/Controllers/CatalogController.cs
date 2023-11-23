using Microsoft.AspNetCore.Mvc;
using OfferCatalog.API.Models;
using OfferCatalog.API.Services;
using System.Net;

namespace OfferCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {

        private readonly ICatalogService _catalogService;

        public CatalogController( ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Item>>> GetAllCatalogItems()
        {
            var res = await _catalogService.GetAllItems();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Item),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> GetCatalogItemById([FromRoute] int id)
        {
            var res = await _catalogService.GetItemById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCatalogItem(ItemNew item)
        {
            if (item == null)
            {
                return BadRequest(new {message ="New Item cannot be null"});
            }
            _catalogService.AddItem(item);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalogItem([FromBody]Item item)
        {
            if(item.ItemId == 0 || item is null)
            {
                return BadRequest();
            }
            _catalogService.UpdateItem(item);
            return Ok(item);
        }



        
    }
}
