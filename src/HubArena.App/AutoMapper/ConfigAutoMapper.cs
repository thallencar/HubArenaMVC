using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Models;

namespace HubArena.App.AutoMapper
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<ContatoModel, ContatoViewModel>().ReverseMap();
            CreateMap<EquipamentoModel, EquipamentoViewModel>().ReverseMap();
            CreateMap<EsporteModel, EsporteViewModel>().ReverseMap();
            CreateMap<FuncionarioModel, FuncionarioViewModel>().ReverseMap();
            CreateMap<QuadraModel, QuadraViewModel>().ReverseMap();
            CreateMap<ReservaEquipamentoModel, ReservaEquipamentoViewModel>().ReverseMap();
            CreateMap<ReservaModel, ReservaViewModel>().ReverseMap();
        }
    }
}
