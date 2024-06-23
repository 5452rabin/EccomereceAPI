using Eccommerec_BLL.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> AddCategory(AddCategoryDTO addCategoryDTO);
        Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);
        void DeleteCategory(CategoryDTO categoryDTO);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
    }
}
