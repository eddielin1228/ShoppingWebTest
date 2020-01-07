using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;

namespace BusinessLogic.Service.ShoppingWeb
{
    public interface IOrderManagementService
    {
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="model">訂單資料</param>
        /// <returns></returns>
        ResponseMessage CreateOrder(OrderViewModel model);

    }
}