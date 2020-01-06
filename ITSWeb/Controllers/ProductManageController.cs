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
        public ActionResult Index()
        {
            ViewBag.ProductList = productManagementService.GetAll();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
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
        public ActionResult Detail(string productId)
        {
            ProductViewModel model = new ProductViewModel()
            {
                ProductId = productId
            };
            ViewBag.ProductList = productManagementService.Get(model);

            return View();
        }
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