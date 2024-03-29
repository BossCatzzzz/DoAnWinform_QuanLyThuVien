USE [master]
GO
/****** Object:  Database [QUANLYTHUVIEN]    Script Date: 31/08/2021 14:07:51 ******/
CREATE DATABASE [QUANLYTHUVIEN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYTHUVIEN', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL15.PRIMESQL\MSSQL\DATA\QUANLYTHUVIEN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYTHUVIEN_log', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL15.PRIMESQL\MSSQL\DATA\QUANLYTHUVIEN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QUANLYTHUVIEN] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYTHUVIEN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QUANLYTHUVIEN] SET QUERY_STORE = OFF
GO
USE [QUANLYTHUVIEN]
GO
/****** Object:  Table [dbo].[CTPHIEUMUON]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUMUON](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaSach] [int] NOT NULL,
	[SoPhieuMuon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCGIA]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCGIA](
	[MaDocGia] [int] IDENTITY(1,1) NOT NULL,
	[TenDocGia] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[Sdt] [varchar](10) NOT NULL,
	[CMND] [varchar](10) NOT NULL,
 CONSTRAINT [PK_DOCGIA_1] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUMUON]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUON](
	[SoPhieuMuon] [int] IDENTITY(1,1) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayHenTra] [date] NOT NULL,
	[NgayTraThucTe] [date] NULL,
	[MaDocGia] [int] NOT NULL,
	[SoLuongMuon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MaTheLoai] [int] NOT NULL,
	[TomTat] [nvarchar](50) NULL,
	[TacGia] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](200) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CTPHIEUMUON] ON 

INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (1, 12, 2)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (2, 2, 2)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (9, 7, 5)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (10, 8, 5)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (11, 10, 5)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (12, 5, 6)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (13, 12, 7)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (14, 13, 7)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (15, 7, 8)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (16, 5, 8)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (22, 2, 13)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (23, 13, 13)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (30, 12, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (31, 13, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (32, 7, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (33, 7, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (34, 7, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (35, 7, 16)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (42, 12, 19)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (43, 10, 19)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (44, 13, 20)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (45, 9, 21)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (46, 10, 21)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (47, 2, 21)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (48, 5, 22)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (49, 5, 22)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (50, 12, 23)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (51, 12, 23)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (52, 12, 23)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (53, 7, 24)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (54, 7, 24)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (55, 13, 25)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (56, 7, 26)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (57, 2, 26)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (58, 8, 27)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (59, 5, 27)
INSERT [dbo].[CTPHIEUMUON] ([ID], [MaSach], [SoPhieuMuon]) VALUES (60, 2, 28)
SET IDENTITY_INSERT [dbo].[CTPHIEUMUON] OFF
GO
SET IDENTITY_INSERT [dbo].[DOCGIA] ON 

INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (1, N'Nguyễn N', N'tphcm', N'1234566789', N'0123')
INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (2, N'Tạo Lý', N'tphcm', N'090909', N'025428')
INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (2005, N'Nguyễn Văn A', N'bình dương', N'0908215966', N'012342345')
INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (2008, N'Lý Thông', N'chưa biết', N'0987654321', N'0')
INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (2009, N'Conan Edogawa', N'Japan', N'111111111', N'0')
INSERT [dbo].[DOCGIA] ([MaDocGia], [TenDocGia], [DiaChi], [Sdt], [CMND]) VALUES (2010, N'Kakalot', N'Vegeta', N'023455632', N'1234567890')
SET IDENTITY_INSERT [dbo].[DOCGIA] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUMUON] ON 

INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (2, CAST(N'2021-07-23' AS Date), CAST(N'2021-08-24' AS Date), CAST(N'2021-08-28' AS Date), 2, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (5, CAST(N'2021-07-23' AS Date), CAST(N'2021-08-23' AS Date), NULL, 2005, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (6, CAST(N'2021-07-23' AS Date), CAST(N'2021-08-23' AS Date), CAST(N'2021-08-28' AS Date), 2, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (7, CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), CAST(N'2021-08-31' AS Date), 2005, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (8, CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), NULL, 1, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (13, CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), 1, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (16, CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), 2, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (19, CAST(N'2021-08-26' AS Date), CAST(N'2021-08-26' AS Date), CAST(N'2021-08-28' AS Date), 2, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (20, CAST(N'2021-08-26' AS Date), CAST(N'2021-08-26' AS Date), CAST(N'2021-08-26' AS Date), 2009, 0)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (21, CAST(N'2021-08-28' AS Date), CAST(N'2021-08-28' AS Date), CAST(N'2021-08-28' AS Date), 2010, 3)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (22, CAST(N'2021-08-28' AS Date), CAST(N'2021-08-28' AS Date), NULL, 2005, 2)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (23, CAST(N'2021-08-28' AS Date), CAST(N'2021-09-09' AS Date), NULL, 2, 3)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (24, CAST(N'2021-08-28' AS Date), CAST(N'2021-10-01' AS Date), NULL, 2, 2)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (25, CAST(N'2021-08-28' AS Date), CAST(N'2021-11-01' AS Date), NULL, 2, 1)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (26, CAST(N'2021-07-01' AS Date), CAST(N'2021-11-01' AS Date), NULL, 1, 2)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (27, CAST(N'2021-06-05' AS Date), CAST(N'2021-12-02' AS Date), NULL, 2005, 2)
INSERT [dbo].[PHIEUMUON] ([SoPhieuMuon], [NgayMuon], [NgayHenTra], [NgayTraThucTe], [MaDocGia], [SoLuongMuon]) VALUES (28, CAST(N'2021-07-05' AS Date), CAST(N'2021-09-09' AS Date), NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[PHIEUMUON] OFF
GO
SET IDENTITY_INSERT [dbo].[SACH] ON 

INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (2, N'Cha Giàu Cha Nghèo', 2, 2, N'là cuốn sách bán chạy nhất của Robert Kiyosaki....', N'Robert Kiyosaki')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (5, N'Những Cuộc Chinh Phạt Của Alexander Đại Đế', 8, 1, N'Người Hy Lạp-La Mã cổ tạo dựng nên...', N'Arrian')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (7, N'300 Bài Code Thiếu Nhi', 3, 5, N'null', N'Abc')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (8, N'sách hay 2', 6, 5, N'sách này dở ẹt', N'mai')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (9, N'Cậu Bé Bút Chì', 6, 3, N'Crayon Shin-chan', N'Usui Yoshito')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (10, N'Sách Hay 4', 5, 4, N'null', N'Bốn')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (12, N'Con Mèo Dạy Hải Âu Bay ', 1, 8, N'văn học nước ngoài', N'Đang Cập Nhật')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (13, N'Nhà Đầu Tư Thông Minh', 2, 2, N'Tác phẩm kinh điển về tư vấn đầu tư', N'Benjamin Graham')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (18, N'Sự Minh Định Của Địa Lý', 3, 17, N'null', N'Robert D. Kaplan')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (19, N'Harry Potter Và Hội Phượng Hoàng', 1, 6, N'null', N'J.K Rowling')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (20, N'Harry Potter Và Chiếc Cốc Lửa', 2, 6, N'null', N'J.K Rowling')
INSERT [dbo].[SACH] ([MaSach], [TenSach], [SoLuong], [MaTheLoai], [TomTat], [TacGia]) VALUES (21, N'Harry Potter Và Đứa Trẻ Bị Nguyền Rủa', 4, 6, N'Phần ngoại truyện', N' J.K. Rowling')
SET IDENTITY_INSERT [dbo].[SACH] OFF
GO
INSERT [dbo].[TAIKHOAN] ([TenDangNhap], [MatKhau], [HoTen], [Email]) VALUES (N'Gic', N'202cb962ac59075b964b07152d234b70', N'Lý Quốc Tạo', N'zmagicz1995@gmail.com.vn')
INSERT [dbo].[TAIKHOAN] ([TenDangNhap], [MatKhau], [HoTen], [Email]) VALUES (N'test', N'098f6bcd4621d373cade4e832627b4f6', N'tester update', N'nomail@mail.com')
GO
SET IDENTITY_INSERT [dbo].[THELOAI] ON 

INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (1, N'Văn Hóa - Lịch Sử')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (2, N'Kinh Doanh')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (3, N'Thiếu Nhi')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (4, N'Pháp Luật')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (5, N'Khoa Học Công Nghệ')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (6, N'Tiểu Thuyết - Truyện')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (8, N'Văn Học')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (17, N'Địa Lý')
SET IDENTITY_INSERT [dbo].[THELOAI] OFF
GO
ALTER TABLE [dbo].[DOCGIA] ADD  CONSTRAINT [DF_DOCGIA_CMND]  DEFAULT ((0)) FOR [CMND]
GO
ALTER TABLE [dbo].[PHIEUMUON] ADD  CONSTRAINT [DF_PHIEUMUON_SoLuongMuon]  DEFAULT ((0)) FOR [SoLuongMuon]
GO
ALTER TABLE [dbo].[SACH] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[CTPHIEUMUON]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CTPHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK__CTPHIEUMU__SoPhi__06CD04F7] FOREIGN KEY([SoPhieuMuon])
REFERENCES [dbo].[PHIEUMUON] ([SoPhieuMuon])
GO
ALTER TABLE [dbo].[CTPHIEUMUON] CHECK CONSTRAINT [FK__CTPHIEUMU__SoPhi__06CD04F7]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUMUON__MaDoc__02FC7413] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DOCGIA] ([MaDocGia])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK__PHIEUMUON__MaDoc__02FC7413]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
/****** Object:  StoredProcedure [dbo].[muonnhieutrongthang]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[muonnhieutrongthang]
(
@thang int,
@nam int
)
as
begin
select ct.MaSach,TenSach,count(ct.MaSach)
from PHIEUMUON p,CTPHIEUMUON ct,SACH s
where p.SoPhieuMuon=ct.SoPhieuMuon and s.MaSach=ct.MaSach and MONTH(NgayMuon)=@thang and year(NgayMuon)=@nam
group by ct.MaSach,TenSach
order by count(ct.MaSach) desc
end
GO
/****** Object:  StoredProcedure [dbo].[showallsach]    Script Date: 31/08/2021 14:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[showallsach]
as
select * from SACH
GO
USE [master]
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  READ_WRITE 
GO
