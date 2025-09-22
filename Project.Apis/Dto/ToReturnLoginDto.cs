using System.Net.NetworkInformation;

namespace Project.Apis.Dto
{
    public class ToReturnLoginDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }   
        public string Token { get; set; }
    }
}
