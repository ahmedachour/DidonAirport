using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ITicketService ticketService = new TicketService();
            System.Console.WriteLine(ticketService.bookTicket(2, 5, "VIP"));
            System.Console.ReadKey();
        }
    }
}
