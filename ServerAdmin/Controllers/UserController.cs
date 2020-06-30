using IServices;
using ServerAdmin.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Filters;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private readonly IApiUserService userLogic;
        public UserController()
        {
            userLogic = (IApiUserService)Activator.GetObject(
         typeof(IApiUserService), "tcp://127.0.0.1:6969/ApiUserService");
        }

        [Route("{userName}", Name = "GetUserByName")]
        public async Task<IHttpActionResult> GetAsync(string userName)
        {
            await Task.Yield();
            var created = userLogic.GetUser(userName);
            var model = new UserRetModel(created);
            return Ok(model);
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] UserCompleteModel newUser)
        {
            await Task.Yield();
            if (newUser == null)
            {
                return BadRequest("User can not be empty");
            }
            userLogic.AddUser(newUser.ToEntity());

            return Content(HttpStatusCode.Created, $"User created {newUser}");
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync([FromBody] UserCompleteModel updatedUser)
        {
            await Task.Yield();
            if (updatedUser == null)
            {
                return BadRequest("User can not be empty");
            }
            var wasUpdated = userLogic.UpdateUser(updatedUser.ToEntity());
            if (!wasUpdated)
            {
                return Content(HttpStatusCode.NotFound, "User was not found in database");
            }
            return Ok("Updated");
        }


        [LogInFilter]
        [HttpPut]
        public async Task<IHttpActionResult> Delete([FromBody] UserLogInModel userToDelete)
        {
            await Task.Yield();
            if (userToDelete == null)
            {
                return BadRequest("User can not be empty");
            }
            var wasDeleted = userLogic.DeleteUser(userToDelete.NickName, userToDelete.Password);
            if (!wasDeleted)
            {
                return Content(HttpStatusCode.NotFound, "User was not found in database");
            }
            return Ok("Deleted");
        }


    }
}
