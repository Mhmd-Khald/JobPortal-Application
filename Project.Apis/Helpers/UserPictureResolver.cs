using AutoMapper;
using Job.Core.Entities;
using Microsoft.Extensions.Configuration;
using Project.Apis.Dto;

namespace Project.Apis.Helpers
{
    public class UserPictureResolver : IValueResolver<AppUser, UserProfileDto, string>
    {
        public UserPictureResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string Resolve(AppUser source, UserProfileDto destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.PictureUrl))
                return $"{Configuration["ApiBaseUrl"]}{source.PictureUrl}";
            return null;
        }
    }
}
