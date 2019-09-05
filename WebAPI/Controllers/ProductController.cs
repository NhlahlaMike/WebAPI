using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        public ProductController(AuthenticationContext context)
        {
            _context = context;
        }
        /*
        [HttpGet("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }
        */

        [HttpGet("[action]")]
        [Authorize]
        // GET: api/Product
        public async Task<Object> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<Object> GetAllProductsByCategory()
        {
            var allProduct = await _context.Products.ToListAsync();

            IEnumerable<ProductSubCategory> allProductByCategory = from p in allProduct
                                                                   group p by p.ProductSubCategoryID into s1
                                                                   select new ProductSubCategory()
                                                                   {
                                                                       ProductSubCategoryID = s1.Key,
                                                                       Product = s1.Select(x => new Product
                                                                       {
                                                                           Barcode = x.Barcode,
                                                                           ProductName = x.ProductName,
                                                                           ProductType = x.ProductType,
                                                                           Quantity = x.Quantity,
                                                                           Description = x.Description,
                                                                           UnitPrice = x.UnitPrice,
                                                                           Features = x.Features,
                                                                           Usage = x.Usage,
                                                                           BillingAddress = x.BillingAddress,
                                                                           TC = x.TC,
                                                                           ImageUrl = x.ImageUrl,
                                                                           Category = x.Category,
                                                                           ProductSubCategoryID = x.ProductSubCategoryID

                                                                       }).ToList()
                                                                   };


            return allProductByCategory;
    }

        [HttpGet("[action]/{id}")]
        [Authorize]
        // GET: api/Product
        public async Task<Object> GetOtherProducts([FromRoute] int id)
        {
            //return Ok(await _context.Products.ToListAsync());
            var getallProducts = await _context.Products.ToListAsync();
            IEnumerable < ProductSubCategory > theProducts = from p in getallProducts
                                                             where p.ProductSubCategoryID == id
                                                             group p by p.ProductSubCategoryID into s1
                                                             select new ProductSubCategory()
                                                             {
                                                                 ProductSubCategoryID = s1.Key,
                                                                Product = s1.Select(x => new Product
                                                                {
                                                                    Barcode = x.Barcode,
                                                                    ProductName = x.ProductName,
                                                                    ProductType = x.ProductType,
                                                                    Quantity = x.Quantity,
                                                                    Description = x.Description,
                                                                    UnitPrice = x.UnitPrice,
                                                                    Features = x.Features,
                                                                    Usage = x.Usage,
                                                                    BillingAddress = x.BillingAddress,
                                                                    TC = x.TC,
                                                                    ImageUrl = x.ImageUrl,
                                                                    Category = x.Category,
                                                                    ProductSubCategoryID = x.ProductSubCategoryID

                                                                }).ToList()
                                                             };

            return theProducts;

            //return Ok(await _context.Products.Where(x => x.ProductSubCategoryID == id).ToListAsync());
            /*
            return new
            {
                products.Barcode,
                products.ProductName,
                products.ProductType,
                products.Description,
                products.ImageUrl,
                products.Features,
                products.Usage,
                products.ProductSubCategoryID
            };*/

            // ProductSubCategory ProductSubCategory = await _context.ProductSubCategories.Include(c => c.Product)
            //   .Single(c => c.ProductSubCategoryID);
        }

        [HttpPost("[action]")]
        [Authorize]
        // POST: api/Product
        public async Task<ActionResult<ProductModel>> PostProducts([FromBody] ProductModel model)
        {
            //string userId = User.Claims.First(c => c.Type == "UserID").Value;
            //var user = await _userManager.FindByIdAsync(userId);await _context.ProductSubCategories.ToListAsync();
            /*
                        var ProductSubCategory = new ProductSubCategory()
                        {
                            ProductSubCategoryID = model.ProductSubCategoryID,
                            SubCategoryName = "Lotion"
                        };
                        */
            //ProductSubCategory addProductSubCategory = await _context.ProductSubCategories.Single(SubC => SubC.ProductSubCategoryID ==
            //model.ProductSubCategoryID);
            ProductSubCategory addProductSubCategory = await _context.ProductSubCategories.FirstOrDefaultAsync(SubC => SubC.ProductSubCategoryID ==
            model.ProductSubCategoryID);

            // IList<ProductSubCategory> subCategories = await _context.ProductSubCategories.Include(SubC => SubC.ProductSubCategoryID)
            //                                                                             .Where(SubC => SubC.ProductSubCategoryID == model.ProductSubCategoryID);

            var ProductSubCategoryModel = new ProductSubCategoryModel()
            {
                ProductSubCategoryID = addProductSubCategory.ProductSubCategoryID,
                SubCategoryName = addProductSubCategory.SubCategoryName
            };
            //Convert.ToInt32()
            var Product = new Product()
            {
                Barcode = model.Barcode,
                ProductName = model.ProductName,
                ProductType = model.ProductType,
                Quantity = model.Quantity,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                Features = model.Features,
                Usage = model.Usage,
                BillingAddress = model.BillingAddress,
                TC = model.TC,
                ImageUrl = model.ImageUrl,
                Category = model.Category,
                ProductSubCategoryID = model.ProductSubCategoryID,
                ProductSubCategory = addProductSubCategory
            };
            try
            {

                await _context.Products.AddAsync(Product);
                await _context.SaveChangesAsync();
                return Ok(new JsonResult("The Product was Added Successfully"));

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPut("[action]/{id}")]
        [Authorize]
        // PUT: api/Product
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel formdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var findProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            if (findProduct == null)
            {
                return NotFound();
            }

            // If the product was found
            findProduct.Barcode = formdata.Barcode;
            findProduct.ProductName = formdata.ProductName;
            findProduct.ProductType = formdata.ProductType;
            findProduct.Quantity = formdata.Quantity;
            findProduct.Description = formdata.Description;
            findProduct.UnitPrice = formdata.UnitPrice;
            findProduct.Features = formdata.Features;
            findProduct.Usage = formdata.Usage;
            findProduct.BillingAddress = formdata.BillingAddress;
            findProduct.TC = formdata.TC;
            findProduct.ImageUrl = formdata.ImageUrl;
            findProduct.Category = formdata.Category;
            findProduct.ProductSubCategoryID = formdata.ProductSubCategoryID;
                

            _context.Entry(findProduct).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(new JsonResult("The Product with id " + id + " is updated"));

        }

        [HttpDelete("[action]/{id}")]
        [Authorize]
        // PUT: api/Product
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // find the product

            var findProduct = await _context.Products.FindAsync(id);

            if (findProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(findProduct);

            await _context.SaveChangesAsync();

            // Finally return the result to client
            return Ok(new JsonResult("The Product with id " + id + " is Deleted."));

        }


    }
}