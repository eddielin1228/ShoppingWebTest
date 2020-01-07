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
        ResponseMessage CreateProduct(ProductViewModel model);
        /// <summary>
        /// 刪除商品資料
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <returns></returns>
        ResponseMessage DeleteProduct(string productId);
        /// <summary>
        /// 取得單一商品資料
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <returns></returns>
        ProductViewModel GetProductData(string productId);
        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        List<ProductViewModel> GetAllProduct();
        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        ResponseMessage UpdateProduct(ProductViewModel model);
    }
}