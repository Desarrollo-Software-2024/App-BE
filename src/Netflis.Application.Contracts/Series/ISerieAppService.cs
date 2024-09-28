using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Netflis.Series
{
    public interface ISerieAppService : ICrudAppService<SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDTO, CreateUpdateSerieDTO>
    {
        Task<ICollection<SerieDTO>> SearchAsync(string? titulo, string? genero); //El ? al final de string permite que el valor sea null
    }
}
