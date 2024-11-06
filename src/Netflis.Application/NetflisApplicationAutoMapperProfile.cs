using AutoMapper;
using Netflis.Capitulos;
using Netflis.Notificaciones;
using Netflis.Series;
using Netflis.Temporadas;

namespace Netflis;

public class NetflisApplicationAutoMapperProfile : Profile
{
    public NetflisApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Serie, SerieDTO>().ReverseMap();
        //CreateMap<SerieDTO, Serie>();

        CreateMap<CreateUpdateSerieDTO, Serie>();

        CreateMap<Temporada, TemporadaDTO>();

        CreateMap<Capitulo, CapituloDTO>();

    }
}
