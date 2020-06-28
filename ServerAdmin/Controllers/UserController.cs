using IServices;
using ServerAdmin.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private IApiUserService userLogic;
        public UserController()
        {
            userLogic = (IApiUserService)Activator.GetObject(
         typeof(IApiUserService), "tcp://127.0.0.1:6969/ApiUserService");
        }

        [Route("{userName}", Name = "GetUserByName")]
        public async Task<IHttpActionResult> GetAsync(string userName)
        {
            await Task.Yield();
            var ret = userLogic.GetUser(userName);
            return Ok(ret);
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

            userLogic.AddUser(newUser);

            return CreatedAtRoute(
                            "GetUserByName",
                            newUser.NickName,
                            $"#{newUser.ToString()}");
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync([FromBody] UserRegisterModel updatedUser)
        {
            await Task.Yield();
            if (updatedUser == null)
            {
                return BadRequest("User can not be empty");
            }
            try
            {
                userLogic.UpdateUser(updatedUser);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, "User was not found in database");
            }
            return Ok("Updated");
        }

    }
}
