using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.WebApi.Auth.Interface;
using PublishingHouse.WebApi.Dto.AuthDto;

namespace PublishingHouse.WebApi.Controller
{
    [ApiController]
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController(ILoginService loginService, ICustomerRegisterService registerService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        private readonly ICustomerRegisterService _registerService = registerService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            try
            {
                var responseObj = await _loginService.LoginAsync(requestDto);
                return Ok(responseObj);
            }
            catch (AccessException e)
            {
                return Unauthorized(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerRequestDto requestDto)
        {
            try
            {
                var responseObj = await _registerService.RegisterAsync(requestDto);
                return Ok(responseObj);
            }
            catch (AccessException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }
    }
}
