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
   public class BusRepository : RepositoryBase<bus>, IBusRepository
    {
        public BusRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        { }
}

public interface IBusRepository : IRepository<bus>
    {

    }
}
