using DataAccess.ShoppingWebDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IOrderDetailRepository : IDisposable
    {
            void Create(OrderDetail model);

            void Update(OrderDetail instance);

            void Delete(OrderDetail instance);

            OrderDetail Get(int categoryID);

            IQueryable<OrderDetail> GetAll();

            void SaveChanges();
    }
}
