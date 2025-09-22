using System;

namespace Project.Apis.Dto
{
    public class ToReturnOfferReciverDto
    {
        public string Message { get; set; }
        public DateTime OfferDate { get; set; }
        public string Reciver { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }  
        public string ReciverId { get; set; }
    }
}
