using IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Filters;

namespace ServerAdmin.Controllers
{
    [LogInFilter]
    [RoutePrefix("log")]
    public class LogController : ApiController
    {
        private ILogService logService;
        public LogController()
        {
            logService = (ILogService)Activator.GetObject(
         typeof(ILogService), ApiConfig.LogServiceIP);
        }
              
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            await Task.Yield();
            List<string> rawLogs = logService.GetLog("");
            return Ok(rawLogs);
        }

        [Route("{filter}", Name = "GetLogsByFilter")]
        [HttpGet]
        public async Task<IHttpActionResult> GetMovieAsync(string filter)
        {
            await Task.Yield();
            List<string> rawLogs = logService.GetLog(filter);
            return Ok(rawLogs);
        }

    }
}
