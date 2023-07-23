using DGS.API.Services;
using DGS.BusinessObjects.DTOs.Auth;
using DGS.Repository.Impls;
using Microsoft.AspNetCore.Authorization;
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
                if (request.Password != request.ConfirmPassword) return StatusCode(500, "Confirm password don't match !!!");
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

        [Authorize]
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

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO request)
        {
            try
            {
                var isSuccess = await services.ChangePassword(request);
                return Ok(isSuccess);
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

        [Authorize(Roles ="Admin")]
        [HttpGet("User")]
        public async Task<IActionResult> GetAllUser()
        {

            try
            {
                return Ok(await services.GetUsers());
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

        [Authorize]
        [HttpPost("ProfilePost")]
        public async Task<IActionResult> Profile(UserDTO request)
        {
            try
            {
                await services.ProfileSave(request);
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
    }
}
