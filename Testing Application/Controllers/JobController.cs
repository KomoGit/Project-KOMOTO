using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingApplication.Authentication;
using TestingApplication.Data;
using TestingApplication.Data_Transfer_Objects;
using TestingApplication.Enums;
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
        public readonly IMapper _mapper;
        public JobController(MyMongoRepository repo,ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _jobService = new(repo);
            _context = context;
        }

        [HttpGet]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<IActionResult> Index()
        {
            List<Job> jobs = await _jobService.GetAsync();

            List<JobDTO>? items = jobs.Select(job => new JobDTO
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
                LocationType = job.WorkLocation,

                MaximumAgeRequirement = job.MaximumAgeRequirement,
                MinimumAgeRequirement = job.MinimumAgeRequirement,
                MinimumExperienceInYears = job.MinimumExperienceInYears,

                MenNeedNotApply = job.MenNeedNotApply,
                WomenNeedNotApply = job.WomenNeedNotApply,
            }).ToList();
            return Ok(items);
        }

        //[HttpGet]
        //[Route("categoryid")]
        ////Not including ("JobCategory") because the channel names are the categories.
        //public IActionResult GetJobsByCategory(int id = 1)
        //{
        //    List<Job>? items = _context.Jobs
        //        .Where(j => j.CategoryId == id && j.ExpirationDate >= DateTime.Today)
        //        .Include("Employer")
        //        .ToList();
        //    return Ok(items);
        //}

        //[HttpGet]
        //[Route("companyid")]
        //public IActionResult GetJobsByCompany(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest("Id cannot be 0");
        //    }
        //    List<JobDTO>? items = _context.Jobs
        //        .Select(job => new JobDTO
        //        {
        //            Id = job.Id,
        //            CategoryId = job.CategoryId,

        //            Title = job.Title,
        //            Description = job.Description,

        //            Employer = job.Employer,
        //            JobCategory = job.JobCategory,

        //            ExpirationDate = job.ExpirationDate,
        //            PublishDate = job.PublishDate,

        //            Link = job.Link,

        //            NumberOfHires = job.NumberOfHires,
        //            NumberOfViews = job.NumberOfViews,

        //            EmploymentType = job.EmploymentType,
        //            LocationType = job.LocationType,

        //            MaximumAgeRequirement = job.MaximumAgeRequirement,
        //            MinimumAgeRequirement = job.MinimumAgeRequirement,
        //            MinimumExperienceInYears = job.MinimumExperienceInYears,

        //            MenNeedNotApply = job.MenNeedNotApply,
        //            WomenNeedNotApply = job.WomenNeedNotApply,
        //        })
        //        .Where(j => j.Employer!.Id == id && j.ExpirationDate < DateTime.Today)
        //        .ToList();
        //    return Ok(items);
        //}

        [HttpGet]
        [Route("companyandcategory")]
        public IActionResult GetJobsByCompanyAndCategory(int id, Category category)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            List<JobDTO>? items = _context.Jobs
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

                    
                    LocationType = job.WorkLocation,

                    MaximumAgeRequirement = job.MaximumAgeRequirement,
                    MinimumAgeRequirement = job.MinimumAgeRequirement,
                    MinimumExperienceInYears = job.MinimumExperienceInYears,

                    MenNeedNotApply = job.MenNeedNotApply,
                    WomenNeedNotApply = job.WomenNeedNotApply,
                })
                .Where(j =>
                j.JobCategory == category &&
                j.ExpirationDate < DateTime.Today)
                .ToList();
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
                //Enums
                JobCategory = data.JobCategory,
                SeniorityLevel = data.SeniorityLevel,
                WorkType = data.EmploymentType,
                WorkLocation = data.LocationType,
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
            try{
                _context.Jobs.Add(job);            
            }catch(Exception e){
                await Console.Out.WriteLineAsync(e.ToString());
            }
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
                    LocationType = job.WorkLocation,

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
