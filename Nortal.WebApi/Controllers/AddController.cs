using Microsoft.AspNetCore.Mvc;

namespace Nortal.WebApi.Controllers
{
    public class AddValues
    {
        public int a;
        public int b;
        public int c;
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] AddValues data)
        {
            var a = data.a;
            var b = data.b;
            var c = data.c;

            return a + b + c;
        }
    }
}