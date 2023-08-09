using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkHW.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Order
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("EmployeeId")]
        public Guid? EmployeeId { get; set; }

        [Column("ProductId")]
        public Guid? ProductId { get; set; }

        [Column("OrderDetails")]
        public string OrderDetails { get; set; }
    }
}
