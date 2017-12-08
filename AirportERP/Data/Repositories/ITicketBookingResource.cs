using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public  interface ITicketBookingResource
    {
        string bookTicket(int idPassenger, int idFlight, string category);
    }
}
