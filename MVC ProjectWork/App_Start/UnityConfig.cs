//using MVC_ProjectWork.Repository;
//using System.Web.Mvc;
//using Unity;
//using Unity.Mvc5;

//namespace MVC_ProjectWork
//{
//    public static class UnityConfig
//    {
//        public static void RegisterComponents()
//        {
//			var container = new UnityContainer();
//            container.RegisterType<IUserMasterRepository, UserMasterRepository>();

//            // register all your components with the container here
//            // it is NOT necessary to register your controllers

//            // e.g. container.RegisterType<ITestService, TestService>();

//            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
//        }
//    }
//}