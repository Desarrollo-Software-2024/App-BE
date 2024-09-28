using Netflis.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Netflis.ListaSeguimientos
{
    public class ListaSeguimientoAppService : ApplicationService, IListaSeguimientoAppService
    {
        private readonly IRepository<ListaSeguimiento, int> _listaseguimientoRepository;
        private readonly IRepository<Serie, int> _serieRepository;

        public ListaSeguimientoAppService(IRepository<ListaSeguimiento, int> listaseguimientoRepository, IRepository<Serie, int> serieRepository)
        {
            _listaseguimientoRepository = listaseguimientoRepository;
            _serieRepository = serieRepository;
        }

        public async Task AddSerieAsync(int serieId)
        {
            var listaseguimiento = ((List<ListaSeguimiento>)await _listaseguimientoRepository.GetListAsync()).FirstOrDefault();

            //Si la ListaSeguimiento es nula, la crea y la inserta en el repositorio.
            if (listaseguimiento == null)
            {
                listaseguimiento = new ListaSeguimiento();
                await _listaseguimientoRepository.InsertAsync(listaseguimiento);
            }

            //Método para agregar serie a la lista:
            var serie = await _serieRepository.GetAsync(serieId);
            listaseguimiento.Series.Add(serie);
            await _listaseguimientoRepository.UpdateAsync(listaseguimiento);
        }
    }
}
