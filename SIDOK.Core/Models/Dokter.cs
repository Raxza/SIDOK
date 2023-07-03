using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SIDOK.Core.Models
{
    public class Dokter
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        [Display(Name = "NIP")]
        public string Nip { get; set; }
        [Display(Name = "NIK")]
        public string Nik { get; set; }
        [Display(Name = "Tanggal Lahir")]
        [DataType(DataType.Date)]
        public DateTime Tanggal_Lahir { get; set; }
        [Display(Name = "Tempat Lahir")]
        public string Tempat_Lahir { get; set; }
        [Display(Name = "Jenis Kelamin")]
        public int Jenis_Kelamin { get; set; }
        public Spesialisasi? Spesialisasi { get; set; }
        public List<Poli>? Poli { get; set; }
    }
}