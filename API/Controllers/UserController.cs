using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        #region User Repository
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region User Get
        [HttpGet]
        public IActionResult UserGet()
        {
            var Users = _userRepository.UserSelectAll();
            return Ok(Users);
        }
        #endregion

        #region User Get By ID
        [HttpGet("{id}")]
        public IActionResult UserGetByID(int id)
        {
            var Users = _userRepository.SelectByID(id);
            return Ok(Users);
        }
        #endregion

        #region User Delete
        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            var Users = _userRepository.UserDelete(id);
            return Ok(Users);
        }
        #endregion

        #region User Insert
        [HttpPost]
        public IActionResult UserInsert([FromBody] UserModel User)
        {
            var Users = _userRepository.UserInsert(User);
            return Ok(Users);
        }
        #endregion

        #region User Update
        [HttpPut("{id}")]
        public IActionResult UserUpdate(int id, [FromBody] UserModel User)
        {
            var Users = _userRepository.UserUpdate(id, User);
            return Ok(Users);
        }
        #endregion
    }
}
