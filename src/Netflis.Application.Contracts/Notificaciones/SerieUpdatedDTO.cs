using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.Notificaciones
{
    public class SerieUpdatedDTO : EntityDto<int>
    {
        public string serieId { get; set; }
        public string updateTitle { get; set; }
        public string updateType { get; set; }
    }
}
