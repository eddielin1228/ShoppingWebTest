using BusinessLogic.Service.ShoppingWeb;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;
using ITSWeb.Controllers.Base;
using ITSWeb.Models.Repository;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace ITSWeb.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Admin")]
    public class ProductManageController : BaseController
    {
        IProductManagementService productManagementService;
        public ProductManageController()
        {
            productManagementService = new ProductManagementService();
        }
        /// <summary>
        /// 商品管理 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.ProductList = productManagementService.GetAllProduct();

            return View();
        }
        /// <summary>
        /// 商品管理 新增頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult CreateProduct(ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            if (model == null)
            {
                result.success = false;
                result.Message = "沒有商品資料";
            }

            if (result.success)
            {
                model.ProductId = Guid.NewGuid().ToString();
                result = productManagementService.CreateProduct(model);
            }

            return Json(result);
        }
        /// <summary>
        /// 修改 商品資訊 頁面
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult Detail(string productId)
        {
            ViewBag.ProductList = productManagementService.GetProductData(productId);

            return View();
        }

        /// <summary>
        /// 修改商品資訊
        /// </summary>
        /// <param name="model">商品資料</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult UpdateProduct([FromBody]ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            if (model == null)
            {
                result.success = false;
            }
            result = productManagementService.UpdateProduct(model);
            return Json(result);
        }
        /// <summary>
        /// 刪除商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteProduct([FromBody]ProductViewModel model)
        {
            ResponseMessage result = new ResponseMessage()
            {
                success = true
            };
            if (string.IsNullOrWhiteSpace(model.ProductId))
            {
                result.success = false;
                result.Message = "沒有商品ID";
            }
            if (result.success)
            {
                result = productManagementService.DeleteProduct(model.ProductId);
            }
            return Json(result);
        }
    }
}