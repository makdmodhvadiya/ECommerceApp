using ECommerce.BAL.Utilities;
using ECommerce.DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BAL.Services
{
    public class ProductService : IProductService
    {

        public IList<Product> GetProducts(int categoryId, int pageNumber, int pageSize, out long totalCount)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = uow.ProudctRepositry.GetAll(p => p.ProdCatId == categoryId, po => po.OrderBy(x => x.ProdName), "ProductAttribute,ProductAttribute.Attribute");
                totalCount = products.Count();
                return PagedList<Product>.Create(products, pageNumber, pageSize);
            }
        }

        public IList<ProductAttribute> GetProductAttributes(int productId)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.ProudctAttributeRepositry.GetAll(x => x.ProductId == productId).ToList();
            }
        }

        public Product GetProduct(long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var product = uow.ProudctRepositry.GetAll(p => p.ProductId == id, null, "ProductAttribute,ProductAttribute.Attribute").FirstOrDefault();
                if (product == null)
                {
                    product = new Product();
                }
                return product;
            }
        }

        public long Save(Product product)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (product.ProductId == 0)
                {
                    uow.ProudctRepositry.Add(product);
                }
                else
                {
                    var p = uow.ProudctRepositry.GetAll(x => x.ProductId == product.ProductId, null, "ProductAttribute").FirstOrDefault();
                    p.ProductAttribute.Clear();
                    p.ProdName = product.ProdName;
                    p.ProdDescription = product.ProdDescription;
                    p.ProdCatId = product.ProdCatId;
                    foreach (var attrb in product.ProductAttribute)
                    {
                        p.ProductAttribute.Add(attrb);
                    }
                    foreach (var attr in p.ProductAttribute)
                    {
                        if (!product.ProductAttribute.Contains(attr))
                        {
                            uow.ProudctAttributeRepositry.Delete(attr);
                        }
                    }
                }

                uow.Save();
            }
            return product.ProductId;
        }

        public bool Delete(long id)
        {
            using (var uow = new UnitOfWork())
            {
                var productToDelete = GetProduct(id);
                uow.ProudctRepositry.Delete(productToDelete);
                uow.Save();
                return true;
            }
        }
    }
}
