using AutoMapper;
using Eccommerec_BLL.DTO.Category;
using Eccommerec_BLL.DTO.Photo;
using Eccommerec_BLL.DTO.Product;
using Eccommerec_BLL.DTO.User;
using Ecommerece_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Abstraction
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryDTO, CategoryDTO>().ReverseMap();
            CreateMap<AddProductDTO,Product>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, AddProductDTO>().ReverseMap();
            CreateMap<CustomerDTO,Customer>().ReverseMap();
            CreateMap<ProductPhoto,Product_PhotoDTO>().ReverseMap();
            CreateMap<CategoryPhoto,Category_PhotoDTO>().ReverseMap();
           
        }
    }
}
