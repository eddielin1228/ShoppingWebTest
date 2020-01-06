using BusinessLogic.Interface;
using DataAccess.ShoppingWebDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    class ProductMainRepository : IProductMainRepository
    {
        protected ShoppingWebContext db{get;set;}
        public ProductMainRepository()
        {
            this.db = new ShoppingWebContext();
        }
        public void Create(ProductMain model)
        {
            if (model != null)
            {
                db.ProductMain.Add(model);
                this.SaveChanges();
            }
        }

        public void Delete(ProductMain model)
        {
            if (model != null)
            {
                db.ProductMain.Remove(model);
                this.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ProductMain Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductMain> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductMain model)
        {
            throw new NotImplementedException();
        }

                protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
