using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CarService : ICarService
    {
        public static DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public CarService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }

        public void addCar(car p)
        {
            utwk.CarRepository.Add(p);
            utwk.Commit();
        }

        public void deleteCar(car p)
        {
            utwk.CarRepository.Delete(p);
            utwk.Commit();
        }

        public List<car> getAllCars()
        {
            return utwk.CarRepository.GetAll().ToList();
        }

        public car getById(long id)
        {
            return utwk.CarRepository.GetById(id);
        }

        public void updateCar(car p)
        {
            utwk.CarRepository.Update(p);
            utwk.Commit();
        }
    }

    public interface ICarService
    {
        void addCar(car p);
        List<car> getAllCars();
        void updateCar(car p);
        void deleteCar(car p);

        car getById(long id);
    }
}
