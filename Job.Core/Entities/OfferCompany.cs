using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class OfferCompany
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime OfferdDate { get; set; }
        public string SenderId { get; set; }
        public virtual AppUser Sender { get; set; }
        public string RecipientId { get; set; }
        public virtual AppUser Recipient { get; set; }
    }
}
