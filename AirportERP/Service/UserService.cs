using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

       public UserService()
        {
           dbFactory = new DatabaseFactory();
           unitOfWork = new UnitOfWork(dbFactory);
        }

        public void AddUser(user usr)
        {
            unitOfWork.UserRepository.Add(usr);
            unitOfWork.Commit();
        }

        public void deleteUser(user usr)
        {
            unitOfWork.UserRepository.Delete(usr);
            unitOfWork.Commit();
        }

        public List<user> getAllCoPilots()
        {
            List<user> users = getAllUsers();
            List<user> CoPilots = new List<user>();
            foreach (user usr in users)
            {
                if ((usr.function == "employee") && (usr.position == "Co-Pilote"))
                    CoPilots.Add(usr);
            }
            return CoPilots;
        }

        public List<user> getAllPilots()
        {
            List<user> users = getAllUsers();
            List<user> pilots = new List<user>();
            foreach (user usr in users)
            {
                if ((usr.function == "employee") && (usr.position == "Pilot"))
                    pilots.Add(usr);
            }
            return pilots;
        }

        public List<user> getAllStewardesses()
        {
            List<user> users = getAllUsers();
            List<user> stewardesses = new List<user>();
            foreach (user usr in users)
            {
                if ((usr.function == "employee") && (usr.position == "Stewardess"))
                    stewardesses.Add(usr);
            }
            return stewardesses;
        }

        public List<user> getAllStewards()
        {
            List<user> users = getAllUsers();
            List<user> stewards = new List<user>();
            foreach (user usr in users)
            {
                if ((usr.function == "employee") && (usr.position == "Steward"))
                    stewards.Add(usr);
            }
            return stewards;
        }

        public List<user> getAllTechnicians()
        {
            List<user> users = getAllUsers();
            List<user> technicians = new List<user>();
            foreach (user usr in users)
            {
                if ((usr.function == "employee") && (usr.position == "Technician"))
                    technicians.Add(usr);
            }
            return technicians;
        }

        public List<user> getAllUsers()
        {
            return unitOfWork.UserRepository.GetAll().ToList();
        }

        public user getById(long id)
        {
            return unitOfWork.UserRepository.GetById(id);
        }

        public void UpdateUser(user usr)
        {
            unitOfWork.UserRepository.Update(usr);
            unitOfWork.Commit();
        }
    }

    public interface IUserService
    {
        void AddUser(user usr);
        List<user> getAllUsers();
        List<user> getAllPilots();
        List<user> getAllCoPilots();
        List<user> getAllStewards();
        List<user> getAllStewardesses();
        List<user> getAllTechnicians();
        void UpdateUser(user usr);
        user getById(long id);
        void deleteUser(user usr);

    }
}
