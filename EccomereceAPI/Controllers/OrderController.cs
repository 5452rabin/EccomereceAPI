using Eccommerec_BLL.DTO.Order;
using Eccommerec_BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EccomereceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) {
        
            _orderService = orderService;
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> CreateOrder(AddOrderDTO addOrderDTO)
        {
            try
            {
                return Ok(await _orderService.AddOrder(addOrderDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      

    }
}
