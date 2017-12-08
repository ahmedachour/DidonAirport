using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CarRentalAgencyService : ICarRentalAgencyService
    {
        public static DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public CarRentalAgencyService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }

        public void addCarRentalAgency(carrentalagency cra)
        {
            utwk.CarRentalAgencyRepository.Add(cra);
            utwk.Commit();
        }

        public void deleteCarRentalAgency(carrentalagency cra)
        {
            utwk.CarRentalAgencyRepository.Delete(cra);
            utwk.Commit();
        }

        public List<carrentalagency> getAllCarRentalAgencys()
        {
            return utwk.CarRentalAgencyRepository.GetAll().ToList();
        }

        public carrentalagency getById(long id)
        {
            return utwk.CarRentalAgencyRepository.GetById(id);
        }

        public void updateCarRentalAgency(carrentalagency cra)
        {
            utwk.CarRentalAgencyRepository.Update(cra);
            utwk.Commit();
        }
    }

    public interface ICarRentalAgencyService
    {
        void addCarRentalAgency(carrentalagency cra);
        List<carrentalagency> getAllCarRentalAgencys();
        void updateCarRentalAgency(carrentalagency cra);
        void deleteCarRentalAgency(carrentalagency cra);

        carrentalagency getById(long id);
    }
}
