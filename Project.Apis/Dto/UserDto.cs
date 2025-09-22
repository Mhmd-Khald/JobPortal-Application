namespace Project.Apis.Dto
{
    public class UserDto
    {
        public string id { get; set; }
        public string Bio { get; set; }
        public string pictureUrl { get; set; }
        public string CvUrl { get; set; }
        public string DisplayName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //public string TokenValue { get; set; }
        public int IsCompanyOrNot { get; set; }
    }
}
