using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RunwayService : IRunwayService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

        public RunwayService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }

        public void AddRunway(runway rnwy)
        {
            unitOfWork.RunwayRepository.Add(rnwy);
            unitOfWork.Commit();
        }

        

        public void deleteRunway(runway rnwy)
        {
            unitOfWork.RunwayRepository.Delete(rnwy);
            unitOfWork.Commit();
        }

        public List<runway> getAllRunways()
        {
            return unitOfWork.RunwayRepository.GetAll().ToList();
        }

        public runway getById(long id)
        {
            return unitOfWork.RunwayRepository.GetById(id);
        }

        public void UpdateRunway(runway rnwy)
        {
            unitOfWork.RunwayRepository.Update(rnwy);
            unitOfWork.Commit();
        }
    }

    public interface IRunwayService
    {
        void AddRunway(runway rnwy);
        List<runway> getAllRunways();
        void UpdateRunway(runway rnwy);
        runway getById(long id);
        void deleteRunway(runway rnwy);
        
    }
}
