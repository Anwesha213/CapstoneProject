using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int orderId { get; set; }

        [ForeignKey("Products")]
        public int productId { get; set; }

        public virtual Products Products { get; set; }

        [ForeignKey("AddressDetails")]
        public int addressId { get; set; }

        public virtual AddressDetails AddressDetails { get; set; }

    }
}

