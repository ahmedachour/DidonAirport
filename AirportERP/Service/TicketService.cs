using Data.Infrastructure;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class TicketService : ITicketService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork unitOfWork = null;
        ITicketBookingResource tcktBooking = new TicketBookingResource();

        public TicketService()
        {
            dbFactory = new DatabaseFactory();
            unitOfWork = new UnitOfWork(dbFactory);
        }
        public void AddTicket(ticket tckt)
        {
            unitOfWork.TicketRepository.Add(tckt);
            unitOfWork.Commit();
        }

        public string bookTicket(int idPassenger, int idFlight, string category)
        {
            return tcktBooking.bookTicket(idPassenger, idFlight, category);
        }

        public void DeleteTicket(ticket tckt)
        {
            unitOfWork.TicketRepository.Delete(tckt);
            unitOfWork.Commit();
        }

        public ticket FindTicket(int idFlight, int idUser)
        {
            ticket tckt = null;
            List<ticket> tickets = GetAllTickets();
            foreach(ticket t in tickets)
            {
                if ((t.idFlight == idFlight) && (t.idPassenger == idUser))
                    tckt = t;
            }
            return tckt;
        }

        public List<ticket> GetAllTickets()
        {
            return unitOfWork.TicketRepository.GetAll().ToList();
        }

        public ticket GetById(long id)
        {
            return unitOfWork.TicketRepository.GetById(id);
        }

        public void UpdateTicket(ticket tckt)
        {
            unitOfWork.TicketRepository.Update(tckt);
            unitOfWork.Commit();
        }
    }

    public interface ITicketService
    {
        void AddTicket(ticket tckt);
        List<ticket> GetAllTickets();
        void UpdateTicket(ticket tckt);
        void DeleteTicket(ticket tckt);
        ticket GetById(long id);
        ticket FindTicket(int idFlight, int idUser);
        string bookTicket(int idPassenger, int idFlight, string category);
    }
}
