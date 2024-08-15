using CustomSoftMaqueta.Application.BigFile.commands;
using CustomSoftMaqueta.Application.BigFile.Queries;
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
    public class BigFileController : ControllerBase
    {
        private readonly IMediator _sender;
        public BigFileController(IMediator sender)
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

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Boolean>> Post(IFormFile file) 
        {
            var command = new GuardarBigFileCmd(file);
            var filePath = await this._sender.Send(command);
            return Ok(new { filePath });

        }
        [HttpGet("/api/[controller]/User/{ide}")]
        public async Task<ActionResult> LeerArchivoUsuario(Guid ide)
        {
            try
            {
                var command = new GetUserFileQuery(ide);
                var result = await this._sender.Send(command);
                return result;
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("/api/[controller]/User/{ide}")]
        public async Task<ActionResult<bool>> AgregaArchivoUsuario(Guid ide, IFormFile file )
        {   

            var command=new GuardarUsuarioBigFileCmd(ide, file);
            var result=await this._sender.Send(command);
            return Ok(new { result });
        }
    }
}
