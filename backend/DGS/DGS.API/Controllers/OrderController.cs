using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.Enums;
using DGS.Repository;
using DGS.Repository.Impls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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

        [Authorize(Roles = "Admin")]
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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                return Ok(await orderRepository.FindById(id));
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

        [Authorize]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize]
        [HttpGet("OrderDetail/{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            try
            {
                return Ok(await orderDetailRepository.FindByOrder(id));
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

        [Authorize(Roles = "Admin")]
        [HttpGet("Export")]
        public async Task ExportExcel()
        {
            List<OrderDTO> orders = await orderRepository.GetAll();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells[1, 1].Value = "Order Id";
                worksheet.Cells[1, 2].Value = "Customer Name";
                worksheet.Cells[1, 3].Value = "CreateAt";
                worksheet.Cells[1, 4].Value = "Total Price";
                worksheet.Cells[1, 5].Value = "Ship Address";
                worksheet.Cells[1, 6].Value = "Status";

                for (int i = 0; i < orders.Count; i++)
                {

                    var status = "";
                    if (orders[i].Status == OrderStatus.Wait)
                    {
                        status = "Wait";
                    }
                    if (orders[i].Status == OrderStatus.Pending)
                    {
                        status = "Pending";
                    }
                    if (orders[i].Status == OrderStatus.Reject)
                    {
                        status = "Reject";
                    }
                    if (orders[i].Status == OrderStatus.Complete)
                    {
                        status = "Complete";

                    }

                    worksheet.Cells[i + 2, 1].Value = orders[i].Id;
                    worksheet.Cells[i + 2, 2].Value = orders[i].CustomerName;
                    worksheet.Cells[i + 2, 3].Value = orders[i].CreatedAt.ToString();
                    worksheet.Cells[i + 2, 4].Value = orders[i].TotalPrice;
                    worksheet.Cells[i + 2, 5].Value = orders[i].ShipAddress;
                    worksheet.Cells[i + 2, 6].Value = status;

                }


                // Set the content type and filename for the response
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Headers.Add("Content-Disposition", "attachment; filename=exported_data.xlsx");

                // Write the Excel file to the response stream asynchronously
                await Response.Body.WriteAsync(package.GetAsByteArray());

            }
        }
    }
}
