using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.Series 
{
    public class CapituloDTO : EntityDto<int>
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

        //REVISAR, PROBLEMA CON DEPENDENCIA CIRCULAR
        public TemporadaDTO Temp { get; set; }
    }
}
