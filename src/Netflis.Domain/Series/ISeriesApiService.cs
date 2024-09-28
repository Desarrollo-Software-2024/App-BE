using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflis.Series
{
    public interface ISeriesApiService
    {
        Task <ICollection<SerieDTO>> GetSeriesAsync(string titulo, string genero);
    }
}
