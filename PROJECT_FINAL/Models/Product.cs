
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
       
        public bool isActive { get; set; }


        //ka si Foreign Key Category_Id 
        public int Category_Id { get; set; }
        public Categorytbl Categorytbl { get; set; }


        public ICollection<Cart> Cart { get; set; }//lidhja ma tbl Cart
        public ICollection<Order> Order { get; set; }//lidhja me tbl Order



        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}