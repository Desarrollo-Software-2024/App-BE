using Netflis.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Netflis.ListaSeguimientos
{
    public class ListaSeguimiento : AggregateRoot<int>
    {
        public List<Serie> Series { get; set; }

        public ListaSeguimiento() { 
         Series = new List<Serie>();
        }
    }
}
