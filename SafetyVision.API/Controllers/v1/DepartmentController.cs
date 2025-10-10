using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace SafetyVision.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(new List<string> { "TEST" });
        }
    }
}
