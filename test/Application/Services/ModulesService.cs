using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Querys.ModulesQuerys;
using CQRStest.Infrastucture.Repository;
using MediatR;
using System.Runtime.CompilerServices;

namespace CQRStest.Application.Services
{
    public class ModulesService
    {
        private ModuleRepository _moduleRepository { get; set; }
        private readonly IMediator _mediator;
        public ModulesService(IMediator mediator)
        { 
            _mediator = mediator;
            _moduleRepository = new ModuleRepository(_mediator);
        }


        public async Task<IEnumerable<ModuleDTO>> GetModules()
        {
            var modules = await _moduleRepository.Get();
            return modules;
        }

        public async Task<ModuleDTO> GetModuleById(int id)
        {
            var module = await _moduleRepository.GetById(id);
            return module;
        }

        public async Task<ModuleDTO> CreateModule(ModuleDTO module)
        {
            var moduleResponse = await _moduleRepository.Create(module);
            return moduleResponse;
        }

        public async Task<UpdateModuleDTO> UpdateModule(UpdateModuleDTO module)
        {
            var ModuleUpdate = await _moduleRepository.Update(module);
            return ModuleUpdate;
        }

        public async Task<bool> DeleteModule(int id)
        {
            var IsDeleted = await _moduleRepository.Delete(id);
            return IsDeleted;
        }
    }
}
