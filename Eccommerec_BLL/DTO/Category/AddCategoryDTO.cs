using Eccommerec_BLL.DTO.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.DTO.Category
{
    public class AddCategoryDTO
    {
<<<<<<< Updated upstream
        public string CategoryName { get; set; }
        public List<Category_PhotoDTO> category_Photos { get; set; }
=======
        [Required]
        public string CategoryName { get; set; }
>>>>>>> Stashed changes
    }
}
