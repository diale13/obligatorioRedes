using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Filters;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        [LogInFilter]
        [Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            await Task.Yield();
            return Ok("Aca devolver una lista de peliculas paginadasss");
        }
        
    }
}
