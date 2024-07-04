using AutoMapper;
using Eccommerec_BLL.DTO.Category;
using Eccommerec_BLL.DTO.Photo;
using Eccommerec_BLL.GenericRepository.Interface;
using Eccommerec_BLL.Services.Interface;
using Ecommerece_DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        private readonly ICategoryPhotoService _categoryPhotoService;
        public CategoryService(IUnitOfWork uow,IMapper mapper,ICategoryPhotoService categoryPhotoService)
        {
            _categoryPhotoService= categoryPhotoService;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> AddCategory([FromBody]AddCategoryDTO addCategoryDTO)
        {
         using var transacyion= _uow.BeginTransaction();
            try
            {
                Category category = _mapper.Map<Category>(addCategoryDTO);
                _uow.Repository<Category>().AddAsync(category);
                _uow.SaveChangesAsync();
                transacyion.Commit();
                CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
                return categoryDTO;
            }
            catch (Exception ex)
            {
                transacyion.RollbackAsync();
                throw ex;   
            }
        }

        public void DeleteCategory(CategoryDTO categoryDTO)
        {
            Category category =_mapper.Map<Category>(categoryDTO);
            _categoryPhotoService.DeleteCategoryPhotoList(categoryDTO.CategoryId);
            _uow.Repository<Category>().DeleteById(category.CategoryId);
        }
 

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            IEnumerable<Category> categories=_uow.Repository<Category>().GetAll();
            IEnumerable<CategoryDTO> categoryDTOs=_mapper.Map<IEnumerable<CategoryDTO>>(categories);
            foreach (var category in categoryDTOs)
            {
                category.category_Photos=_categoryPhotoService.GetAllCategoryPhotosByCategoryId(category.CategoryId);
            }
            return categoryDTOs;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            Category category=_uow.Repository<Category>().GetById(id);
            CategoryDTO categoryDTO=_mapper.Map<CategoryDTO>(category);
            List<Category_PhotoDTO> category_PhotoDTOs=_categoryPhotoService.GetAllCategoryPhotosByCategoryId(category.CategoryId).ToList();
            categoryDTO.category_Photos = category_PhotoDTOs;
            return categoryDTO;
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            _uow.Repository<Category>().Update(category);
            return categoryDTO;
        }
    }
}
