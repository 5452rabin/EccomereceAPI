using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Photo
{
    public class Category_PhotoDTO
    {
        public int CategoryPhotoId { get; set; }
        public string CategoryPhotoName { get; set; }
        [Required]
        public string CategoryPhotoPath { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
    }
}
