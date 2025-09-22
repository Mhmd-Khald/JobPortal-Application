using AutoMapper;
using Job.Core.Entities;
using Job.Core.Repositories;
using Job.Repository.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Apis.Dto;
using Project.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Project.Apis.Controllers
{

    public class ApplyJobController : BaseApiController
    {
        private readonly IGenericRepositories<JobApplication> _applyjob;
        private readonly IGenericRepositories<Jobs> _jobRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        private readonly Helper _helper;

        public ApplyJobController(IGenericRepositories<JobApplication> applyjob,
            IGenericRepositories<Jobs> jobRepo,
            UserManager<AppUser> userManager,
            StoreDbContext context,
            IGenericRepositories<JobSeeker> userRepo,
            IMapper mapper 
            , IWebHostEnvironment webHost , Helper helper)
        {
            _applyjob = applyjob;
            _jobRepo = jobRepo;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _webHost = webHost;
            _helper = helper;
        }
        [Authorize (Roles ="User")]
        [HttpPost("Apply/{id}")]
        public async Task<ActionResult<JobApplication>> ApplyForJob(IFormFile file, string message, int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var job = await _jobRepo.GetByIdAsync(id);
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            if (user == null || job == null)
            {
                return BadRequest();
            }
            var check = _context.Application.Where(a => a.AppuserId == user.Id && a.JobId == job.Id).ToList();
            if (check.Count < 1)
            {
              

                    var fileName = Path.GetFileName(/*jobApplicationDto*/file.FileName);
                    var filePath = Path.Combine(_webHost.WebRootPath, "Documentaion", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var cv = $"{Request.Scheme}://{Request.Host}/Documentaion/{fileName}";
                   
                   
                var mappedApplication = new JobApplication
                {
                    DateApplied = DateTime.Now,
                    message = message,
                    CvUrl = cv,
                    JobId = job.Id,
                    AppuserId = user.Id,
                    user = user,

            };

               
                var newApplicant = _context.Application.Add(mappedApplication);
                _context.SaveChanges();
                return Ok("Job application submitted successfully");

            }
            else
                return Ok("you Applyed for this job before");

        }
        //Get Job That Current User Applied For it
        [Authorize(Roles = "User")]
        [HttpGet("GetAllAplicant")]
        public async Task<ActionResult<ToReturnJoThatUserApply>> GetJobsForUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var jobApplications = await _context.Application
         .Include(app => app.Jobs)
             .ThenInclude(job => job.User)
         .Where(a => a.AppuserId == user.Id)
         .ToListAsync();
            var data = _mapper.Map<IEnumerable<JobApplication>, IEnumerable<ToReturnJoThatUserApply>>(jobApplications);

            return Ok(data);
        }
        [HttpDelete("DeleteApplicant/{id}")]
        [Authorize (Roles ="User")]
        public async Task<ActionResult> DeletetforApply(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var Apply = await _context.Application.FindAsync(id);

            if (Apply == null)
            {
                return NotFound();
            }

            if (Apply.AppuserId != user.Id)
            {
                return Unauthorized();
            }


            _context.Application.Remove(Apply);
            _context.SaveChanges();
            return NoContent();
        }

       // Get The User Hwo Apply Fpr Job 
        [Authorize(Roles ="company")]
        [HttpGet("getForCompany")]
        public async Task<ActionResult<IEnumerable<ReturnUserthatAppliedToCompany>>> GetApplicantForCompany()
         {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var jobApplications = await _context.Application
                .Include(app => app.Jobs)
                .Include(app => app.user)
                .Where(app => app.Jobs.AppUserId == user.Id)
                .ToListAsync();

            var applicants = jobApplications.Select(app => new ReturnUserthatAppliedToCompany
            {
                UserId= app.user.Id,
                TitleOfJob = app.Jobs.Title,
                DisplayName = app.user.DisplayName,
                email = app.user.Email,
                DateApplied=app.DateApplied,
                Jobid= app.JobId,
                CvUrl= app.CvUrl,
                PictureUrl= app.user.PictureUrl
                
            })
                .ToList();

            return Ok(applicants);
        }

    }
}
