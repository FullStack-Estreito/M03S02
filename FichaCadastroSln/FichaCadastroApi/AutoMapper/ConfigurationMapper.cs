using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.Model;

namespace FichaCadastroApi.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<FichaModel, FichaReadDTO>()
                 .ForMember(dest => dest.FichaComDetalhes, opt => opt.MapFrom(src => src.Detalhes));

            CreateMap<FichaCreateDTO, FichaModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailInformado.ToLower()))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataDeNascimento));

            CreateMap<FichaUpdateDTO, FichaModel>();

            CreateMap<DetalheModel, FichaDetalheReadDTO>();
        }
    }
}
