using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Netflis.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDTO, CreateUpdateSerieDTO>, ISerieAppService
    {

        private readonly ISeriesApiService _seriesApiService;
        public SerieAppService(IRepository<Serie, int> repository, ISeriesApiService seriesService): base(repository)
        {  _seriesApiService = seriesService; }
            
        public async Task<ICollection<SerieDTO>> SearchAsync(string titulo, string genero)
        {
            return await _seriesApiService.GetSeriesAsync(titulo, genero);
        }
    }

}
