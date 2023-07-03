using Dapper;
using SIDOK.Core.Models;
using SIDOK.Repository.Context;
using SIDOK.Repository.Interface;
using System.Data;

namespace SIDOK.Repository.Repository
{
    public class SpesialisasiRepository : ISpesialisasiRepository
    {
        private readonly DapperContext context;

        public SpesialisasiRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task CreateSpesialisasiDokter(int id_dokter, int id_spesialisasi)
        {
            var query = "INSERT INTO Spesialisasi_Dokter (Id_dokter, Id_spesialisasi) VALUES (@Id_dokter, @Id_spesialisasi)";

            var parameters = new DynamicParameters();

            parameters.Add("Id_dokter", id_dokter, DbType.Int32);
            parameters.Add("Id_spesialisasi", id_spesialisasi, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Spesialisasi>> GetSpesialisasi()
        {
            var query = "SELECT * FROM Spesialisasi";

            using (var connection = context.CreateConnection())
            {
                var spesialisasi = await connection.QueryAsync<Spesialisasi>(query);

                return spesialisasi.ToList();
            }
        }

        public async Task DeleteSpesialisasiDokter(int id_dokter)
        {
            var query = "DELETE FROM Spesialisasi_Dokter WHERE Id_Dokter = @Id_Dokter";
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new {  id_dokter });
            }
        }

        public async Task UpdateSpesialisasiDokter(int id_dokter, int id_spesialisasi)
        {
            var query = "UPDATE Spesialisasi_Dokter SET Id_Spesialisasi = @Id_Spesialisasi WHERE Id_Dokter = @Id_Dokter";

            var parameters = new DynamicParameters();

            parameters.Add("Id_Dokter", id_dokter, DbType.Int32);
            parameters.Add("Id_Spesialisasi", id_spesialisasi, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
