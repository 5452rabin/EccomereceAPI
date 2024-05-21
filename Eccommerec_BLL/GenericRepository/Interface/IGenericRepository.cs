using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.GenericRepository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        T Update(T entity);
        IQueryable<T> GetDatas();
    }
}
