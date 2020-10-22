using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repositories
{
    public interface ITicketRepository
    {       
        List<Ticket> GetTickets();
        Ticket Get(long id);
        long Update(long id, Ticket ticket);

    }
}
