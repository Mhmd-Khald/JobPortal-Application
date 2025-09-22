using System;

namespace Project.Apis.Dto
{
    public class ReturnSendOffer
    {
        public int OfferId { get; set; }
        public string Message { get; set; }
        public DateTime OfferdDate { get; set; }
        public string Reciver { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public string ReciverId { get; set; }
    }
}
