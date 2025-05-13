using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.ViewModels
{
    public class PendingOrderVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}