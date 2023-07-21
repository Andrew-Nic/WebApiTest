using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Application.Handlers.ModulesHandlers;
using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Querys.ModulesQuerys;
using CQRStest.Infrastucture.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CQRStest.Infrastucture.Repository
{
    public class ModuleRepository
    {
        private readonly IMediator _mediator;

        public ModuleRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ModuleDTO>> Get()
        {
            var modules = await _mediator.Send(new GetModulesQuery());
            return modules;
        }

        public async Task<ModuleDTO> GetById(int id)
        {
            var module = await _mediator.Send(new GetModuleByIdQuery(id));
            return module;
        }

        public async Task<ModuleDTO> Create(ModuleDTO module)
        {
            var moduleResponse = await _mediator.Send(new CreateModuleCommand(module));
            return moduleResponse;
        }

        public async Task<UpdateModuleDTO> Update(UpdateModuleDTO module)
        {
            var ModuleUpdate = await _mediator.Send(new UpdateModuleCommand(module));
            return ModuleUpdate;
        }

        public async Task<bool> Delete(int id)
        {
            var IsDeleted = await _mediator.Send(new DeleteModuleCommand(id));
            return IsDeleted;
        }
    }
}
