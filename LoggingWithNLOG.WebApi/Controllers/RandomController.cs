using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;

namespace LoggingWithNLOG.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private static ILogger<RandomController> _logger;
        public RandomController(ILogger<RandomController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public void Get()
        {
            _logger.LogInformation("Requested a Random API");
            int count;
            try
            {
                for (count = 0; count <= 5; count++)
                {
                    if (count == 3)
                    {
                        throw new Exception("Random Exception Occured");
                    }
                    else
                    {
                        _logger.LogInformation("Iteration Count is {iteration}", count);
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Exception Caught");
            }
        }
    }
}