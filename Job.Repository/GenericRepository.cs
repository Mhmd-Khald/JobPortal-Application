using Job.Core.Repositories;
using Job.Core.Specification;
using Job.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Repository
{
    public class GenericRepository<T> : IGenericRepositories<T> where T : class
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //return await _context.Set<T>().Where(Item => Item.Id == id).FirsOrDefault();
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T>ApplySpec (ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>() , spec);
        }

        public async Task<int> GetCountAsync(ISpecification<T> Spec)
        {
            return await ApplySpec(Spec).CountAsync();
        }

        public async Task<int> Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await _context.SaveChangesAsync();
        }
    }
     
}
