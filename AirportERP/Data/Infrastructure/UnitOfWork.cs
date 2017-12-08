using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         private didon_dbContext dataContext;
         protected didon_dbContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        


        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        private IUserRepository userRepository;

        public IUserRepository UserRepository
        {
            get { return userRepository = new UserRepository(dbFactory); }
        }

        private ITicketRepository ticketRepository;

        public ITicketRepository TicketRepository
        {
            get { return ticketRepository = new TicketRepository(dbFactory); }
        }

        private IStaffRepository staffRepository;
        public IStaffRepository StaffRepository
        {
            get { return staffRepository = new StaffRepository(dbFactory); }
        }

        private IFlightRepository flightRepository;
        public IFlightRepository FlightRepository
        {
            get
            {
                return flightRepository = new FlightRepository(dbFactory);
            }
        }

        private IPlaneRepository planeRepository;
        public IPlaneRepository PlaneRepository
        {
            get
            {
                return planeRepository = new PlaneRepository(dbFactory);
            }
        }
        private IProviderRepository providerRepository;

        public IProviderRepository ProviderRepository
        {
            get
            {
                return providerRepository = new ProviderRepository(dbFactory);
            }
        }
        private IMealRepository mealRepository;
        public IMealRepository MealRepository
        {
            get
            {
                return mealRepository = new MealRepository(dbFactory);
            }
        }

        private IBaggageRepository baggageRepository;
        public IBaggageRepository BaggageRepository
        {
            get
            {
                return baggageRepository = new BaggageRepository(dbFactory);
            }
        }

        private IBusRepository busRepository;
        public IBusRepository BusRepository
        {
            get
            {
                return busRepository = new BusRepository(dbFactory);
            }
        }

        private IRunwayRepository runwayRepository;
        public IRunwayRepository RunwayRepository
        {
            get
            {
                return runwayRepository = new RunwayRepository(dbFactory);
            }
        }

        private ICarRentalAgencyRepository carRentalAgencyRepository;
        public ICarRentalAgencyRepository CarRentalAgencyRepository
        {
            get
            {
              return  carRentalAgencyRepository = new CarRentalAgencyRepository(dbFactory);
            }
        }

        private ICarRepository carRepository;
        public ICarRepository CarRepository
        {
            get
            {
                return carRepository = new CarRepository(dbFactory);
            }
        }
    }
}
