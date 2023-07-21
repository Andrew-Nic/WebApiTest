using CQRStest.Application.DTOs.ModulesDTO;
using MediatR;

namespace CQRStest.Infrastucture.Querys.ModulesQuerys
{
    public record GetModulesQuery: IRequest<IEnumerable<ModuleDTO>>;
}
