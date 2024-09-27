using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflis.Series
{
    public class OmdbService : ISeriesApiService
    {
        public async Task<SerieDTO[]> GetSeriesAsync(string titulo, string genero)
        {
            throw new NotImplementedException();
        }
    }
}
