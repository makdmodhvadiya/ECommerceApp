using ECommerce.DAL.Model;
using System.Collections.Generic;

namespace ECommerce.BAL.Services
{
    public interface ICategoryService
    {
        IList<ProductCategory> GetCategories();
        IList<ProductAttributeLookup> GetAttributeLookups(int categoryId);
    }
}
