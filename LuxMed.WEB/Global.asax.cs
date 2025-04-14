using AutoMapper;
using LuxMed.Domain.Entities.Admin;
using LuxMed.Domain.Entities.User;
using LuxMed.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LuxMed.Web;



namespace LuxMed.WEB
{
    public class Global: HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeAutoMapper();
        }

        protected static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserLogin, ULoginData>();
                cfg.CreateMap<UserRegister, URegisterData>();
                cfg.CreateMap<UserTable, UserMinimal>();

                cfg.CreateMap<AddUser, AddUserData>();
               
            });
        }
    }
}