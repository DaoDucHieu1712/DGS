using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.Enums;
using DGS.Repository;
using DGS.Repository.Impls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await orderRepository.GetAll());
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

        [HttpGet("MyOrder/{email}")]
        public async Task<IActionResult> FindByUser(string email, [FromQuery] OrderFilterDTO request)
        {
            try
            {
                return Ok(await orderRepository.FindOrdersByEmail(email, request));
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

        [HttpPost]
        public async Task<IActionResult> Add(OrderCreateUpdateDTO request)
        {
            try
            {
                await orderRepository.Add(request);
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

        [HttpPost("CreateAndGet")]
        public async Task<IActionResult> CreateAndGet(OrderCreateUpdateDTO request)
        {
            try
            {
                return Ok(await orderRepository.CreateAndGet(request));
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
        {
            try
            {
                await orderRepository.UpdateStatus(id, status);
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

        [HttpPost("OrderDetail")]
        public async Task<IActionResult> SaveOrderDetail(List<OrderDetailCreateUpdateDTO> request)
        {
            try
            {
                await orderDetailRepository.AddRange(request);
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

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] OrderFilterDTO request)
        {
            try
            {
                return Ok(await orderRepository.Filter(request));
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
        
        public async Task<IActionResult> GetOrderDetail()
        {
            try
            {
                return Ok(await orderRepository.Filter(request));
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
