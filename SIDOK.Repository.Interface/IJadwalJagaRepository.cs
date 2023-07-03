using SIDOK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Repository.Interface
{
    public interface IJadwalJagaRepository
    {
        Task CreateJadwal(JadwalJagaForCreateDto jadwal);
        Task DeleteJadwalByDokter(int id_dokter);
        Task DeleteJadwalByPoli(int id_poli);
    }
}
