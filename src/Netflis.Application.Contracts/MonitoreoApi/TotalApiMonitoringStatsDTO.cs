using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Netflis.MonitoreoApi
{
    public class TotalApiMonitoringStatsDTO : EntityDto<int>
    {
        public int TotalAccesses { get; set; }
        public double AverageResponseTime { get; set; } // Promedio en ms
        public int TotalErrors { get; set; }
    }
}
