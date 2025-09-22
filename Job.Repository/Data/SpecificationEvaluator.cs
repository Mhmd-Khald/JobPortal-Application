using Job.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Repository.Data
{
    internal class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity> Spec)
        {
            var query = inputQuery;
            if (Spec.Criteria != null)
                query = query.Where(Spec.Criteria);

            if (Spec.OrderByDescending != null)
                query.OrderByDescending(Spec.Criteria);
            query = Spec.Includes.Aggregate(query, (currentQuery, includ) => currentQuery.Include(includ));



            return query;
        }
    }
}
