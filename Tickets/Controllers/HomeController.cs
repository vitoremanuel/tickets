using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Models;
using Tickets.Repositories;
using Tickets.Services;

namespace Tickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TicketsContext _context;
        IUserRepository _userRepository;
        public HomeController(TicketsContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(User user)
        {
            // Recupera o usuário
            var usuario = _userRepository.Get(user);

            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(usuario);

            // Oculta a senha
            usuario.Password = "";

            // Retorna os dados
            return new
            {
                user = usuario,
                token = token
            };
        }

        [HttpGet]
        [Authorize]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = _userRepository.GetUsers();

            return users;
        }
    }
}