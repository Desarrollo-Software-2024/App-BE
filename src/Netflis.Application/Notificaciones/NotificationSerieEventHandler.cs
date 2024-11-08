using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Netflis.Notificaciones
{
    public class NotificationSerieEventHandler :
    IDistributedEventHandler<SerieUpdatedDTO>,
    IDistributedEventHandler<TemporadaAddedDTO>,
    IDistributedEventHandler<CapituloAddedDTO>,
    ITransientDependency
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationSerieEventHandler(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task HandleEventAsync(SerieUpdatedDTO eventData)
        {
            var message = $"La serie '{eventData.updateTitle}' ha sido actualizada. {eventData.updateType}";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        public async Task HandleEventAsync(TemporadaAddedDTO eventData)
        {
            var message = $"Se ha añadido la temporada {eventData.numeroTemporada} a la serie con ID {eventData.serieId}.";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        public async Task HandleEventAsync(CapituloAddedDTO eventData)
        {
            var message = $"Se ha añadido el capítulo {eventData.capituloNumero}: '{eventData.titulo}' a la temporada con ID {eventData.temporadaId}.";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
