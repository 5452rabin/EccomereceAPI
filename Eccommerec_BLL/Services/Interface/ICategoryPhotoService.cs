using Eccommerec_BLL.DTO.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface ICategoryPhotoService
    {
        void AddCategoryPhoto(Category_PhotoDTO categoryPhotoDTO);
        Category_PhotoDTO GetCategoryPhotoById(int id);
        List<Category_PhotoDTO> GetAllCategoryPhotosByCategoryId(int id);
        void DeleteCategoryPhoto(Category_PhotoDTO category_PhotoDTO);
        void DeleteCategoryPhotoList(int Categoryid);
    }
}
