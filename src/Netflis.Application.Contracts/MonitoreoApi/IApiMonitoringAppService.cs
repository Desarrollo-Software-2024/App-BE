using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Netflis.MonitoreoApi
{
    public interface IApiMonitoringAppService : IApplicationService
    {

        Task<PagedResultDto<ApiAccessLogDTO>> GetAccessLogsAsync(PagedAndSortedResultRequestDto input);
        Task<List<ApiAccessLogDTO>> GetLogsByEndpointAsync(string endpoint);
        Task<TotalApiMonitoringStatsDTO> GetApiStatisticsAsync();
    }
}
