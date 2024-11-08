using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflis.Notificaciones
{
    public class NotificationHub : Hub
    {
        // Acá agregamos métodos si deseamos gestionar conexiones o eventos específicos del cliente.
        // En este caso, este hub sólo actúa como un punto de recepción de notificaciones desde el servidor,
        // entonces no es necesario definir nada.
    }
}
