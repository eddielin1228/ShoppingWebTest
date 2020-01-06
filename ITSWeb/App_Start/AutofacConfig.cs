using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DataAccess.Base;
using DataAccess.Interface;
using ITSWeb.Models.Repository;

/// <summary>
/// DI設定檔
/// </summary>
public class AutofacConfig
{
    /// <summary>
    /// 註冊DI注入物件資料
    /// </summary>
    public static void Register()
    {
        // 容器建立者
        ContainerBuilder builder = new ContainerBuilder();

        // 註冊Controllers
        builder.RegisterControllers(Assembly.GetExecutingAssembly());
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        // 註冊DbContextFactory
        string connectionString =
            ConfigurationManager.ConnectionStrings["ShoppingWeb"].ConnectionString;
        builder.RegisterType<DbContextFactory>()
            .WithParameter("nameOfConnectionString", connectionString)
            .As<IDbContextFactory>()
            .InstancePerHttpRequest();

        // 註冊 Repository UnitOfWork
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));
        //builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

        // 註冊Services
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();

        // 建立容器
        IContainer container = builder.Build();

        // 解析容器內的型別
        AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver(container);
        AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

        // 建立相依解析器
        GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
        DependencyResolver.SetResolver(resolver);
    }
}