using BackgroundJobs.API.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var jobId = BackgroundJob.Enqueue<DeleteProductsJob>(x => x.DoWork());
            return Ok($"Job Id {jobId} foi completado!");
        }
    }
}
