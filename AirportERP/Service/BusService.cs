using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BusService : IBusService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

        public BusService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }

        public void AddBus(bus bs)
        {
            unitOfWork.BusRepository.Add(bs);
            unitOfWork.Commit();
        }

        public void deleteBus(bus bs)
        {
            unitOfWork.BusRepository.Delete(bs);
            unitOfWork.Commit();
        }

        public List<bus> getAllBuss()
        {
            return unitOfWork.BusRepository.GetAll().ToList();
        }

        public bus getById(long id)
        {
            return unitOfWork.BusRepository.GetById(id);
        }

        public void UpdateBus(bus bs)
        {
            unitOfWork.BusRepository.Update(bs);
            unitOfWork.Commit();
        }
    }

    public interface IBusService
    {
        void AddBus(bus bs);
        List<bus> getAllBuss();
        void UpdateBus(bus bsr);
        bus getById(long id);
        void deleteBus(bus bs);

    }
}
