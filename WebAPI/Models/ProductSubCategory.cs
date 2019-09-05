using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductSubCategory
    {
        [Key]
        public int ProductSubCategoryID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SubCategoryName { get; set; }
        public IList<Product> Product { get; set; }
    }
}