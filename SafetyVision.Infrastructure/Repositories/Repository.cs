using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;
using System.Linq.Expressions;
using System.Threading;

namespace SafetyVision.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _context.Set<T>().AddAsync(entity, cancellationToken);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => await _context.Set<T>().Where(predicate).ToListAsync(cancellationToken);

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Set<T>().ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => await _context.Set<T>().FindAsync(id, cancellationToken);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
