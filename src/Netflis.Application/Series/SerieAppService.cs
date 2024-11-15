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
    //Esta clase heredaba de ISerieAppService, pero daba error de que no se utilizaba
    public class SerieAppService : CrudAppService<Serie, SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDTO, CreateUpdateSerieDTO>, ISerieAppService
    {

        private readonly ISeriesApiService _seriesApiService;
        private readonly IRepository<Serie, int> _serieRepository;

        public SerieAppService(IRepository<Serie, int> repository, ISeriesApiService seriesService): base(repository)
        {  
            _seriesApiService = seriesService; 
        }
            
        public async Task<ICollection<SerieDTO>> SearchAsync(string titulo, string genero)
        {
            return await _seriesApiService.GetSeriesAsync(titulo, genero);
        }

        public async Task UpdateSerieAsync(Serie serie)
        {
            // Lógica para actualizar la serie en el repositorio
            await _serieRepository.UpdateAsync(serie);
        }

        public Task UpdateSerieAsync(SerieDTO serie)
        {
            throw new NotImplementedException();
        }
    }

}
