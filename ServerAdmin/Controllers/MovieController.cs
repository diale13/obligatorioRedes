using System.Threading.Tasks;
using System.Web.Http;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            await Task.Yield();
            return Ok("Aca devolver una lista de peliculas paginadasss");
        }
        
    }
}
