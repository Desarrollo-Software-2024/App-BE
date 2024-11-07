using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.Notificaciones
{
    public class CapituloAddedDTO : EntityDto<int>
    {
        public string temporadaId { get; set; }
        public int capituloNumero { get; set; }
        public string titulo { get; set; }
    }
}
