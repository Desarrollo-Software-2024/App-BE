using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Netflis.Notificaciones
{
    public class SerieUpdated : EtoBase
    {
        public string serieId { get; set; }
        public string updateTitle { get; set; }
        public string updateType { get; set; }
    }
}
