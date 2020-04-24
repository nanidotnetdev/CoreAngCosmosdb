using CoreAngCosmos.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreAngCosmos.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationApiController : ControllerBase
    {
        private IConfiguration _configuration;

        public ConfigurationApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetConfiguration")]
        public AngularConfiguration GetConfiguration()
        {
            return new AngularConfiguration
            {
                ApiUrl = _configuration["API:URL"]
            };
        }
    }
}
