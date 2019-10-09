using ECommerce.Api.ViewModel;
using ECommerce.BAL.Services;
using ECommerce.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get(int categoryId, int page, int pageSize)
        {
            long productCount = 0;
            var productList = _productService.GetProducts(categoryId, page, pageSize, out productCount);
            var products = productList.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProdCatId = p.ProdCatId,
                ProdDescription = p.ProdDescription,
                ProdName = p.ProdName,
                ProductAttribute = p.ProductAttribute.Select(y => new ProductAttributeViewModel()
                {
                    AttributeId = y.AttributeId,
                    AttributeName = y.Attribute.AttributeName,
                    AttributeValue = y.AttributeValue
                }).ToList()
            }).ToList();

            var productListVM = new ProductListViewModel { TotalCount = productCount, Products = products };

            return Ok(productListVM);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var productVM = new ProductViewModel { 
                ProductId = product.ProductId,
                ProdName = product.ProdName,
                ProdDescription = product.ProdDescription,
                ProdCatId = product.ProdCatId
            };
            var attributes = product.ProductAttribute.Select(pa => new ProductAttributeViewModel { 
                AttributeId = pa.AttributeId,
                AttributeName = pa.Attribute.AttributeName,
                AttributeValue = pa.AttributeValue
            });
            productVM.ProductAttribute.AddRange(attributes.ToList());
            return Ok(productVM);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var product = new Product
            {
                ProductId = productVM.ProductId,
                ProdName = productVM.ProdName,
                ProdDescription = productVM.ProdDescription,
                ProdCatId = productVM.ProdCatId,
                ProductAttribute = productVM.ProductAttribute.Select(pa => new ProductAttribute
                {
                    AttributeId = pa.AttributeId,
                    AttributeValue = pa.AttributeValue,
                    ProductId = productVM.ProductId
                }).ToList()
            };
            long id = _productService.Save(product);
            return Ok(id);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var product = new Product
            {
                ProductId = productVM.ProductId,
                ProdName = productVM.ProdName,
                ProdDescription = productVM.ProdDescription,
                ProdCatId = productVM.ProdCatId,
                ProductAttribute = productVM.ProductAttribute.Select(pa => new ProductAttribute
                {
                    AttributeId = pa.AttributeId,
                    AttributeValue = pa.AttributeValue,
                    ProductId = productVM.ProductId
                }).ToList()
            };
            _productService.Save(product);
            return Ok(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid request.");
            }

            _productService.Delete(id);
            return Ok();
        }
    }
}
