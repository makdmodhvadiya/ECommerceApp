using ECommerce.BAL.Repositories;
using ECommerce.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BAL
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProudctRepositry { get; }
        IRepository<ProductCategory> ProudctCategoryRepositry { get; }
        IRepository<ProductAttribute> ProudctAttributeRepositry { get; }
        IRepository<ProductAttributeLookup> ProudctAttributeLookupRepositry { get; }
        int Save();
    }
}
