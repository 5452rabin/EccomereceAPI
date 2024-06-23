using Eccommerec_BLL.DTO.Category;
using Eccommerec_BLL.DTO.Photo;
using Eccommerec_BLL.DTO.Product;
using Eccommerec_BLL.Services.Implementation;
using Eccommerec_BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EccomereceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductPhotoService _productPhotoService;
        public ProductController(IProductService productService, IProductPhotoService productPhotoService)
        {
            _productService = productService;
            _productPhotoService = productPhotoService;
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO productDTO)
        {
            try
            {
                return Ok(_productService.AddProduct(productDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("AddProductPhoto")]
        public async Task<IActionResult> AddProductPhoto([FromBody]Product_PhotoDTO product_PhotoDTO)
        {
            try
            {
                product_PhotoDTO=await _productPhotoService.AddProductPhoto(product_PhotoDTO);
                return Ok(product_PhotoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("GetProductsByCategory")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            return Ok(_productService.GetProductsByCategoryId(categoryId));
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(_productService.GetProducts());
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return Ok(_productService.GetProductById(productId));
        }


    }
}
