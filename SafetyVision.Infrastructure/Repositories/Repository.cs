using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;
using System.Linq.Expressions;

namespace SafetyVision.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;   
        }
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
