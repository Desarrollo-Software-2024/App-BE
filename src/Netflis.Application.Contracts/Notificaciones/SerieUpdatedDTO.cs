using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflis.Notificaciones
{
    public class SerieUpdatedDTO
    {
        public string serieId { get; set; }
        public string updateTitle { get; set; }
        public string updateType { get; set; }
    }
}
