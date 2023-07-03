using DGS.API.Services;
using DGS.BusinessObjects.DTOs.Auth;
using DGS.Repository.Impls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService services;

        public AuthController(AuthService services)
        {
            this.services = services;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            try
            {
              var result = await services.SignUp(request);
                if(result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                return Unauthorized();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SignInDTO request)
        {
            try
            {
                return Ok(await services.SignIn(request));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ReNewToken")]
        public async Task<IActionResult> ReNewToken()
        {
            try
            {
                return Ok();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
