using Eccommerec_BLL.DTO.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface IProductPhotoService
    {
        IEnumerable<Product_PhotoDTO> GetProductPhotoByProductId(int productId);
        Task<Product_PhotoDTO> AddProductPhoto(Product_PhotoDTO productPhotoDTO);
        void DeleteProductPhoto(int productphotoId);
        
        Product_PhotoDTO GetProduct_PhotobyproductphotoId(int productphotoid);
    }
}
