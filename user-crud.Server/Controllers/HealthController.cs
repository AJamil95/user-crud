using Microsoft.AspNetCore.Mvc;

namespace user_crud.Server.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public HealthController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Healthy", environment = _env.EnvironmentName, utcNow = DateTime.UtcNow });
        }
    }
}
