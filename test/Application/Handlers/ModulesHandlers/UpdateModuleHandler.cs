using AutoMapper;
using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRStest.Application.Handlers.ModulesHandlers
{
    public class UpdateModuleHandler: IRequestHandler<UpdateModuleCommand, UpdateModuleDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateModuleHandler(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateModuleDTO> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await _context.Modules.FindAsync(request.moduleToUpdate.Id);

            if (module == null)
            {
                return null;
            }
            module.Name = request.moduleToUpdate.Name;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UpdateModuleDTO>(module);
        }
    }
}
