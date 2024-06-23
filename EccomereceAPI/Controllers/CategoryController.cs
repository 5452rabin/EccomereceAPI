using Eccommerec_BLL.DTO.Category;
using Eccommerec_BLL.DTO.Photo;
using Eccommerec_BLL.GenericRepository.Interface;
using Eccommerec_BLL.Services.Interface;
using Ecommerece_DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace EccomereceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryPhotoService _categoryPhotoService;
       
        public CategoryController(ICategoryService categoryService,ICategoryPhotoService categoryPhotoService)
        {
         
            _categoryService = categoryService;
            _categoryPhotoService = categoryPhotoService;

        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryDTO addCategoryDTO)
        {
            try
            {
                return Ok(_categoryService.AddCategory(addCategoryDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategory()
        {
            IEnumerable<CategoryDTO> categoryDTOs = await _categoryService.GetAllCategories();
            return Ok(categoryDTOs);
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategory(int id)
        {
            CategoryDTO categoryDTO=await _categoryService.GetById(id);
            return Ok(categoryDTO);
        }
        [HttpPost]
        [Route("AddCategoryPhotos")]
        public async Task<IActionResult> AddCategoryPhoto(Category_PhotoDTO category_PhotoDTO)
        {

            _categoryPhotoService.AddCategoryPhoto(category_PhotoDTO);
            return Ok("PhotoAdded");
        }
        [HttpGet]
        [Route("GetAllPhotosByCategoryId")]
        public async Task<IActionResult> GetPhotosByCategoryId(int CategoryId)
        {
            IEnumerable<Category_PhotoDTO> category_PhotoDTOs=_categoryPhotoService.GetAllCategoryPhotosByCategoryId(CategoryId);
            return Ok(category_PhotoDTOs);
        }
        //right now Deleteion must not be done.
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            CategoryDTO categoryDTO =await _categoryService.GetById(id);
            _categoryService.DeleteCategory(categoryDTO);
            return Ok("deleted");
        }
        [HttpDelete]
        [Route("DeleteCategoryPhoto")]
        public async Task<IActionResult> DeleteCategoryPhoto(int id)
        {
            Category_PhotoDTO category_PhotoDTO=_categoryPhotoService.GetCategoryPhotoById(id);
            _categoryPhotoService.DeleteCategoryPhoto(category_PhotoDTO);
            return Ok("Deleted");
        }

    }
}
