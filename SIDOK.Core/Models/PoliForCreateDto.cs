using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Core.Models
{
    public class PoliForCreateDto
    {
        [Required(ErrorMessage = "Field Nama is required")]
        public string Nama { get; set; }

        [Required(ErrorMessage = "Field Lokasi is required")]
        public string Lokasi { get; set; }
    }
}
