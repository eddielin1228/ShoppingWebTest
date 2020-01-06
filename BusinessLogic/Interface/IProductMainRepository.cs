using DataAccess.ShoppingWebDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProductMainRepository : IDisposable
    {
            void Create(ProductMain model);

            void Update(ProductMain instance);

            void Delete(ProductMain instance);

            ProductMain Get(int categoryID);

            IQueryable<ProductMain> GetAll();

            void SaveChanges();
    }
}
