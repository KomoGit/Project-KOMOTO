using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingApplication.Data;
using TestingApplication.Data_Transfer_Objects;

namespace TestingApplication.Controllers
{
    [Route("/api/company")]
    [ApiController]
    public class CompanyController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<CompanyDTO>? data = _context.Companies
                .Select(c => new
                {
                    CompanyId = c.Id,
                    CompanyName = c.Name,
                    //Active Jobs
                    CurrentJobs = _context.Jobs
                        .Where(j => j.EmployerId == c.Id && j.ExpirationDate >= DateTime.Today)
                        .Select(j => new
                        {
                            JobId = j.Id,
                            JobTitle = j.Title,
                        })
                        .ToList(),
                        //Archived Jobs - Date Expired
                        ArchivedJobs = _context.Jobs
                        .Where(j => j.EmployerId == c.Id && j.ExpirationDate < DateTime.Today)
                        .Select(j => new
                        {
                            JobId = j.Id,
                            JobTitle = j.Title,
                        })
                        .ToList(),
                })
                .ToList()
                .Select(c => new CompanyDTO
                {
                    CompanyId = c.CompanyId,
                    CompanyName = c.CompanyName,
                    CurrentJobs = c.CurrentJobs
                        .Select(j => new JobDTO
                        {
                            Id = j.JobId,
                            Title = j.JobTitle,
                        })
                        .ToList(),
                    ArchivedJobs = c.ArchivedJobs
                        .Select(j => new JobDTO
                        {
                            Id = j.JobId,
                            Title = j.JobTitle,
                        })
                        .ToList()
                })
                .ToList();
            return Ok(data);
        }
    }
}
