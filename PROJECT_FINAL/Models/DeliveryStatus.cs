﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.Models
{
    public class DeliveryStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}