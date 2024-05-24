using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.GenericRepository.Interface
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        IDbContextTransaction BeginTransaction();
        Task<int> SaveChangesAsync();
        void Dispose();
        
    }
}
