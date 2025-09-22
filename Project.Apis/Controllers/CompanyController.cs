//using AutoMapper;
//using Job.Core.Entities;
//using Job.Core.Repositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Project.Apis.Dto;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Project.Apis.Controllers
//{
  
//    public class CompanyController : BaseApiController
//    {
//        private readonly IGenericRepositories<Company> _companyRepo;
//        private readonly IGenericRepositories<Jobs> _jobsRepo;
//        private readonly IMapper _mapper;

//        public CompanyController(IGenericRepositories<Jobs> JobRepo,
//            IGenericRepositories<Company> CompanyRepo,
//            IMapper mapper)
//        {
//            _jobsRepo = JobRepo;
//            _companyRepo = CompanyRepo;
//           _mapper = mapper;
//        }
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ToReturnCompanyDto>>> GetCAllCompany()
//        {
//            var Company = await _companyRepo.GetAllAsync();
//            var result = _mapper.Map<IEnumerable<Company>, IEnumerable<ToReturnCompanyDto>>(Company);
//            return Ok(result); 

//        }
//        [HttpGet("{Id}")]
//        public async Task<ActionResult<ToReturnCompanyDto>> GetById(int id)
//        {
//            var company = await _companyRepo.GetByIdAsync(id);
//            if(company == null)
//            {
//                return NotFound();
//            }
//            return Ok(_mapper.Map<Company , ToReturnCompanyDto>(company));
//        }
//        [HttpPost]
//        public async Task<ActionResult<Company>> CreateCompany(Company company)
//        {

//            if (company == null)
//            {
//                return BadRequest("Company data is null");
//            }

//            if (string.IsNullOrWhiteSpace(company.CompanyName))
//            {
//                return BadRequest("Company name is required");
//            }
//            var CompanyResult =await _companyRepo.Add(company);
//            return Ok (CompanyResult);

//        }
//    }
//}
