using System;

namespace Project.Apis.Dto
{
    public class ReturnUserthatAppliedToCompany
    {
        public string UserId { get; set; }
        public string TitleOfJob { get; set; }
        public DateTime DateApplied { get; set; }
        public string DisplayName { get; set; }
        public string email { get; set; }
        public int Jobid { get; set; }
        public string CvUrl { get; set; }
        public string PictureUrl { get; set; }
        

    }
}
