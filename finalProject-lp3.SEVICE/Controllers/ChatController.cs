using Microsoft.AspNetCore.Mvc;
using finalProject_lp3.MODEL;
using finalProject_lp3.BLL;


namespace finalProject_lp3.SERVICE.Controllers
{
    [Route("chat")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpGet(Name = "GetAllChats")]
        public ActionResult<List<Chat>> getAllChats()
        {
            try
            {
                var chats = ChatRepository.getAll();
                if(chats == null)
                {
                    return NotFound();
                }
                return Ok(chats);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/chat/{id}", Name = "GetChatById")]
        public ActionResult<Chat> getChatById(int id)
        {
            try
            {
                var chat = ChatRepository.getById(id);
                if(chat == null)
                {
                    return NotFound();
                }
                return Ok(chat);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getByUserId", Name = "getAllChatsByUser1Id")]
        public ActionResult<List<Chat>> getByUserId(int userId)
        {
            try
            {
                var chats = ChatRepository.getByUserId(userId);
                if(chats == null) { return NotFound(); }
                return Ok(chats);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = "AdicionarChat")]
        public ActionResult<User> addUser(Chat chat)
        {
            try
            {
                Chat c = ChatRepository.addChat(chat);

                return c == null ? NotFound() : Ok(c);

            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/chat/{id}", Name = "DeleteChatById")]
        public ActionResult<User> deleteChat(int id)
        {
            try
            {
                Chat c = ChatRepository.getById(id);
                ChatRepository.removeChat(c);

                Chat _chatNull = ChatRepository.getById(id);
                if (_chatNull == null)
                {
                    return Ok(c);
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
