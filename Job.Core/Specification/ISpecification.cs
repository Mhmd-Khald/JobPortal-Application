using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Specification
{
    public interface ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, Object>>> Includes { get; set; }
        public Expression<Func<T, Object>> OrderBy { get; set; } // P => P.Name   P => P.Price
        public Expression<Func<T, object>> OrderByDescending { get; set; }
    }
}
