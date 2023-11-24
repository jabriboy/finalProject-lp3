using Microsoft.AspNetCore.Mvc;
using finalProject_lp3.MODEL;
using finalProject_lp3.BLL;


namespace finalProject_lp3.SERVICE.Controllers
{
    [Route("message")]
    [ApiController]
    public class MessageController : Controller
    {

        [HttpGet(Name = "getAll")]
        public ActionResult<Message> getAll()
        {
            try
            {
                var message = MessagesRepository.getAll();
                return message == null ? NotFound() : Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/message/{id}", Name = "GetMessageById")]
        public ActionResult<Message> getMessageById(int id)
        {
            try
            {
                var message = MessagesRepository.getById(id);
                if (message == null)
                {
                    return NotFound();
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/getAllInChat/{id}", Name = "GetAllMessagesInChatById")]
        public ActionResult<List<Message>> getAllMessagesInChat(int id)
        {
            try
            {
                var messages = MessagesRepository.getAllMessagesInChat(id);
                return messages == null ? NotFound() : Ok(messages);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost(Name = "AdicionarMessage")]
        public ActionResult<Message> addMessage(Message message)
        {
            try
            {
                Message m = MessagesRepository.addMessage(message);

                return m == null ? NotFound() : Ok(m);

            } catch(Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete("/message/{id}", Name = "DeleteMessageById")]
        public ActionResult<Message> deleteMessage(int id)
        {
            try
            {
                Message m = MessagesRepository.getById(id);
                MessagesRepository.removeMessage(m);

                Message _messageNull = MessagesRepository.getById(id);
                if (_messageNull == null)
                {
                    return Ok(m);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
