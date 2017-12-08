using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models;
using Data.Interfaces;

namespace Data.Repositories
{
    public class TicketRepository : RepositoryBase<ticket>, ITicketRepository
    {
        public TicketRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        { }
    }
    public interface ITicketRepository : IRepository<ticket>
    {

    }
}
