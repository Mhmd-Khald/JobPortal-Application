using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Job.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
        public string CVURl { get; set; }
        public string Position { get; set; }
        public string Bio { get; set; }
        public string VerficationCode { get; set; }
        public string City { get; set; }
        public string JobType { get; set; }
        [Required]
        public string Country { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<JobApplication> JobAppications { get; set; } = new HashSet<JobApplication>();
        public ICollection<OfferCompany> SentOffers { get; set; }
        public ICollection<OfferCompany> ReceivedOffers { get; set; }
        public ICollection<FreelanceJob> freelanceJobs { get; set; }
        //public ICollection<RateUser> rateUsers { get; set; }





    }
}