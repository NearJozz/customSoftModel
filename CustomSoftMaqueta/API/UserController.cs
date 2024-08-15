using CustomSoftMaqueta.Application.User.commands;
using CustomSoftMaqueta.Application.User.DTO;
using CustomSoftMaqueta.Application.User.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomSoftMaqueta.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _sender;
        public UserController(IMediator sender)
        {
            this._sender = sender;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCleanDTO>>> GetAllUsers()
        {
           
            var Users =await this._sender.Send(new GetAllUserCmd { });
            if (Users == null) { 
                return NotFound();
            }
            return Ok(Users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(Guid id)
        {
            var User = await this._sender.Send(new GetUserQuery { Ide=id });
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Boolean>> Post([FromBody] UserDTO user) 
        {
      
            var isCreated = await this._sender.Send(new CreateUserCmd
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });
            if (isCreated)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserCleanDTO>> Put(Guid id,[FromBody] UserUpdateDTO user)
        {
            var updatedUser = await this._sender.Send(new UpdateUserCmd
            {
                Ide = id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });
            return Ok(updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Delete(Guid id)
        {
            var isDeleted = await this._sender.Send(new DeleteUserCmd { Ide = id });
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok(true);
        }
    }
}
