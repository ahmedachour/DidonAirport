using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MealService : IMealService
    {
        public static DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public MealService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }

        public void addMeal(meal ml)
        {
            utwk.MealRepository.Add(ml);
            utwk.Commit();
        }

        public void assignFlightToMeal(flight flt, int idMeal)
        {
            meal ml = utwk.MealRepository.GetById(idMeal);
            ml.idFlight = flt.id;
            utwk.MealRepository.Update(ml);
            utwk.Commit();
        }

        public void deleteMeal(meal ml)
        {
            utwk.MealRepository.Delete(ml);
            utwk.Commit();
        }

        public List<meal> getAllMeals()
        {
            return utwk.MealRepository.GetAll().ToList();
        }

        public meal getById(long id)
        {
            return utwk.MealRepository.GetById(id);
        }

        public void updateMeal(meal ml)
        {
            utwk.MealRepository.Update(ml);
            utwk.Commit();
        }
    }

    public interface IMealService
    {
        void addMeal(meal ml);
        List<meal> getAllMeals();
        void updateMeal(meal ml);
        void deleteMeal(meal ml);

        meal getById(long id);
        void assignFlightToMeal(flight flt, int idFlight);
    }
}
