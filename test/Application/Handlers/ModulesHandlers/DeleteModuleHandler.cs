using CQRStest.Infrastucture.Commands.ModulesCommands;
using CQRStest.Infrastucture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRStest.Application.Handlers.ModulesHandlers
{
    public class DeleteModuleHandler: IRequestHandler<DeleteModuleCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteModuleHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var alteredRows = await _context.Modules.Where(module => module.Id == request.Id).ExecuteDeleteAsync();
            //var module = await _context.Modules.FindAsync(request.Id);
            if (alteredRows == 0)
            {
                return false;
            }

            //_context.Modules.Remove(module);
            //await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
