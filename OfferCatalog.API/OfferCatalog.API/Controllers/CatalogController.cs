using Microsoft.AspNetCore.Mvc;
using OfferCatalog.API.Models;
using OfferCatalog.API.Services;
using System.Net;

namespace OfferCatalog.API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CatalogController : Controller
    {

        private readonly IBenefitService _beneficiaryService;

        public CatalogController(IBenefitService beneficiaryService)
        {
               _beneficiaryService = beneficiaryService;
        }
        [HttpGet]
        [Route("offers")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Item>>> GetAllOffers()
        {
            var res = await _beneficiaryService.GetBenefitList();
            return Ok(res);
        }

        [HttpPost]
        [Route("offers")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public ActionResult<string> AddBenefit(Benefit item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _beneficiaryService.AddBenefit(item);
            return Ok("Added");
        }
    }
}
