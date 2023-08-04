using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using WebApiCoreBasics.Models.DTO.User;

namespace WebApiCoreBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        { 
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _userService.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(long id)
        {
            return await _userService.GetUserByID(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] AddUserDTO userToAdd)
        {
            return await _userService.CreateUserFromDTO(userToAdd);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] EditUserDTO userToEdit)
        {
            return await _userService.UpdateUserFromDTO(userToEdit);
        }

        [HttpPut("updatepassword")]
        public async Task<bool> Put([FromBody] UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            return await _userService.UpdateUserPassword(updateUserPasswordDTO);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _userService.DeleteUserByID(id);
        }
    }
}
