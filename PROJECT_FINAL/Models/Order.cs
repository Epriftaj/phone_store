using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual Invoices Invoice { get; set; }
        public virtual ApplicationUser User { get; set; }

        //ka si FK ProductId

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}