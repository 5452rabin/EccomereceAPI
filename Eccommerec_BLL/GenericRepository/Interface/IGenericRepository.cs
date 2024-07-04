﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.GenericRepository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        void DeleteById(int id);
        Task<T> Update(T entity);
        IQueryable<T> GetDatas();
    }
}
