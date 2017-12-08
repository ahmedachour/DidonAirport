using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FlightService : IFlightService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

        public FlightService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }
        public void AddFlight(flight flt)
        {
            unitOfWork.FlightRepository.Add(flt);
            unitOfWork.Commit();
        }


        public void assignBusToFlight(bus bs, int idFlight)
        {
            flight flt = unitOfWork.FlightRepository.GetById(idFlight);
            flt.idBus = bs.id;
            unitOfWork.FlightRepository.Update(flt);
            unitOfWork.Commit();
        }


        public void assignPlaneToFlight(plane pln, int idFlight)
        {
            flight flt = unitOfWork.FlightRepository.GetById(idFlight);
            flt.idPlane = pln.id;
            unitOfWork.FlightRepository.Update(flt);
            unitOfWork.Commit();
        }

        public void assignStaffToFlight(staff stf, int idFlight)
        {
            flight flt = unitOfWork.FlightRepository.GetById(idFlight);
            flt.idStaff = stf.id;
            unitOfWork.FlightRepository.Update(flt);
            unitOfWork.Commit();
        }

        public void deleteFlight(flight flt)
        {
            unitOfWork.FlightRepository.Delete(flt);
            unitOfWork.Commit();
        }

        public List<flight> getAllFlights()
        {
            return unitOfWork.FlightRepository.GetAll().ToList();
        }

        public flight getById(long id)
        {
            return unitOfWork.FlightRepository.GetById(id);
        }

        public void UpdateFlight(flight flt)
        {
            unitOfWork.FlightRepository.Update(flt);
            unitOfWork.Commit();
        }
    }

    public interface IFlightService
    {
        void AddFlight(flight flt);
        List<flight> getAllFlights();
        void UpdateFlight(flight flt);
        flight getById(long id);
        void deleteFlight(flight flt);
        void assignStaffToFlight(staff stf, int idFlight);
        void assignBusToFlight(bus bs, int idFlight);
        void assignPlaneToFlight(plane pln, int idFlight);
        
        
    }
}
