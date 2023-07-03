using SIDOK.Repository.Interface;

namespace SIDOK.Service.Interface
{
    public interface IService
    {
        IDokterRepository Dokter { get; }
        ISpesialisasiRepository Spesialisasi { get; }
        IPoliRepository Poli { get; }
        IJadwalJagaRepository JadwalJaga { get; }
    }
}