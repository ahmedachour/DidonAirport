using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TicketBookingResource : ITicketBookingResource
    {
        public string bookTicket(int idPassenger, int idFlight, string category)
        {
            string response = null;
            using (WebClient wc = new WebClient())
            {
                response = wc.DownloadString("http://localhost:18080/airport-erp-web/rest/ticket/" + idPassenger + "/" + idFlight + "/" + category);
            }
            return response;
        }
    }
}
