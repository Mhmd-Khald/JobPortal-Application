using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Specification
{
    public class JobParam
    {
        public int? JobId { get; set; }
         public string experince { get; set; }
        public string jobType { get; set; }
        public string position { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string WorkPlace { get; set; }
        //public decimal? Salary { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string disabled { get; set; }
        private string search;

        public string Search
        {
            get { return search; }
            set { search =  value.ToLower();}
        }

    }
}
