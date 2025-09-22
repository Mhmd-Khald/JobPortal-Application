using System;

namespace Project.Apis.Dto
{
    public class UserProfileDto
    {
       public string DisplayName { get; set; }
        public string Cv { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string city { get; set; }
        public string Bio { get; set; }
        public string country { get; set; }
        public string Education { get; set;  }
    }
}
