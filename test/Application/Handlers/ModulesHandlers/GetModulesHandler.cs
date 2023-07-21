using AutoMapper;
using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Infrastucture.Persistence;
using CQRStest.Infrastucture.Querys.ModulesQuerys;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRStest.Application.Handlers.ModulesHandlers
{
    public class GetModulesHandler : IRequestHandler<GetModulesQuery, IEnumerable<ModuleDTO>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetModulesHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ModuleDTO>> Handle(GetModulesQuery request, CancellationToken cancellationToken)
        {
            var modules = await _appDbContext.Modules.AsNoTracking().ToListAsync(cancellationToken);

            return modules.Select(module => _mapper.Map<ModuleDTO>(module));
        }
    }
}
