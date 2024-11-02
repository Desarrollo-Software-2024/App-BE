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

namespace TvTracker.Series
{
    public class SerieModificationCheckerWorker : AsyncPeriodicBackgroundWorkerBase
    {

        public SerieModificationCheckerWorker(
                AbpAsyncTimer timer,
                IServiceScopeFactory serviceScopeFactory
            ) : base(
                timer, serviceScopeFactory)
        {
            Timer.Period = 600000; //10 minutos
        }

        protected async override Task DoWorkAsync(
            PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Iniciando: Verificando modificaciones de series...");

            // Ejemplo: obtienes las series modificadas y envías notificaciones si es necesario.
            var modifiedSeries = await CheckSeriesModificationsAsync();

            if (modifiedSeries.Any())
            {
                foreach (var serie in modifiedSeries)
                {

                    Logger.LogInformation($"La serie {serie.title} ha sido actualizada.");

                }
            }

            Logger.LogInformation("Finalizado: Verificación de modificaciones de series.");
        }

        private async Task<List<Serie>> CheckSeriesModificationsAsync()
        {
            // Consultar las series desde la base de datos o API
            var series = await _serieRepository.GetListAsync();

            // Lista para almacenar las series que han sido modificadas
            var modifiedSeries = new List<Serie>();

            // Obtener la fecha actual para comparar con las fechas de modificación
            var currentDate = DateTime.Now;

            foreach (var serie in series)
            {
                // Suponiendo que cada serie tiene una propiedad 'FechaModificacion'
                // que indica la última vez que fue modificada
                if (serie.FechaModificacion != null && serie.FechaModificacion.Value > currentDate.AddDays(-1))
                {
                    // Si la serie ha sido modificada en las últimas 24 horas, la agregamos a la lista
                    modifiedSeries.Add(serie);
                }
            }

            // Devolver la lista de series modificadas
            return modifiedSeries;
        }
    }
}