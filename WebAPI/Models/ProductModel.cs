using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public string Features { get; set; }
        public string Usage { get; set; }
        public string BillingAddress { get; set; }
        public string TC { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int ProductSubCategoryID { get; set; }
        [ForeignKey("ProductSubCategoryID")]
        public ProductSubCategoryModel ProductSubCategoryModel { get; set; }
    }
}
