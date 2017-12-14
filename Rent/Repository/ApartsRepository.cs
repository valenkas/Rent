using Rent.Context;
using Rent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Repository
{
    public class ApartsRepository
    {

        private DbContext context;

        public ApartsRepository()
        {
            context = new DbContext();
        }

        public IEnumerable<Aparts> GetAparts()
        {
            return (context.Aparts);
        }
    }
}