using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerece_DAL.Model
{
    public class CategoryPhoto
    {
        [Key]
        public int CategoryPhotoId { get; set; }
        public string CategoryPhotoName { get; set; }
        [Required]
        public string CategoryPhotoPath { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
