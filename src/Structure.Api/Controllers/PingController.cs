using Microsoft.AspNetCore.Mvc;

namespace Structure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Ping")]
        public string Get()
        {
            _logger.LogInformation("Ping success");
            return "Ping success";
        }
    }
}