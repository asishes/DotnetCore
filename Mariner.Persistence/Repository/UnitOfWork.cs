using Mariner.Application.Repository;
using Mariner.Persistence.Context;

namespace Mariner.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarinerContext _context;

        public UnitOfWork(MarinerContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
