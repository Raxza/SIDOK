using SIDOK.Repository.Interface;
using SIDOK.Service.Interface;

namespace SIDOK.Service
{
    public class Service : IService
    {
        public Service(IDokterRepository dokterRepository, ISpesialisasiRepository spesialisRepository, IPoliRepository poliRepository, IJadwalJagaRepository jadwalJagaRepository)
        {
            Dokter = dokterRepository;
            Spesialisasi = spesialisRepository;
            Poli = poliRepository;
            JadwalJaga = jadwalJagaRepository;
        }
        public IDokterRepository Dokter { get; }
        public ISpesialisasiRepository Spesialisasi { get; }
        public IPoliRepository Poli { get; }
        public IJadwalJagaRepository JadwalJaga { get; }
    }
}