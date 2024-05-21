using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerece_DAL.Model
{
    public class ProductPhoto
    {
        public int ProductPhotoId { get; set; }
        public string ProductPhotoName { get; set; }
        public string ProductPhotoPath { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
