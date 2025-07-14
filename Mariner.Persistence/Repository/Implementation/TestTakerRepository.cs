using Microsoft.EntityFrameworkCore;
using Mariner.Application.Repository.TestTakersRepository;
using Mariner.Domain.Entities;
using Mariner.Persistence.Context;


namespace Mariner.Persistence.Repository.TestTakersRepository
{
    public class TestTakerRepository : BaseRepository<TestTakers>, ITestTakerRepository
    {
        public TestTakerRepository(MarinerContext context) : base(context)
        {
        }

        public Task<TestTakers> GetByID(string BannerID, CancellationToken cancellationToken)
        {
            return Context.TestTakers.FirstOrDefaultAsync(x => x.BannerID == BannerID, cancellationToken);
        }
    }
}
