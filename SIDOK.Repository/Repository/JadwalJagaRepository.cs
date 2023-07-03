using Dapper;
using SIDOK.Core.Models;
using SIDOK.Repository.Context;
using SIDOK.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIDOK.Repository.Repository
{
    public class JadwalJagaRepository : IJadwalJagaRepository
    {
        private readonly DapperContext context;

        public JadwalJagaRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task CreateJadwal(JadwalJagaForCreateDto jadwal)
        {
            var query = "INSERT INTO Jadwal_Jaga (Id_Dokter, Id_Poli, Hari) VALUES (@Id_Dokter, @Id_Poli, @Hari)";

            var parameters = new DynamicParameters();

            parameters.Add("Id_Dokter", jadwal.Dokter.Id, DbType.Int32);
            parameters.Add("Id_Poli", jadwal.Id_Poli, DbType.Int32);
            parameters.Add("Hari", jadwal.Hari, DbType.String);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteJadwalByDokter(int id)
        {
            var query = "DELETE FROM Jadwal_Jaga WHERE Id_Dokter = @Id";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task DeleteJadwalByPoli(int id)
        {
            var query = "DELETE FROM Jadwal_Jaga WHERE Id_Poli = @Id";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
