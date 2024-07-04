using Eccommerec_BLL.DTO.Product;
using Ecommerece_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Order
{
    public class SalesDTO
    {
        public ProductDTO Product { get; set; }
        public int quatity { get; set; }
        public string unitname { get; set; }
    }
}
