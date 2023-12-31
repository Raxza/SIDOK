USE [master]
GO
/****** Object:  Database [SIDOK]    Script Date: 5/25/2023 5:17:50 AM ******/
CREATE DATABASE [SIDOK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SIDOK', FILENAME = N'C:\Users\Lenovo\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MyLocalDB\SIDOK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SIDOK_log', FILENAME = N'C:\Users\Lenovo\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MyLocalDB\SIDOK.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SIDOK] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIDOK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SIDOK] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [SIDOK] SET ANSI_NULLS ON 
GO
ALTER DATABASE [SIDOK] SET ANSI_PADDING ON 
GO
ALTER DATABASE [SIDOK] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [SIDOK] SET ARITHABORT ON 
GO
ALTER DATABASE [SIDOK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SIDOK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SIDOK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SIDOK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SIDOK] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [SIDOK] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [SIDOK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SIDOK] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [SIDOK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SIDOK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SIDOK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SIDOK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SIDOK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SIDOK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SIDOK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SIDOK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SIDOK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SIDOK] SET RECOVERY FULL 
GO
ALTER DATABASE [SIDOK] SET  MULTI_USER 
GO
ALTER DATABASE [SIDOK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SIDOK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SIDOK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SIDOK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SIDOK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SIDOK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SIDOK] SET QUERY_STORE = OFF
GO
USE [SIDOK]
GO
/****** Object:  Table [dbo].[Dokter]    Script Date: 5/25/2023 5:17:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dokter](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](225) NULL,
	[Nip] [varchar](225) NULL,
	[Nik] [varchar](225) NULL,
	[Tanggal_Lahir] [date] NULL,
	[Tempat_Lahir] [varchar](225) NULL,
	[Jenis_Kelamin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jadwal_Jaga]    Script Date: 5/25/2023 5:17:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jadwal_Jaga](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Hari] [varchar](225) NULL,
	[Id_Poli] [bigint] NULL,
	[Id_Dokter] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poli]    Script Date: 5/25/2023 5:17:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poli](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](225) NULL,
	[Lokasi] [varchar](225) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spesialisasi]    Script Date: 5/25/2023 5:17:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spesialisasi](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nama] [varchar](225) NULL,
	[Gelar] [varchar](225) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spesialisasi_Dokter]    Script Date: 5/25/2023 5:17:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spesialisasi_Dokter](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Dokter] [bigint] NULL,
	[Id_Spesialisasi] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dokter] ON 

INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (2, N'Raja', N'2026250300000', N'081314651781', CAST(N'2000-03-25' AS Date), N'Jakarta', 1)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (3, N'Kumi', N'2026260400001', N'081314651781', CAST(N'2000-04-26' AS Date), N'Bandung', 2)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (10007, N'test', N'202330802181J', N'123', CAST(N'2018-02-08' AS Date), N'Bandung', 1)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (10008, N'test2', N'202330408221MQ', N'123', CAST(N'2022-08-04' AS Date), N'Pontianak', 1)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (10009, N'test3', N'2026180224322', N'123', CAST(N'2024-02-18' AS Date), N'Jakarta', 2)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (10010, N'test4', N'20261605241ZG', N'123', CAST(N'2024-05-16' AS Date), N'Jakarta', 1)
INSERT [dbo].[Dokter] ([Id], [Nama], [Nip], [Nik], [Tanggal_Lahir], [Tempat_Lahir], [Jenis_Kelamin]) VALUES (10011, N'test5', N'20261604212GL', N'123', CAST(N'2021-04-16' AS Date), N'Jakarta', 2)
SET IDENTITY_INSERT [dbo].[Dokter] OFF
GO
SET IDENTITY_INSERT [dbo].[Jadwal_Jaga] ON 

INSERT [dbo].[Jadwal_Jaga] ([Id], [Hari], [Id_Poli], [Id_Dokter]) VALUES (1, N'Senin', 2, 2)
INSERT [dbo].[Jadwal_Jaga] ([Id], [Hari], [Id_Poli], [Id_Dokter]) VALUES (2, N'Kamis', 3, 2)
INSERT [dbo].[Jadwal_Jaga] ([Id], [Hari], [Id_Poli], [Id_Dokter]) VALUES (10002, N'Senin', 2, 2)
INSERT [dbo].[Jadwal_Jaga] ([Id], [Hari], [Id_Poli], [Id_Dokter]) VALUES (10003, N'Senin', 1, 3)
SET IDENTITY_INSERT [dbo].[Jadwal_Jaga] OFF
GO
SET IDENTITY_INSERT [dbo].[Poli] ON 

INSERT [dbo].[Poli] ([Id], [Nama], [Lokasi]) VALUES (1, N'Poli Umum', N'Ruang A1101')
INSERT [dbo].[Poli] ([Id], [Nama], [Lokasi]) VALUES (2, N'Poli Penyakit Dalam', N'Ruang A1102')
INSERT [dbo].[Poli] ([Id], [Nama], [Lokasi]) VALUES (3, N'Poli Gigi', N'Ruang A1109')
SET IDENTITY_INSERT [dbo].[Poli] OFF
GO
SET IDENTITY_INSERT [dbo].[Spesialisasi] ON 

INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (1, N'Spesialis Patologi Klinik', N'Sp.PK')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (2, N'Spesialis Parasitologi Klinik', N'Sp.ParK')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (3, N'Spesialis Urologi', N'Sp.U')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (4, N'Spesialis Gizi Klinik', N'Sp.GK')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (5, N'Spesialis Anak', N'Sp.A')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (6, N'Spesialis Anestesiologi dan Terapi Intensif', N'Sp.An')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (7, N'Spesialis Bedah', N'Sp.B')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (8, N'Spesialis Bedah Plastik Rekonstruksi dan Estetik', N'Sp.BP-RE')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (9, N'Spesialis Farmakologi Klinik', N'Sp.FK')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (10, N'Spesialis Jantung dan Pembuluh Darah', N'Sp.JP')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (11, N'Spesialis Konservasi Gigi', N'Sp.KG')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (12, N'Spesialis Bedah Orthopaedi dan Traumatologi', N'Sp.OT')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (13, N'Spesialis Penyakit Dalam', N'Sp.PD')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (14, N'Spesialis Saraf', N'Sp.S')
INSERT [dbo].[Spesialisasi] ([Id], [Nama], [Gelar]) VALUES (15, N'Spesialis Radiologi', N'Sp.Rad')
SET IDENTITY_INSERT [dbo].[Spesialisasi] OFF
GO
SET IDENTITY_INSERT [dbo].[Spesialisasi_Dokter] ON 

INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (2, 2, 10)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (3, 3, 5)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (10005, 10007, 14)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (10006, 10008, 15)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (10007, 10009, 13)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (10008, 10010, 12)
INSERT [dbo].[Spesialisasi_Dokter] ([Id], [Id_Dokter], [Id_Spesialisasi]) VALUES (10009, 10011, 15)
SET IDENTITY_INSERT [dbo].[Spesialisasi_Dokter] OFF
GO
ALTER TABLE [dbo].[Jadwal_Jaga]  WITH CHECK ADD FOREIGN KEY([Id_Dokter])
REFERENCES [dbo].[Dokter] ([Id])
GO
ALTER TABLE [dbo].[Jadwal_Jaga]  WITH CHECK ADD FOREIGN KEY([Id_Poli])
REFERENCES [dbo].[Poli] ([Id])
GO
ALTER TABLE [dbo].[Spesialisasi_Dokter]  WITH CHECK ADD FOREIGN KEY([Id_Dokter])
REFERENCES [dbo].[Dokter] ([Id])
GO
ALTER TABLE [dbo].[Spesialisasi_Dokter]  WITH CHECK ADD FOREIGN KEY([Id_Spesialisasi])
REFERENCES [dbo].[Spesialisasi] ([Id])
GO
USE [master]
GO
ALTER DATABASE [SIDOK] SET  READ_WRITE 
GO
