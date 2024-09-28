using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflis.Series
{
    public class CreateUpdateSerieDTO
    {
        public string title { get; set; }
        public string fechaLanzamiento { get; set; }
        public string directores { get; set; }
        public string escritores { get; set; }
        public string elenco { get; set; }
        public string portada { get; set; }
        public string paisOrigen { get; set; }
        public string calificacionImdb { get; set; }
        public string duracion { get; set; }
        public string generos { get; set; }
        public string trama { get; set; }
        public string idioma { get; set; }

    }
}
