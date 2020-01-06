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
        ResponseMessage Create(OrderViewModel model);
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="model">訂單資料</param>
        /// <returns></returns>
        ResponseMessage Delete(OrderViewModel model);
        /// <summary>
        /// 取得單一訂單
        /// </summary>
        /// <param name="model">訂單ID</param>
        /// <returns></returns>
        OrderViewModel Get(OrderViewModel model);
        /// <summary>
        /// 取得全部訂單資料
        /// </summary>
        /// <returns></returns>
        List<OrderViewModel> GetAll();
        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseMessage Update(OrderViewModel model);
    }
}