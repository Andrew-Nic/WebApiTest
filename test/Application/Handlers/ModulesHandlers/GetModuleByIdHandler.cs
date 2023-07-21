using AutoMapper;
using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Infrastucture.Persistence;
using CQRStest.Infrastucture.Querys.ModulesQuerys;
using MediatR;

namespace CQRStest.Application.Handlers.ModulesHandlers
{
    public class GetModuleByIdHandler : IRequestHandler<GetModuleByIdQuery, ModuleDTO>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public GetModuleByIdHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ModuleDTO> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var module = await _appDbContext.Modules.FindAsync(request.id);
            
            if (module == null)
            {
                return null;
            }
            return _mapper.Map<ModuleDTO>(module);
        }
    }
}
