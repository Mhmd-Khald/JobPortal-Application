using AutoMapper;
using Job.Core.Entities;
using Job.Core.Repositories;
using Job.Core.Specification;
using Job.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Apis.Dto;
using Project.Apis.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Apis.Controllers
{

    public class JobController : BaseApiController
    {
        private readonly  UserManager<AppUser> _userManager;
        private readonly IGenericRepositories<Jobs> _jobRepo;

        //private readonly IGenericRepositories<Company> _companyRepo;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public JobController(UserManager<AppUser> userManager,
            IGenericRepositories<Jobs> JobRepo,
            StoreDbContext context,
             //IGenericRepositories<Company> CompanyRepo,
            IMapper mapper ,IHttpContextAccessor httpContextAccessor )
        {
            _userManager = userManager;
            _jobRepo = JobRepo;
            //_companyRepo = CompanyRepo;
            _mapper = mapper;
            _context = context;

            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Pagination<JobToReturnDto>>> GetJob([FromQuery]JobParam jobParam )
        {
            var value = _session.GetString("key");
            //var userId = GetUserIdFromToken(value);

            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var Spec = new JobWithCompanySpecification(jobParam);
            var Job = await _jobRepo.GetAllWithSpec(Spec);
            //var Data = _mapper.Map<IEnumerable<Jobs>, IEnumerable<JobToReturnDto>>(Job);
            //var hasUserApplied = await CheckIfUserApplied(userId);

            var data = _mapper.Map<IEnumerable<Jobs>, IEnumerable<JobToReturnDto>>(Job);

            foreach (var jobToReturnDto in data)
            {
                jobToReturnDto.IsCompanyOrNot = 0;
                jobToReturnDto.HasApplied = await CheckIfUserApplied(user.Id, jobToReturnDto.Id);
            }




            var CountSpec = new JobWithFilterForCountSpecification(jobParam);
            var Count = await _jobRepo.GetCountAsync(CountSpec);




            return Ok(new Pagination<JobToReturnDto>(value, data, Count));

        }
   
       
            private async Task<bool> CheckIfUserApplied(string userId, int jobId)
            {
                var userIsApplied = await _context.Application.AnyAsync(app => app.user.Id == userId && app.JobId == jobId);
                return userIsApplied;
            }
        
        [HttpGet("GetCompanyJob")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<JobToReturnDto>>> GetDetails( )
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var data = await _context.jobs.Where(j => j.AppUserId == user.Id).ToListAsync();
            var jobDetails = data.Select(job => new ToReurnJobDetails
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Country = job.Country,
                City = job.City,
                Experience = job.Experience,
                Created=job.Created,
                JobType = job.JobType,
                Position = job.Position,
                Salary=job.Salary,
                Requirement = job.Requirement,
                PictureUrl=user.PictureUrl,
                Skill=job.Skill,
                user = job.User.DisplayName,
                UserId= job.User.Id,
                WorkPlace=job.WorkPlace
            }).ToList();
            return Ok(jobDetails);


        }
    
    


        [HttpGet("{Id}")]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<JobToReturnDto>> GetJobById(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var spec = new JobWithCompanySpecification(id);
            var job = await _jobRepo.GetByIdWithSpec(spec);
            if (job == null)
            {
                return NotFound();
            }

            var jobToReturnDto = _mapper.Map<Jobs, JobToReturnDto>(job);
            jobToReturnDto.IsCompanyOrNot = 0;
            jobToReturnDto.HasApplied = await CheckIfUserApplied(user.Id, jobToReturnDto.Id);

            return Ok(jobToReturnDto);
        
    }
        [HttpGet("{details}/{id}")]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<IEnumerable<ToReurnJobDetails>>> GetDetails( int id)
        {
            var Spec = new JobWithCompanySpecification(id);
            var Job = await _jobRepo.GetByIdWithSpec(Spec);
            if(Job == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Jobs, ToReurnJobDetails>(Job));
        }
        [Authorize(Roles ="company")]
        [HttpPost("CreateJob")]
        public async Task<ActionResult<Jobs>> CreateJob(ToPostJobDto jobDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var job = new Jobs
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
                Position = jobDto.Position,
                JobType = jobDto.JobType,
                Requirement = jobDto.Requirement,
                Created = jobDto.Created,
                Salary = jobDto.Salary,
                disabledJob= jobDto.disabledJob,
                City = jobDto.City,
                WorkPlace=jobDto.WorkPlace,

                Country = jobDto.Country,
                Skill = jobDto.Skill,
                Experience = jobDto.Experience,
                AppUserId = user.Id,
                User = user
            };
            var newjob= await _jobRepo.Add(job);
               return Ok("Job Created Succecfully");



        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="company")]
        public async Task<ActionResult> DeleteJob(int id)
        {
            var job = await _jobRepo.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Remove(job);
            await _context.SaveChangesAsync();

            return Ok("job Deleted Succefully");
        }


    }
}
