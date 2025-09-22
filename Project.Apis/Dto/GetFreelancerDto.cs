using System;

namespace Project.Apis.Dto
{
    public class GetFreelancerDto
    {
        public int id { get; set; }
        public string ProjectDetails { get; set; }
        public string Title { get; set; }
        public string Budget { get; set; }
        public string ProjectOwner { get; set; }
        public string pictureUrl { get; set; }
    }
}
