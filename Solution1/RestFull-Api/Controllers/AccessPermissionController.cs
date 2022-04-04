using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermissionController : ControllerBase, IDisposable
    {
        public Logic logic = new Logic();
     
        [HttpPut]
        [Route("GetUserAccess")]
        public IActionResult GetAccessToChat(Creditionals creditionals)
        {
            try
            {
                Allow_AccessModel User = logic.Check_User_Access(creditionals);
                if (User == null)
                    return Unauthorized();

                User = logic.UpdateTologin(creditionals);
                return Ok(User);
            }
        
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("LogoutAccess")]
        public IActionResult GetLogOut_AccessToChat(string Username)
        {
            try
            {
                Allow_AccessModel User = logic.CheckIfLogin(Username);
                if (User == null)
                    return NotFound();

                User = logic.UpdateToLogout(Username);
                return Ok(User);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }



        [HttpGet]
        [Route("CheckUser_login/{username}")]
        public IActionResult CheckIf_UserLogin(string username)
        {
            try
            {
                Allow_AccessModel User = logic.CheckIfLogin(username);
                if (User != null && User.status == "Login")
                    return Ok(User);

                return NotFound($"check if {username} property is found in DB");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
