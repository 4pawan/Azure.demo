using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azure.Web.Implementation.Abstract;

namespace Azure.Web.Implementation.Concrete
{
    public class SqlContext : IContext
    {
        private readonly dynamic _context;

        public dynamic Context
        {
            get { return _context; }
        }

        public void Add()
        {

        }
    }
}