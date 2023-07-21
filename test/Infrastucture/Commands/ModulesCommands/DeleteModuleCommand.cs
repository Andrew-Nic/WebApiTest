using MediatR;

namespace CQRStest.Infrastucture.Commands.ModulesCommands
{
    public record DeleteModuleCommand(int Id): IRequest<bool>;
}
