using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusEyesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArgusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var image = System.IO.File.OpenRead(@"C:\\Users\Omar\source\repos\ArgusEyesApi\wwwroot\Arguseyes\retina.jpg");
            var result = File(image, "image/jpeg");
            return result;
        }
    }
}
//https://localhost:7133/api/Argus