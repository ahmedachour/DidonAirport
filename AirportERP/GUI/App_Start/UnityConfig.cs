using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Service;
using Data.Repositories;
using Data.Infrastructure;

namespace GUI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<IUserService, UserService>(new PerRequestLifetimeManager());
            container.RegisterType<ITicketService, TicketService>(new PerRequestLifetimeManager());
            container.RegisterType<IStaffService, StaffService>(new PerRequestLifetimeManager());
            container.RegisterType<IFlightService, FlightService>(new PerRequestLifetimeManager());
            container.RegisterType<IBusService, BusService>(new PerRequestLifetimeManager());
            container.RegisterType<IBaggageService, BaggageService>(new PerRequestLifetimeManager());
            container.RegisterType<ICarService, CarService>(new PerRequestLifetimeManager());
            container.RegisterType<ICarRentalAgencyService, CarRentalAgencyService>(new PerRequestLifetimeManager());
            container.RegisterType<IPlaneService, PlaneService>(new PerRequestLifetimeManager());
            container.RegisterType<IMealService, MealService>(new PerRequestLifetimeManager());
            container.RegisterType<IProviderService, ProviderService>(new PerRequestLifetimeManager());
            container.RegisterType<IRunwayService, RunwayService>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ITicketRepository, TicketRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IStaffRepository, StaffRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IFlightRepository, FlightRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IBusRepository, BusRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IBaggageRepository, BaggageRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICarRepository, CarRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICarRentalAgencyRepository, CarRentalAgencyRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IPlaneRepository, PlaneRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IMealRepository, MealRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IProviderRepository, ProviderRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IRunwayRepository, RunwayRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());
            
        }
    }
}
