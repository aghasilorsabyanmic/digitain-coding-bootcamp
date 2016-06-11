using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Invalid Name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Range(10.0, 1000000.0, ErrorMessage = "Invalid Price")]
        [Display(Name = "Product Price in AMD")]
        public double Price { get; set; }
    }
}