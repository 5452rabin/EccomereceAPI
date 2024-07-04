using Eccommerec_BLL.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface IProductService
    {

        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByCategoryId(int categoryId);
        ProductDTO GetProductById(int productId);
        void DeleteProduct(int productId);
        void UpdateProduct(ProductDTO productDTO);
        Task<ProductDTO> AddProduct(AddProductDTO addproductDTO);

        Task<ProductDTO> AddProductAsExplored(int productId);
        Task<ProductDTO> RemoveProductAsExplored(int productId);
        List<ProductDTO> GetAllExploredProducts();


    }
}
