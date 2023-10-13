using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestingApplication.Authentication;
using TestingApplication.Data;
using TestingApplication.Data_Transfer_Objects;
using TestingApplication.Model;

namespace TestingApplication.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public JobController(ApplicationDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IActionResult Index()
        {
            var items = _context.Jobs
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    CategoryId = job.CategoryId,
                    EmployerId = job.EmployerId,

                    Title = job.Title,
                    Description = job.Description,

                    Employer = job.Employer,
                    JobCategory = job.JobCategory,

                    ExpirationDate = job.ExpirationDate,
                    PublishDate = job.PublishDate,
                    
                    Link = job.Link,
                   
                    NumberOfHires = job.NumberOfHires,
                    NumberOfViews = job.NumberOfViews,

                    EmploymentType = job.EmploymentType,
                    LocationType = job.LocationType,
                    
                    MaximumAgeRequirement = job.MaximumAgeRequirement,
                    MinimumAgeRequirement = job.MinimumAgeRequirement,
                    MinimumExperienceInYears = job.MinimumExperienceInYears,

                    MenNeedNotApply = job.MenNeedNotApply,
                    WomenNeedNotApply = job.WomenNeedNotApply,             
                })
                .ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/categoryid")]
        //Not including ("JobCategory") because the channel names are the categories.
        public IActionResult GetJobsByCategory(int id = 1)
        {
            List<Job>? items = _context.Jobs 
                .Where(j => j.CategoryId == id && j.ExpirationDate >= DateTime.Today)
                .Include("Employer")
                .ToList();
            return Ok(items);
        }

        [HttpGet]
        [Route("/api/companyid")]
        public IActionResult GetJobsByCompany(int id)
        {
            if(id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            //For debug reasons the employer is also included but remove it after.
            List<Job>? items = _context.Jobs
                .Where(j => j.EmployerId == id && j.ExpirationDate >= DateTime.Today)
                .Include("JobCategory")
                .Include("Employer")
                .ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/archive")]
        public IActionResult GetArchivedJobs()
        {
            List<Job>? items = _context.Jobs
                .Include("JobCategory")
                .Include("Employer")
                .Where(j => j.ExpirationDate < DateTime.Today)
                .ToList();
            return Ok(items);
        }
    }
}
