USE [master]
GO
/****** Object:  Database [PJDBMS]    Script Date: 9/29/2025 10:21:44 PM ******/
CREATE DATABASE [PJDBMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PJDBMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PJDBMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PJDBMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PJDBMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PJDBMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PJDBMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PJDBMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PJDBMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PJDBMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PJDBMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PJDBMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PJDBMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PJDBMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PJDBMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PJDBMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PJDBMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PJDBMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PJDBMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PJDBMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PJDBMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PJDBMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PJDBMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PJDBMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PJDBMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PJDBMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PJDBMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PJDBMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PJDBMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PJDBMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PJDBMS] SET  MULTI_USER 
GO
ALTER DATABASE [PJDBMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PJDBMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PJDBMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PJDBMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PJDBMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PJDBMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PJDBMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [PJDBMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PJDBMS]
GO
/****** Object:  User [sa1]    Script Date: 9/29/2025 10:21:44 PM ******/
CREATE USER [sa1] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [QuanLyHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
CREATE ROLE [QuanLyHocSinh]
GO
/****** Object:  DatabaseRole [GiaoVien]    Script Date: 9/29/2025 10:21:44 PM ******/
CREATE ROLE [GiaoVien]
GO
/****** Object:  DatabaseRole [Admin]    Script Date: 9/29/2025 10:21:44 PM ******/
CREATE ROLE [Admin]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GioiTinhText]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ===== Functions: đổi mã sang chữ ===== */
CREATE   FUNCTION [dbo].[fn_GioiTinhText](@GioiTinh TINYINT)
RETURNS NVARCHAR(10)
AS
BEGIN
    RETURN (CASE @GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Khác' END);
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TinhDiemTrungBinhKi]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[fn_TinhDiemTrungBinhKi]
(
    @HocSinhID INT,
    @LopHocID INT
)
RETURNS DECIMAL(4,2)
AS
BEGIN
    DECLARE @TongDiem DECIMAL(10,2) = 0,
            @SoMon INT = 0;

    -- Duyệt tất cả các môn mà học sinh có điểm trong lớp
    SELECT 
        @TongDiem += dbo.fn_TinhDiemTrungBinhMon(@HocSinhID, MonHocID, @LopHocID),
        @SoMon += CASE 
                     WHEN dbo.fn_TinhDiemTrungBinhMon(@HocSinhID, MonHocID, @LopHocID) IS NOT NULL 
                     THEN 1 ELSE 0 
                  END
    FROM DiemHocSinh
    WHERE HocSinhID = @HocSinhID AND LopHocID = @LopHocID;

    RETURN CASE WHEN @SoMon > 0 THEN ROUND(@TongDiem / @SoMon, 2) ELSE NULL END;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TinhDiemTrungBinhMon]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   FUNCTION [dbo].[fn_TinhDiemTrungBinhMon]
(
    @HocSinhID INT,
    @MonHocID INT,
    @LopHocID INT
)
RETURNS DECIMAL(4,2)
AS
BEGIN
    DECLARE @TongDiem DECIMAL(10,2) = 0,
            @TongHeSo INT = 0;

    DECLARE @TX1 DECIMAL(4,2), @TX2 DECIMAL(4,2), @TX3 DECIMAL(4,2), @TX4 DECIMAL(4,2),
            @GK DECIMAL(4,2), @CK DECIMAL(4,2);

    SELECT TOP 1
        @TX1 = DiemTX1, 
        @TX2 = DiemTX2, 
        @TX3 = DiemTX3, 
        @TX4 = DiemTX4,
        @GK  = DiemGiuaKy, 
        @CK  = DiemCuoiKy
    FROM DiemHocSinh
    WHERE HocSinhID = @HocSinhID 
      AND MonHocID  = @MonHocID 
      AND LopHocID  = @LopHocID;

    -- Tính toán
    IF @TX1 IS NOT NULL BEGIN SET @TongDiem += @TX1; SET @TongHeSo += 1; END;
    IF @TX2 IS NOT NULL BEGIN SET @TongDiem += @TX2; SET @TongHeSo += 1; END;
    IF @TX3 IS NOT NULL BEGIN SET @TongDiem += @TX3; SET @TongHeSo += 1; END;
    IF @TX4 IS NOT NULL BEGIN SET @TongDiem += @TX4; SET @TongHeSo += 1; END;

    IF @GK IS NOT NULL BEGIN SET @TongDiem += @GK * 2; SET @TongHeSo += 2; END;
    IF @CK IS NOT NULL BEGIN SET @TongDiem += @CK * 3; SET @TongHeSo += 3; END;

    RETURN CASE WHEN @TongHeSo > 0 THEN ROUND(@TongDiem / @TongHeSo, 2) ELSE NULL END;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TrangThaiHocSinhText]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[fn_TrangThaiHocSinhText](@TrangThai TINYINT)
RETURNS NVARCHAR(20)
AS
BEGIN
    RETURN (CASE @TrangThai
              WHEN 0 THEN N'Nghỉ'
              WHEN 1 THEN N'Đang học'
              WHEN 2 THEN N'Bảo lưu'
              WHEN 3 THEN N'Tạm nghỉ'
              ELSE N'Không rõ'
            END);
END;
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[LopHocID] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](100) NOT NULL,
	[KhoiHoc] [tinyint] NOT NULL,
	[HocKy] [tinyint] NOT NULL,
	[NamHoc] [smallint] NOT NULL,
	[DaKetThuc] [bit] NOT NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[LopHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_LopHoc_TenLop] UNIQUE NONCLUSTERED 
(
	[TenLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[HocSinhID] [int] IDENTITY(1,1) NOT NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [tinyint] NOT NULL,
	[DanToc] [nvarchar](30) NULL,
	[TonGiao] [nvarchar](30) NULL,
	[QueQuan] [nvarchar](100) NULL,
	[TrangThai] [tinyint] NOT NULL,
	[NamNhapHoc] [smallint] NOT NULL,
	[LopHocID] [int] NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[HocSinhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[GiaoVienID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [tinyint] NOT NULL,
	[TrangThai] [tinyint] NOT NULL,
	[LaTuyenMoi] [bit] NOT NULL,
	[CMND_CCCD] [nvarchar](20) NULL,
	[SoDinhDanhCaNhan] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DanToc] [nvarchar](50) NULL,
	[TonGiao] [nvarchar](50) NULL,
	[LaDoanVien] [bit] NOT NULL,
	[LaDangVien] [bit] NOT NULL,
	[SoSoBHXH] [nvarchar](50) NULL,
	[NoiThuongTru] [nvarchar](200) NULL,
	[QueQuan] [nvarchar](200) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[GiaoVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SoDinhDanhCaNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CMND_CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MonHocID] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NOT NULL,
	[LaMonDoi] [bit] NOT NULL,
	[LaMonNangKhieu] [bit] NOT NULL,
	[SoTiet] [int] NOT NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_MonHoc_TenMon] UNIQUE NONCLUSTERED 
(
	[TenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoanID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](200) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_TK_TenDangNhap] UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_ThongKe]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- View thống kê toàn bộ
CREATE   VIEW [dbo].[vw_ThongKe]
AS
SELECT 
    (SELECT COUNT(*) FROM HocSinh) AS SoHocSinh,
    (SELECT COUNT(*) FROM GiaoVien) AS SoGiaoVien,
    (SELECT COUNT(*) FROM LopHoc  where LopHoc.DaketThuc=0) AS SoLopHoc,
    (SELECT COUNT(*) FROM MonHoc) AS SoMonHoc,
    (SELECT COUNT(*) FROM TaiKhoan) AS SoTaiKhoan;
GO
/****** Object:  View [dbo].[vw_LopHoc_HocKy]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[vw_LopHoc_HocKy]
AS
SELECT 
    l.LopHocID,
    l.TenLop,
    l.HocKy,
    l.NamHoc,
    l.KhoiHoc,
    -- Xuất ra chuỗi: "10A1 (HK1 - 2025)"
    l.TenLop + N' (HK' + CAST(l.HocKy AS NVARCHAR(10)) + N' - ' + CAST(l.NamHoc AS NVARCHAR(10)) + N')' AS TenLopHocKy
FROM LopHoc l;
GO
/****** Object:  View [dbo].[vw_DanhSachGiaoVien]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_DanhSachGiaoVien]
AS
SELECT 
    gv.GiaoVienID,
    gv.HoTen,
    gv.NgaySinh,
    GioiTinh = CASE gv.GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Khác' END,
    TrangThai = CASE gv.TrangThai 
                   WHEN 0 THEN N'Nghỉ'
                   WHEN 1 THEN N'Đang dạy'
                   WHEN 2 THEN N'Tạm nghỉ'
                   ELSE N'Không rõ'
                END,
    gv.Email,
    gv.DienThoai,
    gv.DanToc,
    gv.TonGiao,
    gv.NoiThuongTru
FROM dbo.GiaoVien gv;
GO
/****** Object:  View [dbo].[vw_DanhSachMonHoc]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_DanhSachMonHoc]
AS
SELECT 
    mh.MonHocID,
    mh.TenMon,
    LaMonDoi = CASE mh.LaMonDoi WHEN 1 THEN N'Có' ELSE N'Không' END,
    LaMonNangKhieu = CASE mh.LaMonNangKhieu WHEN 1 THEN N'Có' ELSE N'Không' END,
    mh.SoTiet
FROM dbo.MonHoc mh;
GO
/****** Object:  View [dbo].[vw_HocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_HocSinh]
AS
SELECT 
    hs.HocSinhID,
    hs.Ho + N' ' + hs.Ten AS HoTen,
    hs.NgaySinh,
    dbo.fn_GioiTinhText(hs.GioiTinh) AS GioiTinh,
    hs.DanToc,
    hs.TonGiao,
    hs.QueQuan,
    dbo.fn_TrangThaiHocSinhText(hs.TrangThai) AS TrangThai,
    hs.NamNhapHoc,
    l.LopHocID,
    l.TenLop,
    l.KhoiHoc,
    l.HocKy,
    l.NamHoc
FROM HocSinh hs
LEFT JOIN LopHoc l ON hs.LopHocID = l.LopHocID;
GO
/****** Object:  Table [dbo].[PhanCongDay]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongDay](
	[PhanCongID] [int] IDENTITY(1,1) NOT NULL,
	[GiaoVienID] [int] NOT NULL,
	[LopHocID] [int] NOT NULL,
	[MonHocID] [int] NOT NULL,
	[SoTiet] [int] NOT NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[PhanCongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_PhanCong] UNIQUE NONCLUSTERED 
(
	[GiaoVienID] ASC,
	[LopHocID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_DanhSachPhanCong]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_DanhSachPhanCong]
AS
SELECT 
    pc.PhanCongID,
    pc.GiaoVienID,
    gv.HoTen AS TenGiaoVien,
    pc.LopHocID,
    l.TenLop,
    pc.MonHocID,
    mh.TenMon,
    pc.SoTiet
FROM dbo.PhanCongDay pc
JOIN dbo.GiaoVien gv ON pc.GiaoVienID = gv.GiaoVienID
JOIN dbo.LopHoc l    ON pc.LopHocID = l.LopHocID
JOIN dbo.MonHoc mh   ON pc.MonHocID = mh.MonHocID;
GO
/****** Object:  View [dbo].[vw_HocSinhChuaCoLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_HocSinhChuaCoLop]
AS
SELECT 
    hs.HocSinhID,
    hs.Ho,
    hs.Ten,
    hs.NgaySinh,
    dbo.fn_GioiTinhText(hs.GioiTinh) AS GioiTinh,
    hs.DanToc,
    hs.TonGiao,
    hs.QueQuan,
    dbo.fn_TrangThaiHocSinhText(hs.TrangThai) AS TrangThai,
    hs.NamNhapHoc
FROM HocSinh hs
WHERE hs.LopHocID IS NULL;
GO
/****** Object:  Table [dbo].[DiemHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemHocSinh](
	[HocSinhID] [int] NOT NULL,
	[LopHocID] [int] NOT NULL,
	[MonHocID] [int] NOT NULL,
	[DiemTX1] [decimal](4, 2) NULL,
	[DiemTX2] [decimal](4, 2) NULL,
	[DiemTX3] [decimal](4, 2) NULL,
	[DiemTX4] [decimal](4, 2) NULL,
	[DiemGiuaKy] [decimal](4, 2) NULL,
	[DiemCuoiKy] [decimal](4, 2) NULL,
	[HoanThanh] [bit] NOT NULL,
 CONSTRAINT [PK_DiemHocSinh] PRIMARY KEY CLUSTERED 
(
	[HocSinhID] ASC,
	[LopHocID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocSinh_Lop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh_Lop](
	[HocSinhID] [int] NOT NULL,
	[LopHocID] [int] NOT NULL,
	[HanhKiem] [tinyint] NULL,
 CONSTRAINT [PK_HocSinh_Lop] PRIMARY KEY CLUSTERED 
(
	[HocSinhID] ASC,
	[LopHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](200) NULL,
	[TrangThaiQuyen] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DiemHocSinh] ADD  CONSTRAINT [DF_Diem_HoanThanh]  DEFAULT ((0)) FOR [HoanThanh]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_GioiTinh]  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_LaTuyenMoi]  DEFAULT ((0)) FOR [LaTuyenMoi]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_DanToc]  DEFAULT (N'Kinh') FOR [DanToc]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_TonGiao]  DEFAULT (N'Không') FOR [TonGiao]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_LaDoanVien]  DEFAULT ((0)) FOR [LaDoanVien]
GO
ALTER TABLE [dbo].[GiaoVien] ADD  CONSTRAINT [DF_GV_LaDangVien]  DEFAULT ((0)) FOR [LaDangVien]
GO
ALTER TABLE [dbo].[HocSinh] ADD  CONSTRAINT [DF_HS_GioiTinh]  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[HocSinh] ADD  CONSTRAINT [DF_HS_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LopHoc] ADD  CONSTRAINT [DF_LopHoc_DaKetThuc]  DEFAULT ((0)) FOR [DaKetThuc]
GO
ALTER TABLE [dbo].[MonHoc] ADD  CONSTRAINT [DF_MonHoc_LaMonDoi]  DEFAULT ((0)) FOR [LaMonDoi]
GO
ALTER TABLE [dbo].[MonHoc] ADD  CONSTRAINT [DF_MonHoc_LaMonNK]  DEFAULT ((0)) FOR [LaMonNangKhieu]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT ((1)) FOR [TrangThaiQuyen]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF_TK_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DiemHocSinh]  WITH CHECK ADD  CONSTRAINT [FK_Diem_HS] FOREIGN KEY([HocSinhID])
REFERENCES [dbo].[HocSinh] ([HocSinhID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiemHocSinh] CHECK CONSTRAINT [FK_Diem_HS]
GO
ALTER TABLE [dbo].[DiemHocSinh]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Lop] FOREIGN KEY([LopHocID])
REFERENCES [dbo].[LopHoc] ([LopHocID])
GO
ALTER TABLE [dbo].[DiemHocSinh] CHECK CONSTRAINT [FK_Diem_Lop]
GO
ALTER TABLE [dbo].[DiemHocSinh]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Mon] FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[DiemHocSinh] CHECK CONSTRAINT [FK_Diem_Mon]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HS_LopHoc] FOREIGN KEY([LopHocID])
REFERENCES [dbo].[LopHoc] ([LopHocID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HS_LopHoc]
GO
ALTER TABLE [dbo].[HocSinh_Lop]  WITH CHECK ADD  CONSTRAINT [FK_HSL_HS] FOREIGN KEY([HocSinhID])
REFERENCES [dbo].[HocSinh] ([HocSinhID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocSinh_Lop] CHECK CONSTRAINT [FK_HSL_HS]
GO
ALTER TABLE [dbo].[HocSinh_Lop]  WITH CHECK ADD  CONSTRAINT [FK_HSL_Lop] FOREIGN KEY([LopHocID])
REFERENCES [dbo].[LopHoc] ([LopHocID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocSinh_Lop] CHECK CONSTRAINT [FK_HSL_Lop]
GO
ALTER TABLE [dbo].[PhanCongDay]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GV] FOREIGN KEY([GiaoVienID])
REFERENCES [dbo].[GiaoVien] ([GiaoVienID])
GO
ALTER TABLE [dbo].[PhanCongDay] CHECK CONSTRAINT [FK_PhanCong_GV]
GO
ALTER TABLE [dbo].[PhanCongDay]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_Lop] FOREIGN KEY([LopHocID])
REFERENCES [dbo].[LopHoc] ([LopHocID])
GO
ALTER TABLE [dbo].[PhanCongDay] CHECK CONSTRAINT [FK_PhanCong_Lop]
GO
ALTER TABLE [dbo].[PhanCongDay]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_Mon] FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[PhanCongDay] CHECK CONSTRAINT [FK_PhanCong_Mon]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_Role]
GO
ALTER TABLE [dbo].[DiemHocSinh]  WITH CHECK ADD  CONSTRAINT [CK_Diem_Range] CHECK  ((([DiemTX1] IS NULL OR [DiemTX1]>=(0) AND [DiemTX1]<=(10)) AND ([DiemTX2] IS NULL OR [DiemTX2]>=(0) AND [DiemTX2]<=(10)) AND ([DiemTX3] IS NULL OR [DiemTX3]>=(0) AND [DiemTX3]<=(10)) AND ([DiemTX4] IS NULL OR [DiemTX4]>=(0) AND [DiemTX4]<=(10)) AND ([DiemGiuaKy] IS NULL OR [DiemGiuaKy]>=(0) AND [DiemGiuaKy]<=(10)) AND ([DiemCuoiKy] IS NULL OR [DiemCuoiKy]>=(0) AND [DiemCuoiKy]<=(10))))
GO
ALTER TABLE [dbo].[DiemHocSinh] CHECK CONSTRAINT [CK_Diem_Range]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [CK_GV_GioiTinh] CHECK  (([GioiTinh]=(2) OR [GioiTinh]=(1) OR [GioiTinh]=(0)))
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [CK_GV_GioiTinh]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [CK_GV_TrangThai] CHECK  (([TrangThai]=(2) OR [TrangThai]=(1) OR [TrangThai]=(0)))
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [CK_GV_TrangThai]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [CK_HS_GioiTinh] CHECK  (([GioiTinh]=(2) OR [GioiTinh]=(1) OR [GioiTinh]=(0)))
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [CK_HS_GioiTinh]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [CK_HS_NamNhapHoc] CHECK  (([NamNhapHoc]>=(2000) AND [NamNhapHoc]<=(2100)))
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [CK_HS_NamNhapHoc]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [CK_HS_TrangThai] CHECK  (([TrangThai]=(3) OR [TrangThai]=(2) OR [TrangThai]=(1) OR [TrangThai]=(0)))
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [CK_HS_TrangThai]
GO
ALTER TABLE [dbo].[HocSinh_Lop]  WITH CHECK ADD  CONSTRAINT [CK_HSL_HanhKiem] CHECK  (([HanhKiem]>=(1) AND [HanhKiem]<=(4) OR [HanhKiem] IS NULL))
GO
ALTER TABLE [dbo].[HocSinh_Lop] CHECK CONSTRAINT [CK_HSL_HanhKiem]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [CK_LopHoc_HocKy] CHECK  (([HocKy]=(2) OR [HocKy]=(1)))
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [CK_LopHoc_HocKy]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [CK_LopHoc_Khoi] CHECK  (([KhoiHoc]>=(1) AND [KhoiHoc]<=(12)))
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [CK_LopHoc_Khoi]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [CK_LopHoc_NamHoc] CHECK  (([NamHoc]>=(2000) AND [NamHoc]<=(2100)))
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [CK_LopHoc_NamHoc]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [CK_MonHoc_SoTiet] CHECK  (([SoTiet]>(0)))
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [CK_MonHoc_SoTiet]
GO
ALTER TABLE [dbo].[PhanCongDay]  WITH CHECK ADD  CONSTRAINT [CK_PhanCong_SoTiet] CHECK  (([SoTiet]>(0)))
GO
ALTER TABLE [dbo].[PhanCongDay] CHECK CONSTRAINT [CK_PhanCong_SoTiet]
GO
/****** Object:  StoredProcedure [dbo].[sp_BatQuyenRole]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==========================================================
   9. Proc bật / tắt quyền Role (GRANT/REVOKE)
   ========================================================== */
CREATE   PROCEDURE [dbo].[sp_BatQuyenRole]
    @RoleName NVARCHAR(50)
AS
BEGIN
    IF @RoleName = N'Admin'
        GRANT CONTROL ON DATABASE::PJDBMS TO [Admin];

    ELSE IF @RoleName = N'QuanLyHocSinh'
    BEGIN
        GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.HocSinh TO [QuanLyHocSinh];
        GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.LopHoc TO [QuanLyHocSinh];
        GRANT EXECUTE ON dbo.sp_ThemHocSinh TO [QuanLyHocSinh];
        GRANT EXECUTE ON dbo.sp_CapNhatHocSinh TO [QuanLyHocSinh];
        GRANT EXECUTE ON dbo.sp_XoaHocSinh TO [QuanLyHocSinh];
        GRANT EXECUTE ON dbo.sp_ChuyenHocSinhSangLop TO [QuanLyHocSinh];
        GRANT EXECUTE ON dbo.sp_ChuyenToanBoHocSinh TO [QuanLyHocSinh];
    END

    ELSE IF @RoleName = N'GiaoVien'
    BEGIN
        GRANT SELECT, UPDATE ON dbo.DiemHocSinh TO [GiaoVien];
        GRANT EXECUTE ON dbo.sp_CapNhatDiem TO [GiaoVien];
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatDiem]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_CapNhatDiem]
    @HocSinhID INT,
    @LopHocID INT,
    @MonHocID INT,
    @DiemTX1 DECIMAL(4,2) = NULL,
    @DiemTX2 DECIMAL(4,2) = NULL,
    @DiemTX3 DECIMAL(4,2) = NULL,
    @DiemTX4 DECIMAL(4,2) = NULL,
    @DiemGiuaKy DECIMAL(4,2) = NULL,
    @DiemCuoiKy DECIMAL(4,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE DiemHocSinh
    SET DiemTX1 = @DiemTX1,
        DiemTX2 = @DiemTX2,
        DiemTX3 = @DiemTX3,
        DiemTX4 = @DiemTX4,
        DiemGiuaKy = @DiemGiuaKy,
        DiemCuoiKy = @DiemCuoiKy
    WHERE HocSinhID = @HocSinhID AND LopHocID = @LopHocID AND MonHocID = @MonHocID;

    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO DiemHocSinh(HocSinhID, LopHocID, MonHocID, 
            DiemTX1, DiemTX2, DiemTX3, DiemTX4, DiemGiuaKy, DiemCuoiKy)
        VALUES(@HocSinhID, @LopHocID, @MonHocID,
            @DiemTX1, @DiemTX2, @DiemTX3, @DiemTX4, @DiemGiuaKy, @DiemCuoiKy);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ===== Proc: cập nhật học sinh ===== */
CREATE   PROCEDURE [dbo].[sp_CapNhatHocSinh]
    @HocSinhID INT,
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @NgaySinh DATE,
    @GioiTinh TINYINT,
    @DanToc NVARCHAR(30) = NULL,
    @TonGiao NVARCHAR(30) = NULL,
    @QueQuan NVARCHAR(100) = NULL,
    @TrangThai TINYINT,
    @NamNhapHoc SMALLINT,
    @LopHocID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE HocSinh
    SET Ho=@Ho, Ten=@Ten, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
        DanToc=@DanToc, TonGiao=@TonGiao, QueQuan=@QueQuan,
        TrangThai=@TrangThai, NamNhapHoc=@NamNhapHoc, LopHocID=@LopHocID
    WHERE HocSinhID=@HocSinhID;

    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Cập nhật lớp
CREATE   PROCEDURE [dbo].[sp_CapNhatLop]
    @LopHocID INT,
    @TenLop NVARCHAR(100),
    @KhoiHoc TINYINT,
    @HocKy TINYINT,
    @NamHoc SMALLINT,
    @DaKetThuc BIT
AS
BEGIN
    UPDATE LopHoc
    SET TenLop=@TenLop, KhoiHoc=@KhoiHoc, HocKy=@HocKy,
        NamHoc=@NamHoc, DaKetThuc=@DaKetThuc
    WHERE LopHocID=@LopHocID;

    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatPhanCong]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sửa
CREATE   PROCEDURE [dbo].[sp_CapNhatPhanCong]
    @PhanCongID INT,
    @GiaoVienID INT,
    @LopHocID INT,
    @MonHocID INT,
    @SoTiet INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PhanCongDay
    SET GiaoVienID = @GiaoVienID,
        LopHocID = @LopHocID,
        MonHocID = @MonHocID,
        SoTiet = @SoTiet
    WHERE PhanCongID = @PhanCongID;

    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTaiKhoan]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CapNhatTaiKhoan]
    @TaiKhoanID INT,
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(200),
    @RoleID INT,
    @TrangThai BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE TaiKhoan
    SET TenDangNhap=@TenDangNhap,
        MatKhau=@MatKhau,
        RoleID=@RoleID,
        TrangThai=@TrangThai
    WHERE TaiKhoanID=@TaiKhoanID;

    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTrangThaiRole]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_CapNhatTrangThaiRole]
    @RoleID INT,
    @TrangThaiQuyen BIT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RoleName NVARCHAR(50);
    SELECT @RoleName = RoleName FROM Role WHERE RoleID = @RoleID;

    IF @RoleName IS NULL
    BEGIN
        RAISERROR(N'Role không tồn tại.', 16, 1);
        RETURN;
    END

    -- Cập nhật trạng thái trong bảng Role
    UPDATE Role
    SET TrangThaiQuyen = @TrangThaiQuyen
    WHERE RoleID = @RoleID;

    -- Bật quyền (GRANT)
    IF @TrangThaiQuyen = 1
    BEGIN
        EXEC sp_BatQuyenRole @RoleName;
    END
    ELSE  -- Tắt quyền (REVOKE)
    BEGIN
        EXEC sp_TatQuyenRole @RoleName;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ChuyenHocSinhSangLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Chuyển toàn bộ học sinh sang lớp khác
CREATE   PROCEDURE [dbo].[sp_ChuyenHocSinhSangLop]
    @HocSinhID INT,
    @LopHocCu INT,
    @LopHocMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        -- Đánh dấu lớp cũ đã kết thúc
        UPDATE LopHoc
        SET DaKetThuc = 1
        WHERE LopHocID = @LopHocCu;

        -- Cập nhật lớp hiện tại của học sinh
        UPDATE HocSinh
        SET LopHocID = @LopHocMoi
        WHERE HocSinhID = @HocSinhID;

        -- Lưu lại lịch sử (nếu chưa có trong HocSinh_Lop thì thêm mới)
        IF NOT EXISTS (
            SELECT 1 FROM HocSinh_Lop WHERE HocSinhID=@HocSinhID AND LopHocID=@LopHocMoi
        )
        BEGIN
            INSERT INTO HocSinh_Lop(HocSinhID, LopHocID, HanhKiem)
            VALUES(@HocSinhID, @LopHocMoi, NULL);
        END

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ChuyenToanBoHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ChuyenToanBoHocSinh]
    @LopHocCu INT,
    @LopHocMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        -- Đánh dấu lớp cũ đã kết thúc
        UPDATE LopHoc
        SET DaKetThuc = 1
        WHERE LopHocID = @LopHocCu;

        -- Cập nhật lớp hiện tại cho toàn bộ học sinh
        UPDATE HocSinh
        SET LopHocID = @LopHocMoi
        WHERE LopHocID = @LopHocCu;

        -- Thêm lịch sử vào HocSinh_Lop nếu chưa có
        INSERT INTO HocSinh_Lop(HocSinhID, LopHocID, HanhKiem)
        SELECT hs.HocSinhID, @LopHocMoi, NULL
        FROM HocSinh hs
        WHERE hs.LopHocID = @LopHocMoi
          AND NOT EXISTS (
              SELECT 1 
              FROM HocSinh_Lop hsl 
              WHERE hsl.HocSinhID = hs.HocSinhID AND hsl.LopHocID = @LopHocMoi
          );

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GanRoleChoUser]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==========================================================
   8. Proc gán / hủy role cho User
   ========================================================== */
CREATE   PROCEDURE [dbo].[sp_GanRoleChoUser]
    @UserName NVARCHAR(100),
    @RoleName NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @UserName)
    BEGIN
        SET @sql = 'ALTER ROLE [' + @RoleName + '] ADD MEMBER [' + @UserName + ']';
        EXEC(@sql);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHocSinhById]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ===== Proc: lấy 1 học sinh theo ID (để Sửa) ===== */
CREATE   PROCEDURE [dbo].[sp_GetHocSinhById]
    @HocSinhID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 *
    FROM HocSinh
    WHERE HocSinhID = @HocSinhID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPhanCongById]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy chi tiết theo ID
CREATE   PROCEDURE [dbo].[sp_GetPhanCongById]
    @PhanCongID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM vw_DanhSachPhanCong WHERE PhanCongID = @PhanCongID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_HuyRoleCuaUser]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_HuyRoleCuaUser]
    @UserName NVARCHAR(100),
    @RoleName NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @UserName)
    BEGIN
        SET @sql = 'ALTER ROLE [' + @RoleName + '] DROP MEMBER [' + @UserName + ']';
        EXEC(@sql);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachPhanCong]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_LayDanhSachPhanCong]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        pc.PhanCongID,
        gv.HoTen AS TenGiaoVien,
        l.TenLop AS TenLop,
        mh.TenMon AS TenMon,
        pc.SoTiet
    FROM dbo.PhanCongDay pc
    JOIN dbo.GiaoVien gv ON pc.GiaoVienID = gv.GiaoVienID
    JOIN dbo.LopHoc l    ON pc.LopHocID = l.LopHocID
    JOIN dbo.MonHoc mh   ON pc.MonHocID = mh.MonHocID
    ORDER BY l.NamHoc DESC, l.KhoiHoc, l.HocKy;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachRole]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_LayDanhSachRole]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT RoleID, RoleName, TrangThaiQuyen, MoTa
    FROM Role
    ORDER BY RoleName;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayHocSinhTheoLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ===== Proc: danh sách học sinh theo lớp (gọn, chỉ text) ===== */
CREATE PROCEDURE [dbo].[sp_LayHocSinhTheoLop]
    @LopHocID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hs.HocSinhID,
        hs.Ho ,
        hs.Ten,
        hs.NgaySinh,
        dbo.fn_GioiTinhText(hs.GioiTinh) AS GioiTinh,
        hs.DanToc,
        hs.TonGiao,
        hs.QueQuan,
        dbo.fn_TrangThaiHocSinhText(hs.TrangThai) AS TrangThai,
        hs.NamNhapHoc,
        l.TenLop AS LopHoc
    FROM HocSinh hs
    LEFT JOIN LopHoc l ON hs.LopHocID = l.LopHocID
    WHERE (@LopHocID IS NULL OR hs.LopHocID = @LopHocID);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTatCaLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy tất cả lớp (chưa kết thúc)
CREATE   PROCEDURE [dbo].[sp_LayTatCaLop]
AS
BEGIN
    SELECT LopHocID, TenLop, KhoiHoc, HocKy, NamHoc, DaKetThuc
    FROM LopHoc
    ORDER BY NamHoc DESC, KhoiHoc, HocKy;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTatCaLop_Filter]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_LayTatCaLop_Filter]
    @BaoGomDaKetThuc BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        l.LopHocID,
        TenLopHocKy = (l.TenLop + N' (Khối ' + CAST(l.KhoiHoc AS NVARCHAR(10)) 
                        + N' - HK' + CAST(l.HocKy AS NVARCHAR(10)) 
                        + N' - ' + CAST(l.NamHoc AS NVARCHAR(10)) + N')'),
        l.DaKetThuc
    FROM dbo.LopHoc l
    WHERE @BaoGomDaKetThuc = 1  -- nếu chọn thì lấy tất cả
       OR l.DaKetThuc = 0       -- nếu không chọn thì chỉ lấy lớp chưa kết thúc
    ORDER BY l.NamHoc DESC, l.KhoiHoc ASC, l.HocKy ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTatCaRole]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_LayTatCaRole]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.name AS RoleName,
        r.type_desc AS RoleType,
        ISNULL(members.SoLuongUser, 0) AS SoLuongUser
    FROM sys.database_principals r
    LEFT JOIN (
        SELECT drm.role_principal_id, COUNT(*) AS SoLuongUser
        FROM sys.database_role_members drm
        GROUP BY drm.role_principal_id
    ) members ON r.principal_id = members.role_principal_id
    WHERE r.type = 'R' -- chỉ lấy role
      AND r.name IN (N'Admin', N'QuanLyHocSinh', N'GiaoVien') -- lọc role của bạn
    ORDER BY r.name;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTatCaTaiKhoan]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_LayTatCaTaiKhoan]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        tk.TaiKhoanID,
        tk.TenDangNhap,
        tk.MatKhau,
        tk.RoleID,
        r.RoleName,
        tk.TrangThai,
        TrangThaiText = CASE tk.TrangThai 
                           WHEN 1 THEN N'Đang hoạt động'
                           ELSE N'Ngừng' 
                        END
    FROM TaiKhoan tk
    LEFT JOIN Role r ON tk.RoleID = r.RoleID
    ORDER BY tk.TenDangNhap;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TatQuyenRole]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_TatQuyenRole]
    @RoleName NVARCHAR(50)
AS
BEGIN
    IF @RoleName = N'Admin'
        REVOKE CONTROL ON DATABASE::PJDBMS FROM [Admin];

    ELSE IF @RoleName = N'QuanLyHocSinh'
    BEGIN
        REVOKE SELECT, INSERT, UPDATE, DELETE ON dbo.HocSinh FROM [QuanLyHocSinh];
        REVOKE SELECT, INSERT, UPDATE, DELETE ON dbo.LopHoc FROM [QuanLyHocSinh];
        REVOKE EXECUTE ON dbo.sp_ThemHocSinh FROM [QuanLyHocSinh];
        REVOKE EXECUTE ON dbo.sp_CapNhatHocSinh FROM [QuanLyHocSinh];
        REVOKE EXECUTE ON dbo.sp_XoaHocSinh FROM [QuanLyHocSinh];
        REVOKE EXECUTE ON dbo.sp_ChuyenHocSinhSangLop FROM [QuanLyHocSinh];
        REVOKE EXECUTE ON dbo.sp_ChuyenToanBoHocSinh FROM [QuanLyHocSinh];
    END

    ELSE IF @RoleName = N'GiaoVien'
    BEGIN
        REVOKE SELECT, UPDATE ON dbo.DiemHocSinh FROM [GiaoVien];
        REVOKE EXECUTE ON dbo.sp_CapNhatDiem FROM [GiaoVien];
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemHocSinh]
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @NgaySinh DATE,
    @GioiTinh TINYINT,
    @DanToc NVARCHAR(30) = NULL,
    @TonGiao NVARCHAR(30) = NULL,
    @QueQuan NVARCHAR(100) = NULL,
    @TrangThai TINYINT,
    @NamNhapHoc SMALLINT,
    @LopHocID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra lớp có null không
    IF @LopHocID IS NULL
    BEGIN
        RAISERROR (N'Không thể thêm học sinh khi chưa chọn lớp.', 16, 1);
        RETURN;
    END

    -- Kiểm tra lớp có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE LopHocID = @LopHocID)
    BEGIN
        RAISERROR (N'Lớp học không tồn tại.', 16, 1);
        RETURN;
    END

    -- Thêm học sinh
    INSERT INTO HocSinh(Ho, Ten, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, TrangThai, NamNhapHoc, LopHocID)
    VALUES(@Ho, @Ten, @NgaySinh, @GioiTinh, @DanToc, @TonGiao, @QueQuan, @TrangThai, @NamNhapHoc, @LopHocID);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewHocSinhID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thêm lớp
CREATE   PROCEDURE [dbo].[sp_ThemLop]
    @TenLop NVARCHAR(100),
    @KhoiHoc TINYINT,
    @HocKy TINYINT,
    @NamHoc SMALLINT
AS
BEGIN
    INSERT INTO LopHoc(TenLop, KhoiHoc, HocKy, NamHoc, DaKetThuc)
    VALUES(@TenLop, @KhoiHoc, @HocKy, @NamHoc, 0);

    SELECT SCOPE_IDENTITY() AS NewLopHocID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemPhanCong]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thêm
CREATE   PROCEDURE [dbo].[sp_ThemPhanCong]
    @GiaoVienID INT,
    @LopHocID INT,
    @MonHocID INT,
    @SoTiet INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.PhanCongDay(GiaoVienID, LopHocID, MonHocID, SoTiet)
    VALUES(@GiaoVienID, @LopHocID, @MonHocID, @SoTiet);

    SELECT SCOPE_IDENTITY() AS NewPhanCongID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTaiKhoan]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ThemTaiKhoan]
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(200),
    @RoleID INT,
    @TrangThai BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TaiKhoan(TenDangNhap, MatKhau, RoleID, TrangThai)
    VALUES(@TenDangNhap, @MatKhau, @RoleID, @TrangThai);

    SELECT SCOPE_IDENTITY() AS NewTaiKhoanID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaHocSinh]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ===== Proc: xóa học sinh ===== */
CREATE   PROCEDURE [dbo].[sp_XoaHocSinh]
    @HocSinhID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM HocSinh WHERE HocSinhID=@HocSinhID;
    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaLop]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xóa lớp
CREATE   PROCEDURE [dbo].[sp_XoaLop]
    @LopHocID INT
AS
BEGIN
    DELETE FROM LopHoc WHERE LopHocID=@LopHocID;
    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaPhanCong]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xóa
CREATE   PROCEDURE [dbo].[sp_XoaPhanCong]
    @PhanCongID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.PhanCongDay WHERE PhanCongID = @PhanCongID;
    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTaiKhoan]    Script Date: 9/29/2025 10:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_XoaTaiKhoan]
    @TaiKhoanID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM TaiKhoan WHERE TaiKhoanID=@TaiKhoanID;
    SELECT @@ROWCOUNT AS RowAffected;
END;
GO
USE [master]
GO
ALTER DATABASE [PJDBMS] SET  READ_WRITE 
GO
