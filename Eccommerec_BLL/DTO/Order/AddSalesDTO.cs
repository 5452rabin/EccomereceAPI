using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Order
{
    public class AddSalesDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int quatity { get; set; }
        public string unitname { get; set; }
    }
}
