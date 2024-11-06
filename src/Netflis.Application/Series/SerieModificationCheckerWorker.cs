using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;
using Volo.Abp.Users;
using Volo.Abp.Domain.Repositories;
using Netflis.Series;
using System.Threading;
using Microsoft.Extensions.Hosting;

namespace TvTracker.Series
{
    public class SerieUpdateBackgroundService : BackgroundService //AsyncPeriodicBackgroundWorkerBase
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SerieUpdateBackgroundService> _logger;
        private readonly TimeSpan _updateInterval = TimeSpan.FromMinutes(15); // Intervalo de actualización

        public SerieUpdateBackgroundService(IServiceProvider serviceProvider, ILogger<SerieUpdateBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Iniciando actualización periódica de series...");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var omdbApiService = scope.ServiceProvider.GetRequiredService<OmdbApiService>();
                    var serieRepository = scope.ServiceProvider.GetRequiredService<IRepository<Serie, int>>();

                    var series = await serieRepository.GetListAsync();

                    foreach (var serie in series)
                    {
                        await omdbApiService.UpdateSerieFromOmdbAsync(serie.ImdbId); // Actualizar desde OMDb
                    }
                }

                _logger.LogInformation("Actualización periódica de series completada.");

                await Task.Delay(_updateInterval, stoppingToken);
            }
        }
    }
}