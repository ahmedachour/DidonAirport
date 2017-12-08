using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProviderService : IProviderService
    {
        public static DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public ProviderService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }

        public void addProvider(provider p)
        {
            utwk.ProviderRepository.Add(p);
            utwk.Commit();
        }

        public void deleteProvider(provider p)
        {
            utwk.ProviderRepository.Delete(p);
            utwk.Commit();
        }

        public List<provider> getAllProviders()
        {
            return utwk.ProviderRepository.GetAll().ToList();
        }

        public provider getById(long id)
        {
            return utwk.ProviderRepository.GetById(id);
        }

        public void updateProvider(provider p)
        {
            utwk.ProviderRepository.Update(p);
            utwk.Commit();
        }
    }

    public interface IProviderService
    {
        void addProvider(provider p);
        List<provider> getAllProviders();
        void updateProvider(provider p);
        void deleteProvider(provider p);
        provider getById(long id);
    }
}
