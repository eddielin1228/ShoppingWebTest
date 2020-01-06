using DataAccess.ShoppingWebDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUserDataRepository : IDisposable
    {
        void Create(AspNetUsers model);

        void Update(AspNetUsers instance);

        void Delete(AspNetUsers instance);

        AspNetUsers Get(int categoryID);

        IQueryable<AspNetUsers> GetAll();

        void SaveChanges();
    }
}
