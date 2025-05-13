using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DeliveryStatusId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime InsertedDate { get; set; }

        public virtual DeliveryStatus DeliveryStatus { get; set; }
    }
}