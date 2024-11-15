using Microsoft.EntityFrameworkCore;
using Netflis.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Netflis.MonitoreoApi
{
    public class ApiAccessLogRepository : EfCoreRepository<NetflisDbContext, ApiAccessLog, int>, IApiAccessLogRepository
    {
        public ApiAccessLogRepository(IDbContextProvider<NetflisDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ApiAccessLog>> GetLogsByEndpointAsync(string endpoint)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.ApiAccessLogs
                .Where(log => log.Endpoint == endpoint)
                .ToListAsync();
        }
    }
}
