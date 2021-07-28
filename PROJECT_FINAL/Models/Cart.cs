using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        //si Foreign Key ka ProductId(lidhja me tbl Product)
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}