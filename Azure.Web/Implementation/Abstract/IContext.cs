﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Web.Implementation.Abstract
{
    interface IContext
    {
        CloudStorageAccount CloudStorageAccount { get; }
        void Add();

    }
}
