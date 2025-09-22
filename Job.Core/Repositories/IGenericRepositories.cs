using Job.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Repositories
{
    public interface IGenericRepositories<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<int> GetCountAsync(ISpecification<T> Spec);
        Task<int> Add(T item);
    }
}
