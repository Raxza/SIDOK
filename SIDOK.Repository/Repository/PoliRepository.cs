using Dapper;
using SIDOK.Core.Models;
using SIDOK.Repository.Context;
using SIDOK.Repository.Interface;
using System.Data;

namespace SIDOK.Repository.Repository
{
    public class PoliRepository : IPoliRepository
    {
        private readonly DapperContext context;

        public PoliRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task CreatePoli(PoliForCreateDto poli)
        {
            var query = "INSERT INTO Poli (Nama, Lokasi) VALUES (@Nama, @Lokasi)";

            var parameters = new DynamicParameters();

            parameters.Add("Nama", poli.Nama, DbType.String);
            parameters.Add("Lokasi", poli.Lokasi, DbType.String);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdatePoli(int id, PoliForCreateDto poli)
        {
            var query = "UPDATE Poli SET Nama = @Nama, Lokasi = @Lokasi WHERE Id = @Id";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Nama", poli.Nama, DbType.String);
            parameters.Add("Lokasi", poli.Lokasi, DbType.String);

            using (var connections = context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePoli(int id)
        {
            var query = "DELETE FROM Poli WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Poli>> GetAllPoli()
        {
            var query = "SELECT * FROM Poli";

            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Poli>(query);

                return result.ToList();
            }
        }

        public async Task<PoliForDetails> GetPoliDetails(int id)
        {
            var query = "SELECT Poli.Id, Poli.Nama, Poli.Lokasi, Jadwal_Jaga.Id, Jadwal_Jaga.Hari, Dokter.Id ,Dokter.Nama, Spesialisasi.Id, Spesialisasi.Nama FROM Poli LEFT JOIN Jadwal_Jaga ON Poli.Id = Jadwal_Jaga.Id_Poli LEFT JOIN Dokter ON Jadwal_Jaga.Id_Dokter = Dokter.Id LEFT JOIN Spesialisasi_Dokter ON Dokter.Id = Spesialisasi_Dokter.Id_Dokter LEFT JOIN Spesialisasi ON Spesialisasi_Dokter.Id_Spesialisasi = Spesialisasi.Id WHERE Poli.Id =" + id;

            using (var connection = context.CreateConnection())
            {
                var result = new Dictionary<int, PoliForDetails>();
                await connection.QueryAsync<PoliForDetails, Jadwal_Jaga, DokterHari, Spesialisasi, PoliForDetails>(query,
                    (p, j, d, s) =>
                    {
                        PoliForDetails poli;
                        if (!result.TryGetValue(p.Id, out poli))
                        {
                            result.Add(p.Id, poli = p);
                        }

                        if (poli.Dokters == null)
                            poli.Dokters = new List<DokterHari>();

                        if(s != null)
                        {
                            d.Spesialisasi = s;
                        }

                        if(j != null)
                        {
                            d.Hari = j.Hari;
                            poli.Dokters.Add(d);
                        }

                        return poli;
                    });
                var poli = result.Values.FirstOrDefault();
                return poli;
            }
        }

        public async Task<Poli> GetPoli(int id)
        {
            var query = "SELECT * FROM Poli WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<Poli>(query, new { id });

                return result;
            }
        }
    }
}
