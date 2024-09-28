using AutoMapper;
using Netflis.Series;

namespace Netflis;

public class NetflisApplicationAutoMapperProfile : Profile
{
    public NetflisApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Serie, SerieDTO>();
        CreateMap<CreateUpdateSerieDTO, Serie>();

    }
}
