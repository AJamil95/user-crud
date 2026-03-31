using Microsoft.AspNetCore.Mvc;
using user_crud.Server.Services;

namespace user_crud.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalityService _service;

        public NationalitiesController(INationalityService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _service.GetAll();
            return Ok(list);
        }
    }
}
