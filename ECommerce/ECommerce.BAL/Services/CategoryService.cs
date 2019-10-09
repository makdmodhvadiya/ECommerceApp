using ECommerce.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.BAL.Services
{
    public class CategoryService : ICategoryService
    {
        public IList<ProductAttributeLookup> GetAttributeLookups(int categoryId)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.ProudctAttributeLookupRepositry.GetAll(a => a.ProdCatId == categoryId).ToList();
            }
        }

        public IList<ProductCategory> GetCategories()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.ProudctCategoryRepositry.GetAll(null, c => c.OrderBy(x => x.CategoryName)).ToList();
            }
        }
    }
}
