using System;

namespace Project.Apis.Dto
{
    public class ReturnUserSendOfeerForCompany
    {
        public int OfferId { get; set; }
        public string OfferDetails { get; set; }
        public string UserId { get;set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string email { get; set; }
        public int OfferValue { get; set; }
        public string TimeToComplete { get; set; }
        public string PictureUrl { get; set; }
        public string DisplayName { get; set; }
        public int Jobid { get; set; }
    }
}
