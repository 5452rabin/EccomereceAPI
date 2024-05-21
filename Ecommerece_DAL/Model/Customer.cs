using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerece_DAL.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string municipality { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public bool HasViber { get; set; }
        public string ViberNo { get; set; }
        public bool HasWhatsApp { get; set; }

        public string WhatsAppNo { get; set;}
        public string Email { get; set; }

    }
}
