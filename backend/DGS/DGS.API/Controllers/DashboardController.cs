using DGS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            this.dashboardRepository = dashboardRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Chart")]
        public async Task<IActionResult> GetChart()
        {
            try
            {
                return Ok(await dashboardRepository.GetChart());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Total")]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                return Ok(await dashboardRepository.GetDashboardTotal());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
