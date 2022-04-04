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
    public class ChatController : ControllerBase,IDisposable
    {
        private Logic logic = new Logic();

        [HttpPost]
        [Route("NewMessage")]
        public IActionResult AddNewMessage(ChatModels New_Message)
        {
            try
            {
                ChatModels New_Message_ToDB = logic.AddMessage(New_Message);
                return Ok(New_Message_ToDB);
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);            
            }
        }
 
        [HttpGet]
        [Route("GetAAllMessages")]
        public IActionResult GetAllMessages()
        {
            try
            {
                List<ChatModels> AllMessages = logic.GetAllMessages();
                return Ok(AllMessages);

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
