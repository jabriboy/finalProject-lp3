using Microsoft.AspNetCore.Mvc;
using finalProject_lp3.MODEL;
using finalProject_lp3.BLL;


namespace finalProject_lp3.SERVICE.Controllers
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

        [HttpGet("/username/{username}", Name = "GetUserByUsername")]
        public ActionResult<User> getUserByUsername(string username)
        {
            try
            {
                var user = UserRepository.getByUsername(username);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("post", Name = "AdicionarUser")]
        public ActionResult<User> addUser(string username, string password)
        {
            try
            {   User _user = new User();
                _user.Id = UserRepository.getAll().Count();
                _user.Username = username;
                _user.Password = password;
                User u = UserRepository.addUser(_user);

                return u == null ? NotFound() : Ok(u);

            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("verifyLogin", Name = "verifyLogin")]
        public ActionResult<User> verifyLogin(User user)
        {
            try
            {
                var _user = UserRepository.verifyLogin(user);
                if(_user == null) { return NotFound(); }
                return Ok(_user);

            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
