using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Netflis.MonitoreoApi
{
    public class ApiAccessLog : AuditedAggregateRoot<int>
    {
        public DateTime RequestTime { get; set; }
        public long ResponseTimeMs { get; set; } // Tiempo de respuesta en milisegundos
        public bool IsSuccessful { get; set; }
        public string Endpoint { get; set; }
        public string ErrorMessage { get; set; }

        // Constructor vacío para Entity Framework
        protected ApiAccessLog() { }

        public ApiAccessLog(DateTime requestTime, long responseTimeMs, bool isSuccessful, string endpoint, string errorMessage = null)
        {
            RequestTime = requestTime;
            ResponseTimeMs = responseTimeMs;
            IsSuccessful = isSuccessful;
            Endpoint = endpoint;
            ErrorMessage = errorMessage;
        }
    }
}
