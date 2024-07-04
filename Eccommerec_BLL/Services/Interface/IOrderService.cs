using Eccommerec_BLL.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrder(AddOrderDTO addOrder);
        Task<OrderDTO> GetOrder(int id);
        Task<IEnumerable<OrderDTO>> GetOrders();
        void DeleteOrder(int id);
        Task<OrderDTO> GetOrderByCustomerId(int id);


    }
}
