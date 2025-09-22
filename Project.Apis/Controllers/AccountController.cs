using AutoMapper;
using Job.Core.Entities;
using Job.Core.Repositories;
using Job.Core.Services;
using Job.Core.Specification;
using Job.Repository.Data;
using Job.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using Project.Apis.Dto;
using Project.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Project.Apis.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<AccountController> _generic;
        private readonly IWebHostEnvironment _WebHost;
        private readonly StoreDbContext _context;
        private readonly Helper _helper;


        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenServices tokenServices, RoleManager<IdentityRole> roleManager, IMapper mapper, IGenericRepositories<AccountController> generic
            ,IWebHostEnvironment webHost,
            StoreDbContext context , Helper helper , IHttpContextAccessor httpContextAccessor)

        {
            _WebHost = webHost;
            _context = context;
            _helper = helper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _roleManager = roleManager;
            _mapper = mapper;
            _generic = generic;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        [HttpPost("register/Company")]
        public async Task<ActionResult<ToReturnLoginDto>> Register(RegisterCompany registerCompany)
        {
            if (CheckEmailExist(registerCompany.email).Result.Value)
                return BadRequest("This Email Already used");
            var user = new AppUser()
            {
                DisplayName = registerCompany.displayName,
                Email = registerCompany.email,
                PhoneNumber = registerCompany.phoneNumber,
                UserName = registerCompany.email.Split("@")[0],
                City = registerCompany.City,
                Country = registerCompany.Country,
                Bio = registerCompany.Bio

            };
            var result = await _userManager.CreateAsync(user, registerCompany.password);
            if (!result.Succeeded) return BadRequest();
            var roleResult = await _userManager.AddToRoleAsync(user, "company");

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(roleResult.Errors);
            }


            return Ok(new ToReturnLoginDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateToken(user, _userManager)
            });
        }
        [HttpPost("register/user")]
        public async Task<ActionResult<ToReturnLoginDto>> RegisterUser(RegisterUserDto registerUserDto)
        {
            if (CheckEmailExist(registerUserDto.Email).Result.Value)
                return BadRequest("This Email Already used");
            var user = new AppUser()
            {
                DisplayName = registerUserDto.DisplayName,
                City = registerUserDto.City,
                Country = registerUserDto.Country,
                Email = registerUserDto.Email,
                Experience = registerUserDto.Experience,
                Qualification = registerUserDto.Qualification,
                DateOfBirth = registerUserDto.DateOfBirth,
                JobType = registerUserDto.JobType,
                UserName = registerUserDto.Email.Split("@")[0]
            };
            var result = await _userManager.CreateAsync(user, registerUserDto.password);
            if (!result.Succeeded) return BadRequest();
            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(roleResult.Errors);
            }

            return Ok(new ToReturnLoginDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateToken(user, _userManager)
            });
        }
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>>  CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
        //[HttpPost("login")]
        //public async Task<ActionResult<ToReturnLoginDto>> Login(LoginDto loginDto)
        //{
        //    var user = await _userManager.FindByEmailAsync(loginDto.Email);
        //    if (user == null) return Unauthorized();
        //    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        //    if (!result.Succeeded) return Unauthorized();
        //    var roles = await _userManager.GetRolesAsync(user);

        //    var PublicToken = await _tokenServices.CreateToken(user, _userManager);
        //    _session.SetString("key", PublicToken);
        //    var value = _session.GetString("key");


        //    if (roles.Contains("company"))
        //    {
        //        return RedirectToAction("GetUsersWithRole", "User"); // , new { tokenPass = PublicToken }

        //        //return RedirectToAction("GetUsersWithRole", "User"); ESLAM
        //    }
        //    if (roles.Contains("User"))
        //    {
        //        return RedirectToAction("GetJob", "Job", new { tokenPass = PublicToken });
        //    }

        //    return Ok(new ToReturnLoginDto()
        //    {

        //        Email = user.Email,
        //        DisplayName = user.DisplayName,
        //        Token = await _tokenServices.CreateToken(user, _userManager)

        //    });
        //}
        [HttpPost("login")]
        public async Task<ActionResult<ToReturnLoginDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            var roles = await _userManager.GetRolesAsync(user);

            var publicToken = await _tokenServices.CreateToken(user, _userManager);

            bool isCompany = roles.Contains("company");
            bool isUser = roles.Contains("User");

            if (isCompany)
            {
               

                return Ok(new { IsCompany = true, Token = publicToken });
            }
            else if (isUser)
            {
                

                return Ok(new { IsCompany = false, Token = publicToken });
            }
            else
            {
                return Unauthorized();
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<ToReturnLoginDto>> GetCurrentUser()

        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new ToReturnLoginDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateToken(user, _userManager)
            });
        }
        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail(ForgetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var rng = new Random();
                    var code = rng.Next(1000, 9999).ToString();

                    user.VerficationCode = code; // update the verification code
                    await _userManager.UpdateAsync(user);

                    var email = new Email()
                    {
                        Subject = "Reset Your Password",
                        To = model.Email,
                        Body = code
                    };
                    EmailSetting.SendEmail(email);

                    return Ok("The Code Send Succecfully");
                }

                ModelState.AddModelError(string.Empty, "Invalid email.");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("codecheck/{Email}")]
        public async Task<ActionResult> CodeCheck(CheckCodeDto check , string Email)
        {
            //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.VerficationCode == check.verificationcode);

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null || user.VerficationCode != check.verificationcode)
            {
                return BadRequest("Invalid verification code.");
            }

            user.VerficationCode = null;
            await _userManager.UpdateAsync(user);

            return Ok("Go To Change Password");
        }
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                if (user is not null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, Token, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok("Password has been reset successfully.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password reset failed.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email address.");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // Sign out the current user
            return Ok(new { message = "Logout successful" });
        }

        [HttpPost("uploadimage")]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_WebHost.WebRootPath, "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = $"{Request.Scheme}://{Request.Host}/Images/{fileName}";
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            user.PictureUrl = image;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { image_Url = image });


        }

        //[HttpPost("UplodeImage")]
        //[Authorize]
        //public async Task<ActionResult<AppUser>> UploadVImage(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        ModelState.AddModelError("file", "The file is required.");
        //        return BadRequest(ModelState);
        //    }
        //    var email = User.FindFirstValue(ClaimTypes.Email);
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var imag = DocumentUploder.UploadFile(file, "Images");
        //    user.PictureUrl = imag;
        //    var result = await _userManager.UpdateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok();
        //       }
        [HttpPost("UplodeCv")]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<AppUser>> UploadCv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_WebHost.WebRootPath, "Documentaion", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var cv = $"{Request.Scheme}://{Request.Host}/Documentaion/{fileName}";
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            user.CVURl = cv;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { cv_Url = cv });


        }

        [HttpPost("UpateBio")]
        [Authorize]
        public async Task<ActionResult> UpdateBio( string Bio , string Education , string Name , string Position , string JobType)
        
        {
            if(string.IsNullOrWhiteSpace(Bio))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(Education))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(Position))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(JobType))
            {
                return BadRequest();
            }

            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("UsrNotFound");
            }
            user.Bio = Bio;
            user.DisplayName = Name;
            user.Qualification = Education;
            user.Position= Position;
            user.JobType = JobType;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to update bio.");
            }

            return Ok("Bio updated successfully.");
        }
       

    }
    }




//https://github.com/aksoftware98/identitycorecourse
//https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
//https://github.com/usamashfque/royal-car-rentals-web-api/blob/33dbc122a268b3f4f0d16da4cf204f8705de8399/Controllers/CustomerController.cs