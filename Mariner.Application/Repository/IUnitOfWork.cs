﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariner.Application.Repository
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken);
    }
}
