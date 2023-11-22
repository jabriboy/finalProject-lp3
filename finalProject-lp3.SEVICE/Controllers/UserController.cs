using Microsoft.AspNetCore.Mvc;
using finalProject_lp3.MODEL;
using finalProject_lp3.BLL;


namespace finalProject_lp3.SERVICOS.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet(Name = "GetAllUsers")]
        public ActionResult<List<User>> getAllUsers()
        {
            try
            {
                var users = UserRepository.getAll();
                if(users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/{id}", Name = "GetUserById")]
        public ActionResult<User> getUserById(int id)
        {
            try
            {
                var user = UserRepository.getById(id);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = "AdicionarUser")]
        public ActionResult<User> addUser(User user)
        {
            try
            {
                User u = UserRepository.addUser(user);

                return u == null ? NotFound() : Ok(u);

            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/{id}", Name = "DeleteUserById")]
        public ActionResult<User> deleteUser(int id)
        {
            try
            {
                User u = UserRepository.getById(id);
                UserRepository.removeUser(u);

                User _userNull = UserRepository.getById(id);
                if (_userNull == null)
                {
                    return Ok(u);
                }

                return NotFound();
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
