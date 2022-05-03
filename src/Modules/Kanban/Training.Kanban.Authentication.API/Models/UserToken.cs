using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Kanban.Authentication.API.Models.Entity;

namespace Training.Kanban.Authentication.API.Models
{
    public class UserToken
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
