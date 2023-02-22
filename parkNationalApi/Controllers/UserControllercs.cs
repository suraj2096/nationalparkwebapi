using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parkNationalApi.Models;
using parkNationalApi.Models.ViewModel;
using parkNationalApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserControllercs : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserControllercs(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.isUnique(user.Username);
                if (!isUniqueUser)
                    return BadRequest("User in user");
                var userinfo = _userRepository.Register(user.Username, user.Password);
                if(userinfo == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserVM user)
        {
            var usercheck = _userRepository.Authenticate(user.userName,user.userPassword);
            if(usercheck == null)
            {
                return BadRequest("enter wrong credentials");
            }
            return Ok(usercheck);
        }
    }
}
