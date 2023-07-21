using CQRStest.Application.DTOs.ModulesDTO;
using MediatR;

namespace CQRStest.Infrastucture.Commands.ModulesCommands
{
    public record UpdateModuleCommand(UpdateModuleDTO moduleToUpdate) : IRequest<UpdateModuleDTO>;
}
