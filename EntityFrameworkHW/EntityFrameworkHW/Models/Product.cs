using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkHW.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("Price")]
        public decimal Price { get; set; }

        [Required]
        [Column("AvailableForPurchase")]
        public bool AvailableForPurchase { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
