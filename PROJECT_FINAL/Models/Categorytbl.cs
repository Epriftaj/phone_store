using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class Categorytbl
    {
        [Key]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}