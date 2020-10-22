using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        IConfiguration _configuration;
        TicketsContext _context;
        public TicketRepository(IConfiguration configuration, TicketsContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                GetSection("Default").Value;
            return connection;
        }
        public Ticket Get(long id)
        {
            var connectionString = this.GetConnection();
            Ticket ticket = new Ticket();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Ticket WHERE Id = @Id";
                    ticket = con.Query<Ticket>(query, new { Id = id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return ticket;
            }
        }

        public List<Ticket> GetTickets()
        {
            var connectionString = this.GetConnection();
            List<Ticket> tickets = new List<Ticket>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Ticket";
                    tickets = con.Query<Ticket>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return tickets;
            }
        }

        public long Update(long id, Ticket ticket)
        {
            var ticketSaved = _context.Tickets.Find(id);

            if (ticket.Description != null)
            {
                ticketSaved.Description = ticket.Description;
            }
            if (ticket.AuthorName != null)
            {
                ticketSaved.AuthorName = ticket.AuthorName;
            }
            if (ticket.Date != null && ticket.Date != new DateTime())
            {
                ticketSaved.Date = ticket.Date;
            }

            _context.Entry(ticketSaved).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return ticketSaved.Id;
        }
    }
}
