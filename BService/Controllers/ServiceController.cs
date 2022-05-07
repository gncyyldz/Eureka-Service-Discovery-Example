using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public string Get()
            => "B Service is working";
    }
}
