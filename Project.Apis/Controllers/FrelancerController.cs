using Job.Core.Entities;
using Job.Core.Repositories;
using Job.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Project.Apis.Dto;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Job.Repository.Migrations;
using AutoMapper;

namespace Project.Apis.Controllers
{

    public class FrelancerController : BaseApiController
    {
        private readonly StoreDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepositories<FreelanceJob> _frelanceRepo;
        private readonly IMapper _mapper;

        public FrelancerController(StoreDbContext context, UserManager<AppUser> userManager
            , IGenericRepositories<FreelanceJob> FrelanceRepo , IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _frelanceRepo = FrelanceRepo;
            _mapper = mapper;
        }
        [HttpPost("CreateFreelancer")]
        [Authorize(Roles ="company")]
        public async Task<ActionResult<FreelanceJob>> CreateFreelanceJob(FreelancerJobDto model)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Unauthorized("User not found.");
                }

                var freelanceJob = new FreelanceJob
                {
                    Title = model.Title,
                    ProjectStatue = model.ProjectStatus,
                    TimeToComplet = model.TimeToComplete,
                    Publised = DateTime.UtcNow,
                    ProjectDetails = model.ProjectDetails,
                    RequiredSkills = model.RequiredSkills,
                    Budget = model.Budget,
                    User = user,
                    AppUserId = user.Id

                };

                _context.freelanceJobs.Add(freelanceJob);
                await _context.SaveChangesAsync();

                return Ok("Freelance Job created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the Freelance Job: {ex.Message}");
            }
        }
        [HttpGet("freelancejobs")]
        [Authorize(Roles ="User")]

        public async Task<ActionResult<List<GetFreelancerDto>>> GetFreelanceJobs([FromQuery] string searchTerm = "", [FromQuery] string projectStatus = "")
        {
            try
            {
                var freelanceJobs = await _context.freelanceJobs.Include(j => j.User).ToListAsync();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    freelanceJobs = freelanceJobs.Where(j => j.ProjectDetails.Contains(searchTerm) || j.RequiredSkills.Contains(searchTerm)).ToList();
                }

                if (!string.IsNullOrWhiteSpace(projectStatus))
                {
                    freelanceJobs = freelanceJobs.Where(j => j.ProjectStatue.ToLower() == projectStatus.ToLower()).ToList();
                }

                var freelanceJobDtos = freelanceJobs.Select(j => new GetFreelancerDto
                {
                    id=j.id,
                    Title = j.Title,
                    Budget = j.Budget,
                    ProjectDetails = j.ProjectDetails,
                    ProjectOwner = j.User.DisplayName,
                    pictureUrl = j.User.PictureUrl
                }).ToList();

                return Ok(freelanceJobDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Freelance jobs: {ex.Message}");
            }
        }


        [HttpGet("freelancejobs/{id}")]
        public async Task<ActionResult<GetDetailsOfFreelancedDto>> GetFreelanceJob(int id)
        {
            try
            {
                var freelanceJob = await _context.freelanceJobs
                    .Include(j => j.User)
                    .FirstOrDefaultAsync(j => j.id == id);

                if (freelanceJob == null)
                {
                    return NotFound($"Freelance job with ID {id} not found.");
                }

                var freelanceJobDto = new GetDetailsOfFreelancedDto
                {
                    
                    ProjectStatus = freelanceJob.ProjectStatue,
                    TimeToComplete = freelanceJob.TimeToComplet,
                    Published = freelanceJob.Publised,
                    Budget = freelanceJob.Budget,
                    Title=freelanceJob.Title,
                    ProjectDetails = freelanceJob.ProjectDetails,
                    RequiredSkills = freelanceJob.RequiredSkills,
                    projectOwner = freelanceJob.User.DisplayName,


                };
                return Ok(freelanceJobDto);
            }


            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the freelance job: {ex.Message}");
            }
        }

        [Authorize(Roles ="User")]
        [HttpPost("SendOfferFreelance/{id}")]
        public async Task<ActionResult<Offers>> CreateOffer(int id ,OffersDto model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var job = await _frelanceRepo.GetByIdAsync(id);

            if (user == null || job == null)
            {
                return BadRequest();
            }
            var check = _context.Offers.Where(a => a.AppuserId == user.Id && a.FreelanceJobId == job.id).ToList();
            if (check.Count < 1)
            {
                var mappedApplication = new Offers
                {
                    OrderDetails = model.OfferDetails,
                    OfferValue = model.OfferValue,
                    TimeToRecive = model.TimeToRecive,
                    OfferDate = DateTime.Now,
                    FreelanceJobId = job.id,
                    AppuserId = user.Id,
                    user = user,

                };
                _context.Offers.Add(mappedApplication);
                await _context.SaveChangesAsync();

                return Ok("the Offer Sent Succecfully");
            } 
            else
            

            return BadRequest("An offer has already been sent for this job by this user.");
        }
        [Authorize(Roles ="User")]
        [HttpDelete("offers/{id}")]
        public async Task<ActionResult> DeleteOffer(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var offer = await _context.Offers.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            if (offer.AppuserId != user.Id)
            {
                return Unauthorized();
            }

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        ////   Get Job That Current User sendOffer For it  To Know the details of Job that he send To Compne
        //   [Authorize]
        //   [HttpGet("GetOfferForUser")]
        //   public async Task<ActionResult<ToReturnOfferThatUserSendTo>> GetJobsForUser()
        //   {
        //       var email = User.FindFirstValue(ClaimTypes.Email);
        //       var user = await _userManager.FindByEmailAsync(email);

        //       var jobb = await _context.Offers
        //           .Include(a => a.Jobs)
        //           .Where(a => a.AppuserId == user.Id)
        //           .ToListAsync();

        //       var data = _mapper.Map<IEnumerable<Offers>, IEnumerable<ToReturnOfferThatUserSendTo>>(jobb);

        //       return Ok(data);

        //   }

        [Authorize(Roles ="company")]
        [HttpGet("GetOffersForCompany")]
        public async Task<ActionResult<IEnumerable<ReturnUserSendOfeerForCompany>>> GetApplicantForCompany()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var jobApplications = await _context.Offers
                .Include(app => app.Jobs)
                .Include(app => app.user)
                .Where(app => app.Jobs.AppUserId == user.Id)
                .ToListAsync();

            var applicants = jobApplications.Select(app => new ReturnUserSendOfeerForCompany
            {
                OfferId=app.id,
                OfferDetails= app.OrderDetails,
                UserId= app.user.Id,
                Title = app.Jobs.Title,
                email = app.user.Email,
                PictureUrl = app.user.PictureUrl,
                OfferValue= app.OfferValue,
                TimeToComplete = app.TimeToRecive,
                DateTime = app.OfferDate,
                DisplayName = app.user.DisplayName,
                Jobid = app.FreelanceJobId

            })
                .ToList();

            return Ok(applicants);
        }
    }
}

