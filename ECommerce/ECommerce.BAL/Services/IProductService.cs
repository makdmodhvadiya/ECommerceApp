using ECommerce.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.BAL.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts(int categoryId, int pageNumber, int pageSize, out long totalCount);
        IList<ProductAttribute> GetProductAttributes(int productId);
        Product GetProduct(long id);
        long Save(Product product);
        bool Delete(long id);
    }
}
