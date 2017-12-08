using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PlaneService : IPlaneService
    {
        public static DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;


        public PlaneService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }
        public void addPlane(plane p)
        {
            utwk.PlaneRepository.Add(p);
            utwk.Commit();

        }

        public void assignRunwayToPlane(runway rnwy, int idPlane)
        {
            plane pln = utwk.PlaneRepository.GetById(idPlane);
            pln.idRunway = rnwy.id;
            utwk.PlaneRepository.Update(pln);
            utwk.Commit();
        }

        public void deletePlane(plane p)
        {
            utwk.PlaneRepository.Delete(p);
            utwk.Commit();
        }

        public List<plane> findAllPlanesByEffectif(int effectif)
        {
            List<plane> allPlanes = getAllPlanes();
            List<plane> planes = new List<plane>();
            foreach(plane pln in allPlanes)
            {
                if (pln.effectif == effectif)
                    planes.Add(pln);
            }
            return planes;
        }

        public List<plane> getAllPlanes()
        {
            return utwk.PlaneRepository.GetAll().ToList();
        }

        public plane getById(long id)
        {
            return utwk.PlaneRepository.GetById(id);
        }

        public void updatePlane(plane p)
        {
            utwk.PlaneRepository.Update(p);
            utwk.Commit();
        }
    }

    public interface IPlaneService
    {
        void addPlane(plane p);
        List<plane> getAllPlanes();
        void updatePlane(plane p);
        void deletePlane(plane p);
        void assignRunwayToPlane(runway rnwy, int idPlane);
        plane getById(long id);
        List<plane> findAllPlanesByEffectif(int effectif);
    }
}
