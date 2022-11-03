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
        private IArticleStore articleStore;
        private IUserStore userStore;
        private UserService userService;
        public UserController(IArticleStore articleStore, IUserStore userStore, UserService userService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.userService = userService;
        }
        [HttpPost]
        public ActionResult<User> Register(User user)
        {
           return Created("", userService.Register(user));
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(userService.GetAll());
        }

        [HttpPut]
        public ActionResult<User> Update(User user)
        {
            var foundUser = userService.Update(user);
            return Ok(foundUser);
        }

        [HttpDelete]
        public ActionResult<User> Delete(string name)
        {
            return Ok(userService.Delete(name));
        }

        [HttpGet("{name}")]
        public ActionResult<User> GetByName(string name)
        {
            return Ok(userService.GetByName(name));
        }
    }
}