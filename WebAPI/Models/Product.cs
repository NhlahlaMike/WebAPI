using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Barcode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductType { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Features { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Usage { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string BillingAddress { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TC { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }
        public int ProductSubCategoryID { get; set; }
        [ForeignKey("ProductSubCategoryID")]
        public ProductSubCategory ProductSubCategory { get; set; }
    }
}
