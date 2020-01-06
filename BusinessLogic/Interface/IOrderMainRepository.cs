using DataAccess.ShoppingWebDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IOrderMainRepository : IDisposable
    {
            void Create(OrderMain model);

            void Update(OrderMain instance);

            void Delete(OrderMain instance);

            OrderMain Get(int categoryID);

            IQueryable<OrderMain> GetAll();

            void SaveChanges();
    }
}
