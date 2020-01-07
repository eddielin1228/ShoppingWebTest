using System.Linq;
using BusinessLogic.Service.SampleSystem;
using BusinessLogic.Service.ShoppingWeb;
using DataAccess.ShoppingWebDataBase;
using ITSWeb.Controllers.Base;
using Repository;
using System.Web.Mvc;

namespace ITSWeb.Controllers
{
    public class HomeController : BaseController
    {
        IProductManagementService productManagementService;

        public HomeController()
        {
            productManagementService = new ProductManagementService();
        }
        public ActionResult Index()
        {
            var data = productManagementService.GetAllProduct().Where(x=>x.CanSale).ToList();

            ViewBag.ProductList = data;

            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

    }
}