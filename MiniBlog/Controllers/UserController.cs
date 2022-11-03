using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            try
            {
                var newUser = _userService.RegisterUser(user);
                return new CreatedResult($"User/{user.Name}", newUser);
            }
            catch (NullReferenceException e)
            {
                return Conflict(e.Message);
            }

        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPut]
        public ActionResult<User> Update(User user)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(user);
                return Ok(updatedUser);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpDelete]
        public ActionResult Delete(string name)
        {
            try
            {
                _userService.DeleteUser(name);
                return Ok();
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{name}")]
        public ActionResult<User> GetByName(string name)
        {
            try
            {
                var userByFind =  _userService.GetUserByName(name);
                return Ok(userByFind);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}