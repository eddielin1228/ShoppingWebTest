using ITSWeb.Infrastructure;
using ITSWeb.Interface;
using System.Web.Mvc;
using ITSWeb.Models.Service.SampleAccount;
using BusinessLogic.Service.ShoppingWeb;

namespace ITSWeb.Controllers.Base
{
    /// <summary>
    /// BaseController Dependency All Service
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 取得當前使用者資訊
        /// </summary>
        public ICurrentUserSerivce UserSerivce;

        public BaseController()
        {
            UserSerivce = new CurrentUserSerivce();
        }

        /// <summary>
        /// SampleService
        /// </summary>
        protected SampleService SampleService { get; set; }

        protected ProductManagementService ProductManagementService { get; set; }
    }
}