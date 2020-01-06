using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;

namespace BusinessLogic.Service.ShoppingWeb
{
    public interface IOrderManagementService
    {
        ResponseMessage Create(OrderViewModel model);
        ResponseMessage Delete(OrderViewModel model);
        OrderViewModel Get(OrderViewModel model);
        List<OrderViewModel> GetAll();
        ResponseMessage Update(OrderViewModel model);
    }
}