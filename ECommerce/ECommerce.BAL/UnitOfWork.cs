using ECommerce.BAL.Repositories;
using ECommerce.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ECommerceDemoContext _context;

        public IRepository<Product> ProudctRepositry { get; private set; }
        public IRepository<ProductCategory> ProudctCategoryRepositry { get; private set; }
        public IRepository<ProductAttribute> ProudctAttributeRepositry { get; private set; }
        public IRepository<ProductAttributeLookup> ProudctAttributeLookupRepositry { get; private set; }

        public UnitOfWork()
        {
            _context = new ECommerceDemoContext();
            ProudctRepositry = new GenericRepository<Product>(_context);
            ProudctCategoryRepositry = new GenericRepository<ProductCategory>(_context);
            ProudctAttributeRepositry = new GenericRepository<ProductAttribute>(_context);
            ProudctAttributeLookupRepositry = new GenericRepository<ProductAttributeLookup>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        #region Disposable
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
