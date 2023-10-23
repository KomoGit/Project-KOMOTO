﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingApplication.Authentication;
using TestingApplication.Data;
using TestingApplication.Data_Transfer_Objects;
using TestingApplication.Library.Repository;
using TestingApplication.Model;
using TestingApplication.Services;

namespace TestingApplication.Controllers
{
    [Route("/api/company")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(MyMongoRepository repo)
        {
            _companyService = new CompanyService(repo);
        }

        [HttpGet]
        public async Task<ActionResult<Company>> Get()
        {
            List<Company>? company = await _companyService.GetAsync();
            return Ok(company);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Company>> Get(string id)
        {
            Company? company = await _companyService.GetAsync(id);
            if (company is null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpPost]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public async Task<IActionResult> Post(Company newComp)
        {
            await _companyService.CreateAsync(newComp);
            return NoContent();
        }
        //public readonly ApplicationDbContext _context;
        //public readonly IMapper _mapper;
        //public CompanyController(ApplicationDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
        //[HttpGet]
        //[Route("detailed")]
        //public IActionResult Index()
        //{
        //    List<CompanyDTO>? data = _context.Companies
        //        .Select(c => new
        //        {
        //            CompanyId = c.Id,
        //            CompanyName = c.Name,
        //            CurrentJobs = _context.Jobs
        //                .Where(j => j.EmployerId == c.Id && j.ExpirationDate >= DateTime.Today)
        //                .Select(j => new
        //                {
        //                    JobId = j.Id,
        //                    JobTitle = j.Title,
        //                })
        //                .ToList(),
        //            //Archived Jobs - Date Expired
        //            ArchivedJobs = _context.Jobs
        //                .Where(j => j.EmployerId == c.Id && j.ExpirationDate < DateTime.Today)
        //                .Select(j => new
        //                {
        //                    JobId = j.Id,
        //                    JobTitle = j.Title,
        //                })
        //                .ToList(),
        //        })
        //        .ToList()
        //        .Select(c => new CompanyDTO
        //        {
        //            CompanyId = c.CompanyId,
        //            CompanyName = c.CompanyName,
        //            CurrentJobs = c.CurrentJobs
        //                .Select(j => new JobDTO
        //                {
        //                    Id = j.JobId,
        //                    Title = j.JobTitle,
        //                })
        //                .ToList(),
        //            ArchivedJobs = c.ArchivedJobs
        //                .Select(j => new JobDTO
        //                {
        //                    Id = j.JobId,
        //                    Title = j.JobTitle,
        //                })
        //                .ToList()
        //        })
        //        .ToList();
        //    return Ok(data);
        //}
        //[HttpGet]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        //public IActionResult Company()
        //{
        //    List<CompanyDTO>? items = _context.Companies
        //        .Select(c => new CompanyDTO
        //        {
        //            //CompanyId = c.Id,
        //            CompanyName = c.Name,
        //            CompanyLogoLink = c.CompanyLogoLink,
        //        })
        //        .ToList();
        //    return Ok(items);
        //}
        //[HttpGet]
        //[Route("id")]
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        //public IActionResult CompanyById(string id)
        //{
        //    List<CompanyDTO>? items = _context.Companies
        //        .Select(c => new CompanyDTO
        //        {
        //            CompanyId = c.Id,
        //            CompanyName = c.Name,
        //            CompanyLogoLink = c.CompanyLogoLink,
        //        })
        //        .Where(c => c.CompanyId.Equals(id)).ToList();
        //    return Ok(items);
        //}  
    }
}
