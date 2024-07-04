using Eccommerec_BLL.DTO.User;
using Ecommerece_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Order
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
    }
}
