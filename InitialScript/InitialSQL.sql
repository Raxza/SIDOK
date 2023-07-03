CREATE TABLE Dokter(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nama VARCHAR(225),
	Nip VARCHAR(225),
	Nik VARCHAR(225),
	Tanggal_Lahir DATE,
	Tempat_Lahir VARCHAR(225),
	Jenis_Kelamin INT
)

CREATE TABLE Poli(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nama VARCHAR(225),
	Lokasi VARCHAR(225)
)

CREATE TABLE Jadwal_Jaga(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Hari VARCHAR(225),
	Id_Poli BIGINT FOREIGN KEY REFERENCES Poli(Id),
	Id_Dokter BIGINT FOREIGN KEY REFERENCES Dokter(Id)
)

CREATE TABLE Spesialisasi(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Nama VARCHAR(225),
	Gelar VARCHAR(225)
)

CREATE TABLE Spesialisasi_Dokter(
	Id BIGINT IDENTITY(1,1) PRIMARY KEY,
	Id_dokter BIGINT FOREIGN KEY REFERENCES Dokter(Id),
	Id_spesialisasi BIGINT FOREIGN KEY REFERENCES Spesialisasi(Id)
)

INSERT INTO Poli (Nama, Lokasi) VALUES
('Poli Umum', 'Ruang A1101'),
('Poli Penyakit Dalam', 'Ruang A1102'),
('Poli Gigi', 'Ruang A1109');


INSERT INTO Spesialisasi (Gelar, Nama) VALUES
('Sp.PK', 'Spesialis Patologi Klinik'),
('Sp.ParK', 'Spesialis Parasitologi Klinik'),
('Sp.U', 'Spesialis Urologi'),
('Sp.GK', 'Spesialis Gizi Klinik'),
('Sp.A', 'Spesialis Anak'),
('Sp.An', 'Spesialis Anestesiologi dan Terapi Intensif'),
('Sp.B', 'Spesialis Bedah'),
('Sp.BP-RE', 'Spesialis Bedah Plastik Rekonstruksi dan Estetik'),
('Sp.FK', 'Spesialis Farmakologi Klinik'),
('Sp.JP', 'Spesialis Jantung dan Pembuluh Darah'),
('Sp.KG', 'Spesialis Konservasi Gigi'),
('Sp.OT', 'Spesialis Bedah Orthopaedi dan Traumatologi'),
('Sp.PD', 'Spesialis Penyakit Dalam'),
('Sp.S', 'Spesialis Saraf'),
('Sp.Rad', 'Spesialis Radiologi');