using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using totvs_test.Dtos;
using totvs_test.Services;

namespace totvs_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuctionController : ControllerBase
    {
        IAuctionService _auctionService;
        IUserService _userService;

        public AuctionController(IAuctionService auctionService, IUserService userService)
        {
            _auctionService = auctionService;
            _userService = userService;
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
                var responsible = await _userService.FindById(auctionDto.ResponsibleId.GetValueOrDefault());

                if (responsible == null)
                {
                    return NotFound("Responsible does not exists");
                }


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
                var responsible = await _userService.FindById(auctionDto.ResponsibleId.GetValueOrDefault());

                if (responsible == null)
                {
                    return NotFound("Responsible does not exists");
                }

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