using Job.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Project.Apis.Dto
{
    public class OffersDto
    {
       public string OfferDetails { get; set; }
        public string TimeToRecive { get; set; }
        public int OfferValue { get; set; }
        public string AppuserId { get; set; }
        //public int JobId { get; set; }   
        public string user { get; set; }
        public string Job { get; set; }

    }
}
