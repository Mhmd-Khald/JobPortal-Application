using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class Offers
    {
      public int id { get; set; }
        public string TimeToRecive { get; set; }
        public int OfferValue { get; set; }
        public DateTime OfferDate { get; set; }
        public string OrderDetails { get; set; }
        public AppUser user { get; set; }
        public string AppuserId { get; set; }
        [ForeignKey("FreelanceJob")]
        public int FreelanceJobId { get; set; }
        public virtual FreelanceJob Jobs { get; set; }
    }
}
