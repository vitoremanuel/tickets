using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repositories
{
    public interface IUserRepository
    {       
        List<User> GetUsers();
        User Get(User user);        

    }
}
