using AutoMapper;
using Netflis.Notificaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectMapping;

namespace Netflis.Series
{
    //Se usa en Notificaciones
    public class OmdbApiService : ITransientDependency
    {
        private readonly HttpClient _httpClient;
        private readonly ISerieAppService _serieManager;
        private readonly IRepository<Serie, int> _serieRepository;
        private readonly IDistributedEventBus _eventBus;
        private readonly IMapper _mapper;

        public OmdbApiService(HttpClient httpClient, ISerieAppService serieManager, IRepository<Serie, int> serieRepository, IDistributedEventBus eventBus)
        {
            _httpClient = httpClient;
            _serieManager = serieManager;
            _serieRepository = serieRepository;
            _eventBus = eventBus;
        }

        public async Task UpdateSerieFromOmdbAsync(string imdbId)
        {
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?i={imdbId}&apikey=f189f7f3");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var omdbSerie = JsonConvert.DeserializeObject<SerieDTO>(content);

            var serie = await _serieRepository.FirstOrDefaultAsync(s => s.ImdbId == imdbId);

            bool isSerieUpdated = false;

            if (serie.title != omdbSerie.title || serie.fechaLanzamiento != omdbSerie.fechaLanzamiento || serie.totalTemporadas != omdbSerie.totalTemporadas)
            {
                serie.title = omdbSerie.title;
                serie.fechaLanzamiento = omdbSerie.fechaLanzamiento;
                serie.totalTemporadas = omdbSerie.totalTemporadas;
                isSerieUpdated = true;
            }
            
            if (isSerieUpdated)
            {
                var mapeoSerie = _mapper.Map<SerieDTO>(serie);

                await _serieManager.UpdateSerieAsync(mapeoSerie);

                await _eventBus.PublishAsync(new SerieUpdatedDTO
                {
                    serieId = serie.ImdbId,
                    updateTitle = serie.title,
                    updateType = "Serie actualizada"
                });
            }
        }
    }
}
