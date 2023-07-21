using CQRStest.Application.DTOs.ModulesDTO;
using MediatR;

namespace CQRStest.Infrastucture.Querys.ModulesQuerys
{
    public record GetModuleByIdQuery(int id) : IRequest<ModuleDTO>;
}
