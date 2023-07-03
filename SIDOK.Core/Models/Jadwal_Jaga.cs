using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Core.Models
{
    public class Jadwal_Jaga
    {
        public int Id {  get; set; }
        public string Hari { get; set; }
        public int Id_Poli { get; set; }
        public int Id_Dokter { get; set; }
    }
}
