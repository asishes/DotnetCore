using Mariner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariner.Application.Repository.TestTakersRepository
{
    public interface ITestTakerRepository : IBaseRepository<TestTakers>
    {
        Task<TestTakers> GetByID(string BannerID, CancellationToken cancellationToken);

    }
}
