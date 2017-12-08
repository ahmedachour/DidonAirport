using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IUserRepository UserRepository { get; }
        ITicketRepository TicketRepository { get; }
        IStaffRepository StaffRepository { get; }
        IFlightRepository FlightRepository { get; }
        IPlaneRepository PlaneRepository { get; }
        IProviderRepository ProviderRepository { get; }
        IMealRepository MealRepository { get; }
        IBaggageRepository BaggageRepository { get; }
        IBusRepository BusRepository { get; }
        IRunwayRepository RunwayRepository { get; }
        ICarRentalAgencyRepository CarRentalAgencyRepository { get; }
        ICarRepository CarRepository { get; }



    }

}
