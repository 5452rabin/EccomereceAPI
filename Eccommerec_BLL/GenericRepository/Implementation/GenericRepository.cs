using Eccommerec_BLL.GenericRepository.Interface;
using Ecommerece_DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.GenericRepository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EccomereceDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(EccomereceDBContext dBContext) 
        {
            _dbContext= dBContext;
            _dbSet = dBContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
     
          await _dbSet.AddAsync(entity);
          return entity;
            
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async void DeleteById(int id)
        {
            T entity= await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetDatas()
        {
            return _dbSet;
        }

        public async void Update(T entity)
        {
           _dbSet.Update(entity);
        }
       
    }
}
