using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.GenericRepository.Interface
{
    public interface IUnitofWork : IDisposable
    {

        void Dispose();
        
    }
}
