using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using OZ_HEPSIBURADA.DAL.Repository;
using OZ_HEPSIBURADA.DAL.UnifOfWork;
using OZ_HEPSIBURADA.BLL.Services;
using OZ_HEPSIBURADA.DATA.Model_Entity;

namespace OZ_HEPSIBURADA.IOC
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void Injection<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            // The Unity container allows creating hierarchies of child containers. 
            // This lifetime creates local singleton for each level of the hierarchy. 
            // So, when you resolve a type and this container does not have an instance of that type, 
            // the container will create new instance. Next time the type is resolved the same instance will be returned.
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // It determines the relationships and lifetimes of classes.
            container.Injection<IUnitOfWork, UnitOfWork>();
            container.Injection<IRepository<Category>, Repository<Category>>();
            container.Injection<ICategoryService, CategoryService>();
        }
    }
}