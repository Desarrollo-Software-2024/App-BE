using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Netflis.MonitoreoApi
{
    public class ApiMonitoringAppService : ApplicationService, IApiMonitoringAppService
    {
        private readonly IApiAccessLogRepository _apiAccessLogRepository;

        public ApiMonitoringAppService(IApiAccessLogRepository apiAccessLogRepository)
        {
            _apiAccessLogRepository = apiAccessLogRepository;
        }

        public Task<PagedResultDto<ApiAccessLogDTO>> GetAccessLogsAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApiAccessLogDTO>> GetLogsByEndpointAsync(string endpoint)
        {
            var logs = await _apiAccessLogRepository.GetLogsByEndpointAsync(endpoint);
            return ObjectMapper.Map<List<ApiAccessLog>, List<ApiAccessLogDTO>>(logs);
        }
        public async Task<TotalApiMonitoringStatsDTO> GetApiStatisticsAsync()
        {
            var logs = await _apiAccessLogRepository.GetListAsync();
            return new TotalApiMonitoringStatsDTO
            {
                TotalAccesses = logs.Count,
                AverageResponseTime = logs.Any() ? logs.Average(log => log.ResponseTimeMs) : 0,
                TotalErrors = logs.Count(log => !log.IsSuccessful)
            };
        }
    }

}
