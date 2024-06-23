using AutoMapper;
using Eccommerec_BLL.DTO.Product;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        private readonly IProductPhotoService _productPhotoService;
        public ProductService(IUnitOfWork uow, IMapper mapper, IProductPhotoService productPhotoService)
        {
            _uow = uow;
            _mapper = mapper;
            _productPhotoService = productPhotoService;
        }

        public async Task<ProductDTO> AddProduct(AddProductDTO addproductDTO)
        {
           using var transaction= _uow.BeginTransaction();
            try
            {
                Product product = _mapper.Map<Product>(addproductDTO);
                await _uow.Repository<Product>().AddAsync(product);
                _uow.SaveChangesAsync();
                transaction.Commit();
                ProductDTO productDTO=_mapper.Map<ProductDTO>(product);
                return productDTO;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void DeleteProduct(int productId)
        {
        using var transaction= _uow.BeginTransaction();
            try
            {
                _uow.Repository<Product>().DeleteById(productId);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public  ProductDTO GetProductById(int productId)
        {
            Product product= _uow.Repository<Product>().GetById(productId);
            ProductDTO productDTO=_mapper.Map<ProductDTO>(product); 
            productDTO.Photos=_productPhotoService.GetProductPhotoByProductId(productId);
            return productDTO;

        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            IEnumerable<Product> products= _uow.Repository<Product>().GetAll();
            IEnumerable<ProductDTO> productDTOs=_mapper.Map<IEnumerable<ProductDTO>>(products);
            foreach(var product in productDTOs)
            {
                product.Photos=_productPhotoService.GetProductPhotoByProductId(product.ProductId);
            }
            return productDTOs;
        }

        public IEnumerable<ProductDTO> GetProductsByCategoryId(int categoryId)
        {
            IEnumerable<Product> products = _uow.Repository<Product>().GetAll().Where(x => x.CategoryId == categoryId);
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            foreach (var product in productDTOs)
            {
                product.Photos = _productPhotoService.GetProductPhotoByProductId(product.ProductId);
            }
            return productDTOs;
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            using var transaction=_uow.BeginTransaction();
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                _uow.Repository<Product>().Update(product);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
