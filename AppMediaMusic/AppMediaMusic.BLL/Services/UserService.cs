using AppMediaMusic.DAL.Entities;
using AppMediaMusic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.BLL.Services
{
    public class UserService
    {
        private UserRepository _repo = new UserRepository();
        public User Authenticate(string user, string pass)
        {
            return _repo.User(user, pass);
        }
    }
}
