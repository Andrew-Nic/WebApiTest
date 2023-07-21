using AutoMapper;
using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Domain;
using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Persistence;
using MediatR;

namespace CQRStest.Application.Handlers.ModulesHandlers
{
    public class CreateModuleHandler : IRequestHandler<CreateModuleCommand, ModuleDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateModuleHandler(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ModuleDTO> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var module = _mapper.Map<Module>(request.module);
            _context.Modules.Add(module);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ModuleDTO>(module);
        }
    }
}
