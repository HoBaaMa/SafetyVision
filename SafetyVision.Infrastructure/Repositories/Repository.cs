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

        public void DeleteAsync(T entity) => _context.Set<T>().Remove(entity); 

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);


        public void UpdateAsync(T entity) => _context.Set<T>().Update(entity);
    }
}
