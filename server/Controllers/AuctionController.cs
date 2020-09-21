using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using totvs_test.Dtos;
using totvs_test.Services;

namespace totvs_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _auctionService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var auction = await _auctionService.GetById(id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrUpdateAuctionDto auctionDto)
        {
            if (ModelState.IsValid)
            {
                var auction = await _auctionService.Create(auctionDto);
                var location = Url.Action("GetById", "Auction", new { id = auction.Id });

                return Created(location, auction);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(Guid id, CreateOrUpdateAuctionDto auctionDto)
        {
            if (ModelState.IsValid)
            {
                var auction = await _auctionService.Update(id, auctionDto);

                if (auction == null)
                {
                    return NotFound();
                }

                return Ok(auction);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            var auction = await _auctionService.DeleteById(id);

            if (auction == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}