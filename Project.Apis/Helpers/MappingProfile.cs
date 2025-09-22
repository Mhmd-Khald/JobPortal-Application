using AutoMapper;
using Job.Core.Entities;
using Project.Apis.Dto;
using System.Runtime.InteropServices;

namespace Project.Apis.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jobs, JobToReturnDto>()
           .ForMember(d => d.user, o => o.MapFrom(s => s.User.DisplayName))
           .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.User.PictureUrl));
            ////.ForMember(d => d.JobAppications, o => o.MapFrom(s => s.JobAppications));
            CreateMap<Jobs, ToReurnJobDetails>()
                .ForMember(d => d.user, o => o.MapFrom(s => s.User.DisplayName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.User.PictureUrl));


            CreateMap<JobApplication, ToReturnJoThatUserApply>()
                .ForMember(c => c.Title, o => o.MapFrom(j => j.Jobs.Title))
                 .ForMember(c => c.ApplicantId, o => o.MapFrom(j => j.Id))
             .ForMember(c => c.UserId, o => o.MapFrom(j => j.Jobs.User.Id))

                .ForMember(c => c.piCtrueUrl, o => o.MapFrom(j => j.Jobs.User.PictureUrl))
                 .ForMember(c => c.Name, o => o.MapFrom(j => j.Jobs.User.DisplayName));
                     //.ForMember(c => c.User, o => o.MapFrom(j => j.user)); // Include the user



            CreateMap<JobApplication, ReturnUserthatAppliedToCompany>()
    .ForMember(dest => dest.TitleOfJob, opt => opt.MapFrom(src => src.Jobs.Title))
    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.user.DisplayName))
    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.user.Email))
    .ForMember(dest => dest.CvUrl, opt => opt.MapFrom(src => src.user.CVURl))
            .ForMember(dest => dest.PictureUrl, o => o.MapFrom(s => s.user.PictureUrl));



  //          CreateMap<Offers, ToReturnOfferThatUserSendTo>()
  //             .ForMember(c => c.Title, o => o.MapFrom(j => j.Jobs.Title))
  //             .ForMember(c => c.DateTime, o => o.MapFrom(j => j.OfferDate));
  //          CreateMap<Offers, ReturnUserSendOfeerForCompany>()
  //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Jobs.Title))
  //.ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.user.UserName))
  //.ForMember(dest => dest.email, opt => opt.MapFrom(src => src.user.Email))
  //.ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.OfferDate));
           









        }

    }
}
