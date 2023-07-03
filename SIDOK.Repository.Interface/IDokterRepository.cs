using SIDOK.Core.Models;

namespace SIDOK.Repository.Interface
{
    public interface IDokterRepository
    {
        Task<IEnumerable<Dokter>> GetDokters();
        Task<Dokter> GetDokter(int? id);
        Task<int> CreateDokter(Dokter dokter);
        Task<IEnumerable<Dokter>> SearchDokter(int id_spesialisasi, int id_poli);
        Task UpdateDokter(int id, Dokter dokter);
        Task DeleteDokter(int id);
    }
}