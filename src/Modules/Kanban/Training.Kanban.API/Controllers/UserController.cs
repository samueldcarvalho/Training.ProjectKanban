using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Kanban.Domain.Boards.Joins;
using Training.Kanban.Domain.Teams.Joins;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Contexts;

namespace Training.Kanban.API.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly KanbanDbContext _context;

        public UserController(KanbanDbContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterUser()
        {
            await _context.Users.AddAsync(new User("Samuel de Carvalho", "samueldcarvalho99@gmail.com", "samueldcarvalho", "asd99536416", new List<TeamUser>()
            {
                new TeamUser
                {
                    Team = new Domain.Teams.Team("personal", "", null, null, null)
                }
            }, new List<BoardUser>()));

            _context.SaveChanges();

            return Ok(true);
        }

    }
}
