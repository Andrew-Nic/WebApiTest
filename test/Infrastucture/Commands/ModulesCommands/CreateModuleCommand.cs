using CQRStest.Application.DTOs.ModulesDTO;
using MediatR;

namespace CQRStest.Infrastucture.Commands.ModulesCommands
{
    public record CreateModuleCommand(ModuleDTO module) : IRequest<ModuleDTO>;
}
