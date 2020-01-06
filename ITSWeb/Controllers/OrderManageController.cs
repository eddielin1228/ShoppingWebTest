using BusinessLogic.Service.ShoppingWeb;
using DataAccess.Domain;
using DataAccess.ShoppingWebDataBase;
using ITSWeb.Controllers.Base;
using ITSWeb.Models.Repository;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace ITSWeb.Controllers
{
    public class OrderManageController : BaseController
    {
        IOrderManagementService orderManagementService;
        public OrderManageController()
        {
            orderManagementService = new OrderManagementService();
        }
        /// <summary>
        /// 訂單列表(未實作)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.ProductList = orderManagementService.GetAll();
            return View();
        }
        /// <summary>
        /// 訂單畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="model">訂單資料</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult CreateOrder([FromBody]OrderViewModel model)
        {
            if (model == null)
            {
                return Json("");
            }
            model.OrderId = Guid.NewGuid().ToString();
            model.OrderUser = base.UserSerivce.CurrentUser.Identity.Name;
            ResponseMessage result = orderManagementService.Create(model);
            return Json(result);
        }
    }
}