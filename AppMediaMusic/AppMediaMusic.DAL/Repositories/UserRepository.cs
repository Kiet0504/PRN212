using AppMediaMusic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.DAL.Repositories
{
    public class UserRepository
    {
        private AssignmentPrnContext _context;
        public User? User(string username, string password)
        {
            _context = new AssignmentPrnContext();
            return _context.Users.FirstOrDefault(x => x.Username.ToLower() == username && x.Password == password);
        }
    }
}
