using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Netflis.Notificaciones
{
    public class TemporadaAdded : Entity<int>
    {
        public string serieId { get; set; }
        public int numeroTemporada { get; set; }
    }
}
