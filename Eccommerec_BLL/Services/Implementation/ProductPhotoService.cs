using AutoMapper;
using Eccommerec_BLL.DTO.Photo;
using Eccommerec_BLL.GenericRepository.Interface;
using Eccommerec_BLL.Services.Interface;
using Ecommerece_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Implementation
{
    public class ProductPhotoService : IProductPhotoService
    {
        
        private IMapper _mapper;
        private IUnitOfWork _uow;
        public ProductPhotoService(IMapper mapper,IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Product_PhotoDTO> AddProductPhoto(Product_PhotoDTO productPhotoDTO)
        {
            using var transaction=_uow.BeginTransaction();
            try
            {
                ProductPhoto productPhoto = _mapper.Map<ProductPhoto>(productPhotoDTO);
                await _uow.Repository<ProductPhoto>().AddAsync(productPhoto);
                await _uow.SaveChangesAsync();
                await transaction.CommitAsync();
                productPhotoDTO =_mapper.Map<Product_PhotoDTO>(productPhoto);
                return productPhotoDTO;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void DeleteProductPhoto(int productphotoId)
        {
            using var transaction = _uow.BeginTransaction();
            try
            {
                _uow.Repository<ProductPhoto>().DeleteById(productphotoId);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public IEnumerable<Product_PhotoDTO> GetProductPhotoByProductId(int productId)
        {
           IEnumerable<ProductPhoto> productPhotos=_uow.Repository<ProductPhoto>().GetAll().Where(p => p.ProductId == productId);
           IEnumerable<Product_PhotoDTO> product_PhotoDTOs=_mapper.Map<IEnumerable<Product_PhotoDTO>>(productPhotos);
           return product_PhotoDTOs;
        }

        public Product_PhotoDTO GetProduct_PhotobyproductphotoId(int productphotoid)
        {
            ProductPhoto productPhoto=_uow.Repository<ProductPhoto>().GetById(productphotoid);
            Product_PhotoDTO product_PhotoDTO = _mapper.Map<Product_PhotoDTO>(productPhoto);
            return product_PhotoDTO;
        }
    }
}
