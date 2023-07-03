using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIDOK.Core.Models
{
    public class Spesialisasi
    {
        public int Id { get; set; }
        [Display(Name = "Spesialisasi")]
        public string Nama { get; set; }
        public string Gelar { get; set; }
    }
}
