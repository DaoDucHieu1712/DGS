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
                var _user = services.GetUserByEmail(request.Email);
                if (_user != null) return StatusCode(500,"Email is Exist !!!!");
                await services.SignUp(request);
                return NoContent();
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
                var rs = await services.SignIn(request);
                if (rs == null) return StatusCode(500, "username or password wrong !!!");
                return Ok(rs);
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

        [HttpGet("FindByEmail")]
        public async Task<IActionResult> FindUserByEmail(string email)
        {
            try
            {
                var user = await services.GetUserByEmail(email);
                return Ok(user);
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
