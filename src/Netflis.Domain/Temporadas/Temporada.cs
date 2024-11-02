using Netflis.Capitulos;
using Netflis.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Netflis.Temporadas
{
    public class Temporada : Entity<int>
    {
        public int numero { get; set; }
        public string titulo { get; set; }
        public string fechaLanzamiento { get; set; }
        public string descripcion { get; set; }

        //Foreign key
        public int serieId { get; set; }
        public Serie Serie { get; set; }
        public ICollection<Capitulo> Capitulos { get; set; }
    }
}
