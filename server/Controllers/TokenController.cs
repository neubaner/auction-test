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
    public class TokenController : ControllerBase
    {
        ITokenService _tokenService;
        IUserService _userService;

        public TokenController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateToken(CreateTokenDto tokenDto)
        {
            var user = await _userService.FindUserByEmailAndPassword(tokenDto.Email, tokenDto.Password);

            if (user == null)
            {
                return NotFound();
            }

            var token = _tokenService.GenerateToken(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}