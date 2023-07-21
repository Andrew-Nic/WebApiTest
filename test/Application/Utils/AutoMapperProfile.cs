using AutoMapper;
using CQRStest.Application.DTOs.ModulesDTO;
using CQRStest.Domain;

namespace CQRStest.Application.Utils
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ModuleDTO, Module>();
            CreateMap<Module, ModuleDTO>();
            CreateMap<UpdateModuleDTO, Module>();
            CreateMap<Module, UpdateModuleDTO>();
        }
    }
}
