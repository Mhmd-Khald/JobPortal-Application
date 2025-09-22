using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Specification
{
    public class UserParam
    {
        public string UserId { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string experince { get; set; }
        public string jobType { get; set; }
        public string position { get; set; }
        private string search;

        public string Search
        {
            get { return search; }
            set { search = value.ToLower(); }

        }
    }
}
