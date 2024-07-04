using Eccommerec_BLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerById(int id);
        Task<CustomerDTO> AddCustomer(AddCustomerDTO addCustomerDTO);
        void DeleteCustomerById(int id);
        Task<IEnumerable<CustomerDTO>> GetAll();

    }
}
