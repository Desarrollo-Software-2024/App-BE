using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Netflis.Series
{
    public class SerieDTO : EntityDto<int>
    {
        public string titulo { get; set; }
        public DateOnly fechaLanzamiento { get; set; }
        public string directores { get; set; }
        public string escritores { get; set; }
        public string elenco { get; set; }
        public string portada { get; set; }
        public string paisOrigen { get; set; }
        public int calificacionImdb { get; set; }
        public int duracion { get; set; }
        public string tipo { get; set; }
    }
}
