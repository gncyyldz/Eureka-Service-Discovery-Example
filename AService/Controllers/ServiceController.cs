using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace AService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        readonly DiscoveryHttpClientHandler _discoveryHttpClientHandler;
        public ServiceController(IDiscoveryClient discoveryClient)
        {
            _discoveryHttpClientHandler = new(discoveryClient);
        }
        public async Task<string> GetBService()
        {
            using HttpClient httpClient = new(_discoveryHttpClientHandler, false);
            return await httpClient.GetStringAsync("https://BService/api/service");
        }
    }
}
