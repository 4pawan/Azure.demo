using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Web.Implementation.Abstract
{
    interface IContext
    {
        dynamic Context { get; }
        void Add();

    }
}
