using System;

namespace Project.Apis.Dto
{
    public class GetDetailsOfFreelancedDto
    {
       
        public string ProjectStatus { get; set; }
        public string TimeToComplete { get; set; }
        public string ProjectDetails { get; set; }
        public string Title { get; set; }
        public string RequiredSkills { get; set; }
        public string Budget { get; set; }
        public DateTime Published { get; set; }
        public string projectOwner { get; set; }
    }
}
