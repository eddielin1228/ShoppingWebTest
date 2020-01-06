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
            ViewBag.ProductList = productManagementService.GetAll();

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
        public ActionResult CreateProduct([FromBody]ProductViewModel model)
        {
            if (model == null)
            {
                return Json("");
            }
            model.ProductId = Guid.NewGuid().ToString();
            ResponseMessage result = productManagementService.Create(model);
            return Json(result);
        }
        /// <summary>
        /// 修改 商品資訊 頁面
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult Detail(string productId)
        {
            ProductViewModel model = new ProductViewModel()
            {
                ProductId = productId
            };
            ViewBag.ProductList = productManagementService.Get(model);

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
            if (model == null)
            {
                return Json("");
            }
            ResponseMessage result = productManagementService.Update(model);
            return Json(result);
        }
    }
}