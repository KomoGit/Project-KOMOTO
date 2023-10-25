using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IActionResult Index()
        {
            List<JobDTO>? items = _context.ArchivedJobs
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    CategoryId = job.CategoryId,

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
        [Route("categoryid")]
        //Not including ("JobCategory") because the channel names are the categories.
        public IActionResult GetJobsByCategory(int id = 1)
        {
            List<Job>? items = _context.ArchivedJobs
                .Where(j => j.CategoryId == id && j.ExpirationDate >= DateTime.Today)
                .Include("Employer")
                .ToList();
            return Ok(items);
        }

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
        public IActionResult GetJobsByCompanyAndCategory(int id, int categoryId)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            List<JobDTO>? items = _context.ArchivedJobs
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    CategoryId = job.CategoryId,

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
                .Where(j =>
                //j.Employer!.Id == id &&
                j.CategoryId == categoryId &&
                j.ExpirationDate < DateTime.Today)
                .ToList();
            return Ok(items);
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult GetArchivedJobs()
        {
            List<JobDTO>? items = _context.ArchivedJobs
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    CategoryId = job.CategoryId,

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
                .Where(j => j.ExpirationDate < DateTime.Today)
                .ToList();
            return Ok(items);
        }
    }
}
