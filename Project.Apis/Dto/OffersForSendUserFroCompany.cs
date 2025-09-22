using System;

namespace Project.Apis.Dto
{
    public class OffersForSendUserFroCompany
    {
        public string Message { get; set; }
        public DateTime OfferdDate { get; set; }
        public string UserId { get; set; }
        public string RecipientId { get; set; }
    }
}
