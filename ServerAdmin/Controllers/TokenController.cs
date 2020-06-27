using IServices;
using ServerAdmin.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServerAdmin.Controllers
{

    [RoutePrefix("Token")]
    public class TokenController : ApiController
    {
        
        [Route("", Name = "LogIn")]
        [HttpPost]
        public async Task<IHttpActionResult> LoginAsync([FromBody] UserLogInModel user)
        {
            await Task.Yield();
            if (user == null)
            {
                return BadRequest("User can not be empty");
            }
            //Todo call blogic

            var sessionLogic = (ISessionService)Activator.GetObject(
               typeof(ISessionService), "tcp://127.0.0.1:8500/SessionService");
            var token = sessionLogic.CreateToken(user.NickName, user.Password);

            return Ok(token);

            //return CreatedAtRoute(
            //    "GetUserByName",
            //    newUser.UserName,
            //    $"#{newUser.ToString()}");
        }

        //[Route("", Name = "LogOut")]
        //[HttpPost]
        //public async Task<IHttpActionResult> LogOutAsync([FromBody] UserLogOutModel logout)
        //{
        //    await Task.Yield();
        //    if (logout == null)
        //    {
        //        return BadRequest("User can not be empty");
        //    }
        //    //Todo call blogic
        //    string token = "AAAAAAAAAAAAAAA";
        //    return Ok(token);

        //    //return CreatedAtRoute(
        //    //    "GetUserByName",
        //    //    newUser.UserName,
        //    //    $"#{newUser.ToString()}");
        //}



    }
}
