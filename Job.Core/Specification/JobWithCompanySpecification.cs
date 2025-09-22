using Job.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Job.Core.Specification
{
    public class JobWithCompanySpecification: BaseSpecification<Jobs>
    {
        public JobWithCompanySpecification(JobParam jobParam)
            : base(j =>
            (string.IsNullOrEmpty(jobParam.Search) || j.Title.ToLower().Contains(jobParam.Search)) &&
                (!jobParam.JobId.HasValue || j.Id == jobParam.JobId.Value) &&
              (string.IsNullOrEmpty(jobParam.experince) || j.Experience.ToLower() == jobParam.experince.ToLower()) &&
              (string.IsNullOrEmpty(jobParam.jobType) || j.JobType.ToLower() == jobParam.jobType.ToLower()) &&
            (string.IsNullOrEmpty(jobParam.position) || j.Position.ToLower() == jobParam.position.ToLower()) &&
            (!jobParam.SalaryMin.HasValue  || (j.Salary >= jobParam.SalaryMin && j.Salary <= jobParam.SalaryMax))&&
                        (!jobParam.SalaryMax.HasValue || (j.Salary >= jobParam.SalaryMin && j.Salary <= jobParam.SalaryMax)) &&

            (string.IsNullOrEmpty(jobParam.disabled) || j.disabledJob.ToLower() == jobParam.disabled.ToLower())
            &&(string.IsNullOrEmpty(jobParam.WorkPlace) || j.WorkPlace.ToLower() == jobParam.WorkPlace.ToLower()) &&
            (string.IsNullOrEmpty(jobParam.Country) || j.Country.ToLower() == jobParam.Country.ToLower()) &&
            (string.IsNullOrEmpty(jobParam.City) || j.City.ToLower() == jobParam.City.ToLower()))




        {
            //Includes.Add(j => j.JobAppications);
            Includes.Add(j => j.User);

        }
        public JobWithCompanySpecification(int id) : base(c=> c.Id == id)
        {
            //Includes.Add(j => j.JobAppications);
            Includes.Add(j => j.User);


        }

    }
}
