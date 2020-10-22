using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repositories
{
    public class UserRepository : IUserRepository
    {
        IConfiguration _configuration;
        TicketsContext _context;
        public UserRepository(IConfiguration configuration, TicketsContext context)
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
        public User Get(User usuario)
        {
            var connectionString = this.GetConnection();
            User user = new User();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM \"User\" WHERE Username = @Username and Password = @Password";
                    user = con.Query<User>(query, new { Username = usuario.Username, Password = usuario.Password }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return user;
            }
        }

        public List<User> GetUsers()
        {
            var connectionString = this.GetConnection();
            List<User> users = new List<User>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT Id, Username FROM \"User\"";
                    users = con.Query<User>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return users;
            }
        }
    }
}
