using SIDOK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Repository.Interface
{
    public interface ISpesialisasiRepository
    {
        Task<IEnumerable<Spesialisasi>> GetSpesialisasi();
        Task CreateSpesialisasiDokter(int id_dokter, int id_spesialisasi);
        Task UpdateSpesialisasiDokter(int id_dokter, int id_spesialisasi);
        Task DeleteSpesialisasiDokter(int id_dokter);
    }
}
