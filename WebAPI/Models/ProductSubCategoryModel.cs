using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductSubCategoryModel
    {
        public int ProductSubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public IList<ProductModel> ProductModel { get; set; }
    }
}