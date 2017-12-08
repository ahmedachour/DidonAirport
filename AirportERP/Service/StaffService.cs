using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StaffService : IStaffService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;

        public StaffService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }
        public void AddStaff(staff stf)
        {
            unitOfWork.StaffRepository.Add(stf);
            unitOfWork.Commit();
        }

        public void deleteStaff(staff stf)
        {
            unitOfWork.StaffRepository.Delete(stf);
            unitOfWork.Commit();
        }

        public List<staff> getAllStaffs()
        {
            return unitOfWork.StaffRepository.GetAll().ToList();
        }

        public staff getById(long id)
        {
            return unitOfWork.StaffRepository.GetById(id);
        }

        public List<staff> getStaffsByEffectif(int effectif)
        {
            List<staff> staffs = new List<staff>();
            List<staff> allStaffs = getAllStaffs();
            foreach(staff s in allStaffs)
            {
                if (s.effectif == effectif)
                    staffs.Add(s);
            }
            return staffs;
        }

        public void UpdateStaff(staff stf)
        {
            unitOfWork.StaffRepository.Update(stf);
            unitOfWork.Commit();
        }
    }
     public interface IStaffService
    {
        void AddStaff(staff stf);
        List<staff> getAllStaffs();
        void UpdateStaff(staff stf);
        staff getById(long id);
        void deleteStaff(staff stf);
        List<staff> getStaffsByEffectif(int effectif);
    }
}
