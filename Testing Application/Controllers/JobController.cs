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
            List<Job>? items = _context.Jobs.Include("JobCategory").ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/catid")]
        //Not including ("JobCategory") because the channel names are the categories.
        public IActionResult GetSpecificJobs(int id = 1)
        {
            List<Job>? items = _context.Jobs.Where(j => j.CategoryId == id).ToList();
            return Ok(items);
        }
    }
}
