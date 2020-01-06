using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;

namespace BusinessLogic.Service.ShoppingWeb
{
    public interface IProductManagementService
    {
        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        ResponseMessage Create(ProductViewModel model);
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        ResponseMessage Delete(ProductViewModel model);
        /// <summary>
        /// 取得單一商品資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        ProductViewModel Get(ProductViewModel model);
        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        List<ProductViewModel> GetAll();
        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        ResponseMessage Update(ProductViewModel model);
    }
}