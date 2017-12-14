using Rent.Context;
using Rent.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Rent.Repository
{
    public class UsersRepository
    {
        private DbContext context;

        public UsersRepository()
        {
            context = new DbContext();
        }
        
        public IEnumerable<Users> GetUsers()
        {
            return (context.Users);
        }

        public Users GetUserByLogin(string userlogin)
        {
            return (context.Users.FirstOrDefault(x => x.UserLogin == userlogin));
        }

        public Users GetUserByPassword(string userpassword)
        {
            return (context.Users.FirstOrDefault(x => x.UserPassword == userpassword));
        }


    }
}