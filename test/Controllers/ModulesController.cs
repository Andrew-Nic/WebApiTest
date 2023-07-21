using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Application.Services;
using CQRStest.Domain;
using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Persistence;
using CQRStest.Infrastucture.Querys.ModulesQuerys;
using CQRStest.Infrastucture.Repository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;
using System.Reflection;
using System.Security.Claims;

namespace CQRStest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        private ModulesService _moduleService { get; set; }
        private LoginService _loginService { get; set; }


        public ModulesController(IMediator mediator, AppDbContext context)
        {
            _context = context;
            _mediator = mediator;
            _moduleService = new ModulesService(_mediator);
            _loginService = new LoginService(_context);
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<ModuleDTO>>> GetModules()
        {
            var modules = await _moduleService.GetModules();
            return Ok(modules);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<ActionResult<ModuleDTO>> GetModuleById([FromRoute] int id)
        {
            var module = await _moduleService.GetModuleById(id);

            if (module == null)
            {
                return NotFound();
            }
            return Ok(module);
        }

        [HttpPost("[Action]")]
        
        public async Task<ActionResult<ModuleDTO>> CreateModule(ModuleDTO module)
        {
            var moduleCreated = await _moduleService.CreateModule(module);
            if (moduleCreated == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(moduleCreated);
        }

        [HttpPut("[Action]")]
        public async Task<ActionResult<UpdateModuleDTO>> UpdateModule(UpdateModuleDTO module)
        {
            var ModuleUpdate = await _moduleService.UpdateModule(module);
            if (ModuleUpdate == null)
            {
                return NotFound();
            }
            return Ok(ModuleUpdate);
        }

        [HttpDelete("[Action]/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteModule([FromRoute] int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = _loginService.ValidToken(identity);
            if (!rToken.success) return rToken;

            User user = rToken.result;

            if (user.PermissionId != 1) 
            {
                return Unauthorized();
            }

            var IsDeleted = await _moduleService.DeleteModule(id);
            if (!IsDeleted)
            {
                return NotFound("No se encontro para eliminar");
            }
            return Ok(IsDeleted);
        }




    }
}
