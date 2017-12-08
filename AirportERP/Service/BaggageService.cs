using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaggageService : IBaggageService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

        public BaggageService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }

        public void AddBaggage(baggage bgg)
        {
            unitOfWork.BaggageRepository.Add(bgg);
            unitOfWork.Commit();
        }

        public void assignFlightToBaggage(flight flt, int idBaggage)
        {
            baggage bgg = unitOfWork.BaggageRepository.GetById(idBaggage);
            bgg.idFlight = flt.id;
            unitOfWork.BaggageRepository.Update(bgg);
            unitOfWork.Commit();
        }

        public void assignPassengerToBaggage(user usr, int idBaggage)
        {
            baggage bgg = unitOfWork.BaggageRepository.GetById(idBaggage);
            bgg.idFlight = usr.id;
            unitOfWork.BaggageRepository.Update(bgg);
            unitOfWork.Commit();
        }

        public void deleteBaggage(baggage bgg)
        {
            unitOfWork.BaggageRepository.Delete(bgg);
            unitOfWork.Commit();
        }

        public List<baggage> findAllBaggagesByFlightId(int idFlight)
        {
            flight flt = unitOfWork.FlightRepository.GetById(idFlight);
            List<baggage> baggages = flt.baggages.ToList();
            return baggages;
        }

        

        public List<baggage> getAllBaggages()
        {
            return unitOfWork.BaggageRepository.GetAll().ToList();
        }

        public baggage getById(long id)
        {
            return unitOfWork.BaggageRepository.GetById(id);
        }

        public void UpdateBaggage(baggage bgg)
        {
            unitOfWork.BaggageRepository.Update(bgg);
            unitOfWork.Commit();
        }
    }

    public interface IBaggageService
    {
        void AddBaggage(baggage bgg);
        List<baggage> getAllBaggages();
        void UpdateBaggage(baggage bgg);
        baggage getById(long id);
        void deleteBaggage(baggage bgg);
        void assignFlightToBaggage(flight flt, int idBaggage);
        void assignPassengerToBaggage(user usr, int idBaggage);
        List<baggage> findAllBaggagesByFlightId(int idFlight);
     

    }
}
