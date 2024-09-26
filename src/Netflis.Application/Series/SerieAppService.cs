using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Netflis.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDTO, CreateUpdateSerieDTO>, ISerieAppService
    {
        public SerieAppService(IRepository<Serie, int> repository) : base(repository)
        {
        }
    }
}
