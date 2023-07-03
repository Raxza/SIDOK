using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Core.Models
{
    public class PoliForDetails : Poli
    {
        public List<DokterHari>? Dokters { get; set; }
    }
}
