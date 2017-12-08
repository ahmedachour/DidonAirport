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
    public class MealRepository : RepositoryBase<meal>, IMealRepository
    {
        public MealRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IMealRepository : IRepository<meal>
    {

    }

}
