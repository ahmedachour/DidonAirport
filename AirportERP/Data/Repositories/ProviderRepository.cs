using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProviderRepository : RepositoryBase<provider>, IProviderRepository
    {
        public ProviderRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IProviderRepository : IRepository<provider>
    {

    }

}
