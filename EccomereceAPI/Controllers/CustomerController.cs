using Eccommerec_BLL.DTO.User;
using Eccommerec_BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EccomereceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        { 
        _customerService = customerService;
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody]AddCustomerDTO addCustomerDTO)
        {
            try
            {
                return Ok(await _customerService.AddCustomer(addCustomerDTO));
            }catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _customerService.GetAll());
        }
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await (_customerService.GetCustomerById(id)));
        }
        [HttpDelete]
        [Route("DeleteCustomerById")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
           try
            {
                _customerService.DeleteCustomerById(id);
                return Ok("Deleted:");
            }
            catch (Exception ex)
            {
                return Ok(ex);
                
            }
        }
    }
}
