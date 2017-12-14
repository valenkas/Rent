using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rent.Context
{
    public class DbContext: System.Data.Entity.DbContext
    {
        public DbContext(): base("DefaultConnection") { }

        public DbSet<Aparts> Aparts { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}