﻿using Microsoft.AspNetCore.Mvc;
using TestingApplication.Data;

namespace TestingApplication.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : Controller
    {
        public readonly ApplicationDbContext _context;
        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Jobs.ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("/api/software")]
        public IActionResult GetDeveloperJobs()
        {
            var items = _context.Jobs.Where(j => j.CategoryId == 2).ToList();
            return Ok(items);
        }
    }
}
