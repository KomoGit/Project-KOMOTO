using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingApplication.Data;
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
        public IActionResult Index()
        {
            List<Job>? items = _context.Jobs.Include("JobCategory").Include("Employer").ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/catid")]
        //Not including ("JobCategory") because the channel names are the categories.
        public IActionResult GetJobsByCategory(int id = 1)
        {
            List<Job>? items = _context.Jobs
                .Where(j => j.CategoryId == id)
                .Include("Employer")
                .ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/comid")]
        public IActionResult GetJobsByCompany(int id)
        {
            if(id == 0)
            {
                return BadRequest("Id cannot be 0");
            }//For debug reasons the employer is also included but remove it after.
            List<Job>? items = _context.Jobs
                .Where(j => j.EmployerId == id)
                .Include("JobCategory")
                .Include("Employer")
                .ToList();
            return Ok(items);
        }
    }
}
