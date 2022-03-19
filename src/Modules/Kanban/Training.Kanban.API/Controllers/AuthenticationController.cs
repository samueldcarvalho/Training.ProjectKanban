using Microsoft.AspNetCore.Mvc;
using Training.Kanban.Domain.Authentication.Models;
using Training.Kanban.Domain.Interfaces;

namespace Training.Kanban.API.Controllers
{
    [Route("api/v1/authentication")]
    public class AuthenticationController : Controller
    {

        private readonly IUserRepository _repository;

        public AuthenticationController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            _repository.GetById(1);
            _repository.Add(new User("Samuel", "samueldcarvalho99@gmail.com","12345"));
            return Json("Bem-vindo");
        }
    }
}
