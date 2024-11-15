using AutoMapper;
using Netflis.Capitulos;
using Netflis.MonitoreoApi;
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

        CreateMap<CreateUpdateSerieDTO, Serie>().ReverseMap();

        CreateMap<Temporada, TemporadaDTO>().ReverseMap();

        CreateMap<Capitulo, CapituloDTO>().ReverseMap();

        //Notificaciones
        CreateMap<CapituloAdded, CapituloAddedDTO>().ReverseMap();
        CreateMap<SerieUpdated, SerieUpdatedDTO>().ReverseMap();
        CreateMap<TemporadaAdded, TemporadaAddedDTO>().ReverseMap();

        CreateMap<ApiAccessLog, ApiAccessLogDTO>().ReverseMap();
        CreateMap<TotalApiMonitoringStats, TotalApiMonitoringStatsDTO>().ReverseMap();

    }
}
