using Job.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Services
{
    public interface ITokenServices
    {
        Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager);

    }
}
