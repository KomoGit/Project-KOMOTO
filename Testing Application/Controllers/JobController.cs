using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingApplication.Authentication;
using TestingApplication.Data;
using TestingApplication.Data_Transfer_Objects;
using TestingApplication.Library.Repository;
using TestingApplication.Model;
using TestingApplication.Services;

namespace TestingApplication.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : Controller
    {
        public readonly ApplicationDbContext _context;

        private readonly JobService _jobService;
        private readonly CompanyService _companyService;

        public readonly IMapper _mapper;
        public JobController(MyMongoRepository repo,ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _jobService = new(repo);
            _companyService = new(repo);
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Job> jobs = await _jobService.GetAsync();
            List<Company>? companies = await _companyService.GetAsync();


            List<JobDTO>? items = jobs.Select(job => new JobDTO
            {
                Id = job.Id,

                Title = job.Title,
                Description = job.Description,

                Employer = companies.Where(c => c.Id.Equals(job.EmployerId)).First(),
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
            }).ToList();
            return Ok(items);
        }

        [HttpPost]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        [Route("create")]
        public async Task<IActionResult> CreateJob([FromForm]JobCreateDTO data)
        {
            Job newJob = new()
            {
                //Basic Data
                Title = data.Title,
                Description = data.Description,
                EmployerId = data.EmployerId,
                Link = data.Link,
                //Salary
                MaxSalary = data.MaxSalary,
                MinSalary = data.MinSalary,
                //Age
                MinimumAgeRequirement = data.MinimumAgeRequirement,
                MaximumAgeRequirement = data.MaximumAgeRequirement,
                //Enums
                JobCategory = data.JobCategory,
                JobLevels = data.JobLevels,
                EmploymentType = data.EmploymentType,
                LocationType = data.LocationType,
                //Dates
                PublishDate = data.PublishDate,
                ExpirationDate = data.ExpirationDate,
            };
            try
            {
                await _jobService.CreateAsync(newJob);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        [Route("archive")]
        public async Task<IActionResult> ArchiveJob(string id) 
        {
            //MongoDb - > SQL Server
            List<Job>? jobs = await _jobService.GetAsync();
            Job? job = jobs.Where(j => j.Id == id).First();

            _context.Jobs.Add(job);
            await _jobService.RemoveAsync(job.Id);

            _context.SaveChanges();
            return Ok($"{job.Id} - {job.Title} Sucessfully archived");
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult GetArchivedJobs()
        {
            List<JobDTO>? items = _context.Jobs
                .Where(j => j.ExpirationDate < DateTime.Today)
                .Select(job => new JobDTO
                {
                    Id = job.Id,

                    Title = job.Title,
                    Description = job.Description,

                    Employer = job.Employer,
                    JobCategory = job.JobCategory,

                    ExpirationDate = job.ExpirationDate,
                    PublishDate = job.PublishDate,

                    Link = job.Link,

                    NumberOfHires = job.NumberOfHires,
                    NumberOfViews = job.NumberOfViews,


                    //EmploymentType = job.SeniorityLevel,
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
    }
}
