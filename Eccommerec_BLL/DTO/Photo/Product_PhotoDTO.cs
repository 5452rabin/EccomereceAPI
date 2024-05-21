using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Photo
{
    public class Product_PhotoDTO
    {
        public int ProductPhotoId { get; set; }
        public string ProductPhotoName { get; set; }
        public string ProductPhotoPath { get; set; }

        public int ProductId { get; set; }
    }
}
