using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.Series
{
    public class TemporadaDTO : EntityDto<int>
    {
        public int numero { get; set; }
        public string titulo { get; set; }
        public string fechaLanzamiento { get; set; }
        public string descripcion { get; set; }

        //Foreign key
        public int serieId { get; set; }

        //REVISAR, PROBLEMA CON DEPENDENCIA CIRCULAR
        public SerieDTO Serie { get; set; }
        public ICollection<CapituloDTO> Capitulos { get; set;} 
    }
}
