using Microsoft.AspNetCore.Mvc;
using SA_W4.Helpers;
using SA_W4.Models;

namespace SA_W4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser confirmation) => _user = confirmation;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var response = _user.GetUsers();
            return CustomResponse.GetResponseByStatus(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel model)
        {
            var response = _user.Login(model);
            return CustomResponse.GetResponseByStatus(response);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel model)
        {
            var response = _user.CreateUser(model);
            return CustomResponse.GetResponseByStatus(response);
        }

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(int idUser, [FromBody] UserModel model)
        {
            model.Id = idUser;
            var response = _user.UpdateUser(model);
            return CustomResponse.GetResponseByStatus(response);
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser(int idUser)
        {
            var response = _user.DeleteUser(idUser);
            return CustomResponse.GetResponseByStatus(response);
        }

        [HttpPost("SaveSession")]
        public IActionResult SaveSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return Ok();
        }

        [HttpGet("GetSession")]
        public IActionResult GetSession(string key)
        {
            var value = HttpContext.Session.GetString(key);
            return Ok(value);
        }

        [HttpGet("RemoveSession")]
        public IActionResult RemoveSession(string key)
        {
            HttpContext.Session.Remove(key);
            return Ok();
        }
    }
}
