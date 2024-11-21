using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var job = await _jobService.GetAllJobsAsync();
            return Ok(job);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobsById(int id)
        {
            var job = await _jobService.GetJobsByIdAsync(id);
            return Ok(job);
        }
        [HttpGet("minLvl/{minLvl}")]
        public async Task<IActionResult> GetJobsByMinLvl(string minLvl)
        {
            var job = await _jobService.GetJobsByMinLvlAsync(minLvl);
            return Ok(job);
        }
        [HttpGet("maxLvl/{maxLvl}")]
        public async Task<IActionResult> GetJobsByMaxLvl(string maxLvl)
        {
            var job = await _jobService.GetJobsByMaxLvlAsync(maxLvl);
            return Ok(job);
        }
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobDto createJobDto)
        {
            var result = await _jobService.CreateJobAsync(createJobDto);
            return Ok(result);
        }
    }
}
