using ServerAdmin.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {

        [Route("{userName}", Name = "GetUserByName")]
        public async Task<IHttpActionResult> GetAsync(string userName)
        {
            await Task.Yield();
            return Ok("Aca devolver un modelo de usuario que tenga una lista de peliculas");
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] UserRegisterModel newUser)
        {

            await Task.Yield();
            if (newUser == null)
            {
                return BadRequest("User can not be empty");
            }
            //Todo call blogic

            return Ok(newUser);

            return CreatedAtRoute(
                "GetUserByName",
                newUser.UserName,
                $"#{newUser.ToString()}");
        }


    }
}
