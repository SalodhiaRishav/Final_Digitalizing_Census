using System.Web.Http;
using BL.BusinessLogics;
using DAL.Repositories;
using DAL.RepositoryInterface;
using DAL.UnitOfWork;
using Shared.Interfaces;
using Shared.Interfaces.BusinessLayerInterfaces;
using Unity;
using Unity.WebApi;

namespace My_Digitalizing_Census_Project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserUnitOfWork, UserUnitOfWork>();

            container.RegisterType<IHouseMemberUnitOfWork, HouseMemberUnitOfWork>();

            container.RegisterType<IHouseUnitOfWork, HouseUnitOfWork>();

            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IHouseRepository, HouseRepository>();

            container.RegisterType<IHouseMemberRepository, HouseMemberRepository>();

            container.RegisterType<IUserCurrentRequestStatusRepository, UserCurrentRequestStatusRepository>();

            container.RegisterType<IUserCurrentRequestStatusUnitOfWork, UserCurrentRequestStatusUnitOfWork>();

            container.RegisterType<IUserBusinessLayer, UserBusinessLogic>();

            container.RegisterType<IHouseMemberBusinessLayer, HouseMemberBusinessLogic>();

            container.RegisterType<IHouseUnitOfWork, HouseUnitOfWork>();

            container.RegisterType<IUserCurrentRequestStatusBusinessLayer, UserCurrentRequestStatusBusinessLogic>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}