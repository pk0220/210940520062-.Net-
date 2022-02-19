using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetLabExam.Models
{
    public class Product
    {
        [Required]
        [DisplayName("Product ID")]
        public int ProductId { set; get; }

        [Required]
        [StringLength(50)]
        [DisplayName("Product Name")]
        public string ProductName { set; get; }

        [Required]
        [DisplayName("Rate")]
        public decimal Rate { set; get; }

        [Required]
        [StringLength(200)]
        [DisplayName("Description")]
        public string Description { set; get; }

        [Required]
        [StringLength(50)]
        [DisplayName("Category Name")]
        public string CategoryName { set; get; }
    }
}