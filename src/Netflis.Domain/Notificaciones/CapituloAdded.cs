using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Netflis.Notificaciones
{
    public class CapituloAdded : Entity<int>
    {
        public string temporadaId { get; set; }
        public int capituloNumero { get; set; }
        public string titulo { get; set; }
    }
}
