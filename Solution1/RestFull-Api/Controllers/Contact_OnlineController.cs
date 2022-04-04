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
    public class Contact_OnlineController : ControllerBase
    {
        private Logic logic = new Logic();

        [HttpGet]
        [Route("GetAllContacts")]
        public IActionResult GetAllcontactsUsers()
        {
            try
            {
                List<Contact_Now_Model> UsersOnline = logic.GetAllUsers();
                return Ok(UsersOnline);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);               
            }
     
        }

        [HttpPost]
        [Route("NewContactOnline")]
        public IActionResult AddNewContactOnline(Contact_Now_Model New_Online_User)
        {
            try
            {
                Contact_Now_Model user = logic.New_UserTo_Online(New_Online_User);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        [HttpPut]
        [Route("UpdateIfType")]
        public IActionResult UpdateIfUserType(string firstname)
        {
            try
            {
                Contact_Now_Model user = logic.FindUserContact(firstname);
                if (user == null)
                    return NotFound();

                user = logic.UpdateIfType(firstname);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPut]
        [Route("UpdateIfNotType")]
        public IActionResult UpdateIfUserNotType(string firstname)
        {
            try
            {
                Contact_Now_Model user = logic.FindUserContact(firstname);
                if (user == null)
                    return NotFound();

                user = logic.UpdateIfNotType(firstname);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
