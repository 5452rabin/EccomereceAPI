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
    public class CategoryPhotoService:ICategoryPhotoService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        public CategoryPhotoService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async void AddCategoryPhoto(Category_PhotoDTO categoryPhotoDTO)
        {
            using var transaction = _uow.BeginTransaction();
            try
            {
                CategoryPhoto categoryPhoto = _mapper.Map<CategoryPhoto>(categoryPhotoDTO);
                _uow.Repository<CategoryPhoto>().AddAsync(categoryPhoto);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();
                throw ex;
            }
        }
        public void DeleteCategoryPhoto(Category_PhotoDTO category_PhotoDTO)
        {
            using var transaction = _uow.BeginTransaction();
            try
            {
            CategoryPhoto categoryPhoto = _mapper.Map<CategoryPhoto>(category_PhotoDTO);
            _uow.Repository<CategoryPhoto>().DeleteById(categoryPhoto.CategoryPhotoId);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();
                throw ex;
            }
        }
        //Delete Not Working Because No any Deletion
        public void DeleteCategoryPhotoList(int Categoryid)
        {
            List<CategoryPhoto> categoryPhotos=_uow.Repository<CategoryPhoto>().GetAll().Where(x=>x.CategoryId == Categoryid).ToList();
            foreach(var  categoryPhoto in categoryPhotos)
            {
                _uow.Repository<CategoryPhoto>().DeleteById(categoryPhoto.CategoryPhotoId);
            }
        }

        public List<Category_PhotoDTO> GetAllCategoryPhotosByCategoryId(int id)
        {
            List<CategoryPhoto> categoryPhotos=_uow.Repository<CategoryPhoto>().GetAll().Where(x=>x.CategoryId == id).ToList();
            List<Category_PhotoDTO> category_PhotoDTOs=_mapper.Map<List<Category_PhotoDTO>>(categoryPhotos);
            return category_PhotoDTOs;
        }

        public Category_PhotoDTO GetCategoryPhotoById(int id)
        {
            CategoryPhoto categoryPhoto=_uow.Repository<CategoryPhoto>().GetById(id);
            Category_PhotoDTO category_PhotoDTO=_mapper.Map<Category_PhotoDTO>(categoryPhoto);
            return category_PhotoDTO;
        }
    }
}
