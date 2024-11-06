using Netflis.Series;
using Netflis.Temporadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Netflis.Capitulos
{
    public class Capitulo : Entity<int>
    {
        public int numeroEpisodio { get; set; }
        public string fechaEstreno { get; set; }
        public string titulo { get; set; }
        public string directores { get; set; }
        public string escritores { get; set; }
        public string duracion { get; set; }
        public string resumen { get; set; }

        //Foreign key
        public int temporadaID { get; set; }
        public Temporada Temp { get; set; }
    }
}
