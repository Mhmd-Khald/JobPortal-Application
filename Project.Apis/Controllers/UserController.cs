using Job.Core.Entities;
using Job.Core.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Apis.Dto;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Job.Repository.Data;

namespace Project.Apis.Controllers
{
 
    public class UserController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StoreDbContext _context;
        private readonly ISession _session;
        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor , StoreDbContext context)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        [HttpGet("profile/User")]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfileForUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            var userProfile = new UserProfileDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                ProfilePictureUrl = user.PictureUrl,
                city = user.City,
                country = user.Country,
                Bio = user.Bio,
                Education = user.Qualification,
                Cv = user.CVURl,
            };

            return Ok(userProfile);

        }
        [HttpGet("profile/Company")]
        [Authorize]
        public async Task<ActionResult<CompanyProfileDto>> GetProfileForCompany()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            var userProfile = new CompanyProfileDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                ProfilePictureUrl = user.PictureUrl,
                city = user.City,
                country = user.Country,
                Bio = user.Bio,
            };

            return Ok(userProfile);

        }

        [HttpGet("GetUser")]
        //[Authorize(Roles ="company")]
               
        public async Task<ActionResult<List<UserDto>>> GetUsersWithRole([FromQuery] UserParam param) // , string tokenPass
        {
            try
            {
                var value = _session.GetString("key");


                var role = await _roleManager.FindByNameAsync("User");

                if (role == null)
                {
                    return BadRequest($"Role '{"User"}' not found.");
                }

                var users = await _userManager.GetUsersInRoleAsync("User");
                if (!string.IsNullOrWhiteSpace(param.Search))
                {
                    users = users.Where(u => u.Bio.Contains(param.Search)).ToList();
                }
                if (!string.IsNullOrEmpty(param.jobType))
                {
                    users = users.Where(u => u.JobType != null && u.JobType.ToLower() == param.jobType.ToLower()).ToList();
                }
                if (!string.IsNullOrEmpty(param.country))
                {
                    users = users.Where(u => u.Country != null && u.Country.ToLower() == param.country.ToLower()).ToList();

                }
                if (!string.IsNullOrEmpty(param.city))
                {
                    users = users.Where(u => u.City != null && u.City.ToLower() == param.city.ToLower()).ToList();
                }
                //if (!string.IsNullOrEmpty(param.position))
                //{
                //    users = users.Where(u => u.Position != null && u.position.ToLower() == param.position.ToLower()).ToList();
                //}
                if (!string.IsNullOrEmpty(param.experince))
                {
                    users = users.Where(u => u.Experience != null && u.Experience.ToLower() == param.experince.ToLower()).ToList();
                }
                var userDtos = users.Select(u => new UserDto
                {
                    id = u.Id,
                    DisplayName = u.DisplayName,
                    City = u.City,
                    Country = u.Country,
                    CvUrl = u.CVURl,
                    Bio = u.Bio,
                    pictureUrl = u.PictureUrl,
                    //TokenValue = value ,
                    IsCompanyOrNot = 1 /// this is for company 
                }).ToList();

                return Ok(/*userDtos*/ new {  Token=value , Data=userDtos});
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving users: {ex.Message}");
            }

        }


        [Authorize]
        [HttpGet("UserById/{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("company"))
            {
              return Ok( new CompanyProfileDto
              {
                   Bio = user.Bio,
                   Email = user.Email,
                   DisplayName = user.DisplayName,
                   ProfilePictureUrl=user.PictureUrl,
                   city = user.City,
                   country = user.Country,
               });
            }
            if (roles.Contains("User"))
            {
                 return Ok(new UserProfileDto
                 {
                     Email = user.Email,
                     DisplayName = user.DisplayName,
                     ProfilePictureUrl = user.PictureUrl,
                     city = user.City,
                     country = user.Country,
                     Bio = user.Bio,
                     Education = user.Qualification,
                     Cv = user.CVURl

                 });
            }
            return Ok(roles);
        }
        [HttpGet("ratingcomments/{userId}")]
        public async Task<ActionResult<IEnumerable<ToReturnRate>>> GetRatingCommentForUser(string userId)
        {
            try
            {
                // Retrieve all rating comments for the specified user ID
                var ratingComments = await _context.rateUsers
              .Include(rc => rc.Rater)
              .Where(rc => rc.rateeId == userId)
              .Select(rc => new ToReturnRate
              {
                  Comment = rc.Comment ,
                  From =rc.Rater.DisplayName

              })
              .ToListAsync();

                return Ok(ratingComments);
            

            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during retrieval
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpPost("ratingcomments/{rateeId}")]
        public async Task<ActionResult<RateUser>> PostRatingComment(string rateeId, RateUser ratingComment)
        {
            try
            {
                // Get the ID of the currently authenticated user
                var email = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(email);

                // Set the ratee ID to the specified user ID
                ratingComment.rateeId = rateeId;

                // Set the rater ID to the ID of the currently authenticated user
                ratingComment.RaterId = user.Id;

                // Add the new RatingComment object to the database
                _context.rateUsers.Add(ratingComment);
                await _context.SaveChangesAsync();

                return Ok("The Comment Posted Succecfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during insertion
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}

