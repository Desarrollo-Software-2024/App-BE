using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Netflis.ListaSeguimientos
{
    public interface IListaSeguimientoAppService : IApplicationService
    {
        Task AddSerieAsync(int serieId);
    }
}
