using SIDOK.Core.Models;
using SIDOK.Repository.Context;
using SIDOK.Repository.Interface;
using Dapper;
using System.Data;

namespace SIDOK.Repository.Repository
{
    public class DokterRepository : IDokterRepository
    {
        private readonly DapperContext context;
        public DokterRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateDokter(Dokter dokter)
        {
            //int year = int.Parse(DateTime.Now.Year.ToString()) + 3;
            string year = ((DateTime.Now.Year) + 3).ToString();
            //string yearStr = year.ToString();
            string birthdate = dokter.Tanggal_Lahir.ToString("ddMMyy");

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var rnd = new String(stringChars).ToUpper();

            string genNip = year + birthdate + dokter.Jenis_Kelamin + rnd;
            //var query = "INSERT INTO Dokter (Nama, Nip, Nik, Tanggal_Lahir, Tempat_Lahir, Jenis_Kelamin) VALUES (@Nama, @Nip, @Nik, @Tanggal_Lahir, @Tempat_Lahir, @Jenis_Kelamin";

            var query = "INSERT INTO Dokter (Nama, Nip, Nik, Tanggal_Lahir, Tempat_Lahir, Jenis_Kelamin) OUTPUT INSERTED.Id VALUES (@Nama, @Nip, @Nik, @Tanggal_Lahir, @Tempat_Lahir, @Jenis_Kelamin)";

            var parameters = new DynamicParameters();

            parameters.Add("Nama", dokter.Nama, DbType.String);
            parameters.Add("Nip", genNip, DbType.String);
            parameters.Add("Nik", dokter.Nik, DbType.String);
            parameters.Add("Tanggal_Lahir", dokter.Tanggal_Lahir, DbType.Date);
            parameters.Add("Tempat_Lahir", dokter.Tempat_Lahir, DbType.String);
            parameters.Add("Jenis_Kelamin", dokter.Jenis_Kelamin, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                return id;
            }
        }

        public async Task DeleteDokter(int id)
        {
            var query = "DELETE FROM Dokter WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Dokter> GetDokter(int? id)
        {
            //var query = "SELECT * FROM Dokter JOIN Spesialisasi_Dokter ON Dokter.Id = Spesialisasi_Dokter.Id_Dokter JOIN Spesialisasi ON Spesialisasi_Dokter.Id_Spesialisasi = Spesialisasi.Id WHERE Dokter.Id = " + id;

            var query = "SELECT * FROM Dokter JOIN Spesialisasi_Dokter ON Dokter.Id = Spesialisasi_Dokter.Id_Dokter JOIN Spesialisasi ON Spesialisasi_Dokter.Id_Spesialisasi = Spesialisasi.Id LEFT JOIN Jadwal_Jaga ON Dokter.Id = Jadwal_Jaga.Id_Dokter LEFT JOIN Poli ON Jadwal_Jaga.Id_Poli = Poli.Id WHERE Dokter.Id = " + id;
            using (var connection = context.CreateConnection())
            {
                var lookup = new Dictionary<int, Dokter>();
                await connection.QueryAsync<Dokter, Spesialisasi, Jadwal_Jaga, Poli, Dokter>(query,
                    (d, s, j, p) =>
                    {
                        Dokter dokter;
                        if (!lookup.TryGetValue(d.Id, out dokter))
                        {
                            d.Spesialisasi = s;
                            lookup.Add(d.Id, dokter = d);
                        }

                        if (dokter.Poli == null)
                            dokter.Poli = new List<Poli>();

                        if(j != null)
                        {
                            p.Hari = j.Hari;
                            dokter.Poli.Add(p);
                        }

                        return dokter;
                    });
                //var dokter = await connection.QueryAsync<Dokter, Spesialisasi, Dokter>(query,
                //    (dokter, spesialisasi) =>
                //    {
                //        dokter.Spesialisasi = spesialisasi;
                //        return dokter;
                //    });

                //var result = dokter.SingleOrDefault();
                //return result;
                var dokter = lookup.Values.FirstOrDefault();
                return dokter;
            }
        }

        public async Task<IEnumerable<Dokter>> GetDokters()
        {
            var query = @"SELECT Dokter.Id, Dokter.Nama, Dokter.Nip, Dokter.Nik, Dokter.Tanggal_Lahir, Dokter.Tempat_Lahir, Dokter.Jenis_Kelamin, Spesialisasi.Nama
                            FROM Dokter 
                            JOIN Spesialisasi_Dokter 
                            ON Dokter.Id = Spesialisasi_Dokter.Id_Dokter 
                            JOIN Spesialisasi 
                            ON Spesialisasi_Dokter.Id_Spesialisasi = Spesialisasi.Id";

            //var query = "SELECT * FROM Dokter";
            using (var connection = context.CreateConnection())
            {
                var dokters = await connection.QueryAsync<Dokter, Spesialisasi, Dokter>(query,
                    (dokter, spesialisasi) =>
                    {
                        dokter.Spesialisasi = spesialisasi;
                        return dokter;
                    }, splitOn: "Nama");    // splitOn digunakan untuk membatasi antara 2 objek (hanya dari parameter yang ada di query, yg pada kasus ini adalah nama dari spesialisasi)
                                            // dan jika tidak disebutkan, akan otomatis membatasi dengan menggunakan parameter Id

                //var dokters = await connection.QueryAsync<Dokter> (query);
                return dokters.ToList();
            }
        }

        public async Task<IEnumerable<Dokter>> SearchDokter(int id_spesialisasi, int id_poli)
        {
            var query = @"SELECT Dokter.Id, Dokter.Nama, Dokter.Nip, Dokter.Nik, Dokter.Tanggal_Lahir, Dokter.Tempat_Lahir, Dokter.Jenis_Kelamin, Spesialisasi.Nama
                            FROM Dokter 
                            JOIN Spesialisasi_Dokter 
                            ON Dokter.Id = Spesialisasi_Dokter.Id_Dokter 
                            JOIN Spesialisasi 
                            ON Spesialisasi_Dokter.Id_Spesialisasi = Spesialisasi.Id 
                            JOIN Jadwal_Jaga
                            ON Dokter.Id = Jadwal_Jaga.Id_Dokter
                            JOIN Poli
                            ON Jadwal_Jaga.Id_Poli = Poli.Id
                            WHERE Spesialisasi.Id = " + id_spesialisasi + " AND Poli.Id = " + id_poli;

            var parameter = new DynamicParameters();

            using (var connection = context.CreateConnection())
            {
                var dokters = await connection.QueryAsync<Dokter, Spesialisasi, Dokter>(query,
                    (dokter, spesialisasi) =>
                    {
                        dokter.Spesialisasi = spesialisasi;
                        return dokter;
                    }, splitOn: "Nama");

                return dokters.ToList();
            }
        }

        public async Task UpdateDokter(int id, Dokter dokter)
        {
            var query = "UPDATE Dokter SET Nama = @Nama, Nip = @Nip, Nik = @Nik, Tanggal_Lahir = @Tanggal_Lahir, Tempat_Lahir = @Tempat_Lahir, Jenis_Kelamin = @Jenis_Kelamin WHERE Id = @Id";

            string nip1 = dokter.Nip.Substring(0, 4);
            string nip3 = dokter.Nip.Substring(10, 3);
            string birthdate = dokter.Tanggal_Lahir.ToString("ddMMyy");

            string newNip = nip1 + birthdate + nip3;
            var parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Nama", dokter.Nama, DbType.String);
            parameters.Add("Nip", newNip, DbType.String);
            parameters.Add("Nik", dokter.Nik, DbType.String);
            parameters.Add("Tanggal_Lahir", dokter.Tanggal_Lahir, DbType.DateTime);
            parameters.Add("Tempat_Lahir", dokter.Tempat_Lahir, DbType.String);
            parameters.Add("Jenis_Kelamin", dokter.Jenis_Kelamin, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}