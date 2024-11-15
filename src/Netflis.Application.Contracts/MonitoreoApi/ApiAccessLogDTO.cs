using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.MonitoreoApi
{
    public class ApiAccessLogDTO : EntityDto<int>
    {
        public DateTime RequestTime { get; set; }
        public long ResponseTimeMs { get; set; } // Tiempo de respuesta en milisegundos
        public bool IsSuccessful { get; set; }
        public string Endpoint { get; set; }
        public string ErrorMessage { get; set; }
    }
}
