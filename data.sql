CREATE DATABASE QUAN_LY_DON_HANG_MOI_TRUONG
GO

USE QUAN_LY_DON_HANG_MOI_TRUONG
GO

/*
	CREATE LOGIN newUser WITH PASSWORD = 'ngocbui2701';
	CREATE USER newUser FOR LOGIN newUser;
	ALTER SERVER ROLE sysadmin ADD MEMBER newUser;
	GO

	SELECT name, type_desc, is_disabled 
	FROM sys.server_principals 
	WHERE type IN ('S', 'U');
	GO

	EXEC sp_configure 'remote access', 1;
	RECONFIGURE;
	GO
*/

--TẠO BẢNG NGƯỜI DÙNG
CREATE TABLE NGUOIDUNG(
	ma_nguoi_dung VARCHAR(50) PRIMARY KEY,
    ten NVARCHAR(255) NOT NULL,
    vai_tro NVARCHAR(50) CHECK (vai_tro IN (N'Quản trị viên', N'Phòng kinh doanh',N'Phòng quan trắc',N'Phòng phân tích', N'Phòng kế hoạch',N'Phòng xuất kết quả')) NOT NULL,
	ten_dang_nhap VARCHAR(50) NOT NULL UNIQUE,
    mat_khau VARCHAR(255) NOT NULL DEFAULT '12345678',
    email VARCHAR(255) UNIQUE NOT NULL,
    sdt VARCHAR(15) UNIQUE NOT NULL
)
GO

CREATE TRIGGER trg_AutoGenerateUserId
ON NGUOIDUNG
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NextID INT;
    DECLARE @NewMaNguoiDung VARCHAR(10);
    SELECT @NextID = ISNULL(MAX(CAST(RIGHT(ma_nguoi_dung, 4) AS INT)), 0) + 1
    FROM NGUOIDUNG;
    INSERT INTO NGUOIDUNG (ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, mat_khau, email, sdt)
    SELECT 
        'NV' + RIGHT('0000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @NextID - 1 AS VARCHAR(4)), 4),
        ten, vai_tro, ten_dang_nhap, COALESCE(mat_khau, '12345678'), email, sdt
    FROM inserted;
END;
GO

-- Quản trị viên (chỉ có 1 người)
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Bùi Thị Bích Ngọc', N'Quản trị viên', 'ngocbui2701', 'ngocbui@example.com', '0987654321');

-- Phòng kinh doanh
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Nguyễn Văn An', N'Phòng kinh doanh', 'an123', 'nguyenvanan@gmail.com', '0788660087');

-- Phòng quan trắc
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Lê Thị B', N'Phòng quan trắc', 'lethib2', 'lethib2@example.com', '0987222333');

-- Phòng phân tích
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Phạm Thị D', N'Phòng phân tích', 'phamthid4', 'phamthid4@example.com', '0987444555');

-- Phòng kế hoạch
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Hoàng Văn E', N'Phòng kế hoạch', 'hoangvane5', 'hoangvane5@example.com', '0987555666');

-- Phòng xuất kết quả
INSERT INTO NGUOIDUNG (ten, vai_tro, ten_dang_nhap, email, sdt) 
VALUES (N'Đinh Văn I', N'Phòng xuất kết quả', 'dinhvani9', 'dinhvani9@example.com', '0987999000');

GO

CREATE PROC USP_Login 
	@userName NVARCHAR(50), @passWord NVARCHAR(255)
AS
BEGIN
SELECT * FROM dbo.NGUOIDUNG WHERE ten_dang_nhap = @userName AND mat_khau = @passWord
END
GO

CREATE PROC USP_GetAccountByUsername
    @username NVARCHAR(50)
AS
BEGIN
    SELECT * FROM NGUOIDUNG WHERE ten_dang_nhap = @username
END
GO

CREATE PROC USP_UpdateAccount
	@username NVARCHAR(50), @ID VARCHAR(50), @name NVARCHAR(255), @email VARCHAR(255), @sdt VARCHAR(15), @password VARCHAR(255), @newPassword VARCHAR(255)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM NGUOIDUNG WHERE ten_dang_nhap = @username and mat_khau = @password
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = ' ')
		BEGIN
			UPDATE NGUOIDUNG SET ma_nguoi_dung = @ID, ten = @name, email = @email, sdt = @sdt WHERE ten_dang_nhap = @username
		END
		ELSE
			UPDATE NGUOIDUNG SET mat_khau = @newPassword WHERE ten_dang_nhap = @username
	END
END
GO

CREATE PROCEDURE USP_GetAccount
AS
BEGIN
    SELECT 
        ma_nguoi_dung, 
        ten_dang_nhap, 
        ten, 
        vai_tro, 
        email, 
        sdt
    FROM NGUOIDUNG
END
GO

--TẠO BẢNG CÔNG TY
CREATE TABLE CongTy (
    ma_cong_ty VARCHAR(50) PRIMARY KEY,
    ten_cong_ty NVARCHAR(255) NOT NULL,
    ki_hieu_cong_ty NVARCHAR(50) NOT NULL,
    ten_nguoi_dai_dien NVARCHAR(255),
    sdt NVARCHAR(15),
    dia_chi NVARCHAR(500)
);
GO

INSERT INTO CongTy (ma_cong_ty, ten_cong_ty, ki_hieu_cong_ty, ten_nguoi_dai_dien, sdt, dia_chi)
VALUES 
	('CT01',N'CTCP Bột giặt Lix','LIXCO',N'Phan Văn Đạt','0935540766',N'Số 3 đường số 2, P.Linh Trung,TP.Thủ Đức,TP.HCM'),
    ('CT02', N'Công Ty A', 'CTA', N'Nguyễn Văn A', '0901234567', N'123 Đường ABC, Hà Nội'),
    ('CT03', N'Công Ty B', 'CTB', N'Trần Thị B', '0912345678', N'456 Đường XYZ, TP.HCM'),
    ('CT04', N'Công Ty C', 'CTC', N'Phạm Văn C', '0923456789', N'789 Đường DEF, Đà Nẵng'),
	('CT05', N'Công Ty D', 'CTD', N'Lê Thị D', '0931111222', N'12 Đường GHJ, Hải Phòng'),
    ('CT06', N'Công Ty E', 'CTE', N'Hoàng Văn E', '0942222333', N'34 Đường KLM, Cần Thơ'),
    ('CT07', N'Công Ty F', 'CTF', N'Võ Thị F', '0953333444', N'56 Đường OPQ, Huế'),
    ('CT08', N'Công Ty G', 'CTG', N'Bùi Văn G', '0964444555', N'78 Đường RST, Nha Trang'),
    ('CT09', N'Công Ty H', 'CTH', N'Ngô Thị H', '0975555666', N'90 Đường UVW, Bình Dương'),
    ('CT10', N'Công Ty I', 'CTI', N'Đinh Văn I', '0986666777', N'11 Đường XYZ, Đồng Nai'),
    ('CT11', N'Công Ty J', 'CTJ', N'Đỗ Thị J', '0997777888', N'22 Đường ABC, Vũng Tàu'),
    ('CT12', N'Công Ty K', 'CTK', N'Phan Văn K', '0908888999', N'33 Đường DEF, Đà Lạt'),
    ('CT13', N'Công Ty L', 'CTL', N'Huỳnh Thị L', '0919999000', N'44 Đường GHI, Bến Tre'),
    ('CT14', N'Công Ty M', 'CTM', N'Lý Văn M', '0920000111', N'55 Đường JKL, Long An'),
    ('CT15', N'Công Ty N', 'CTN', N'Hồ Thị N', '0931111222', N'66 Đường MNO, Tiền Giang'),
    ('CT16', N'Công Ty O', 'CTO', N'Cao Văn O', '0942226933', N'77 Đường PQR, Hậu Giang'),
    ('CT17', N'Công Ty P', 'CTP', N'Vũ Thị P', '0953333444', N'88 Đường STU, Sóc Trăng'),
    ('CT18', N'Công Ty Q', 'CTQ', N'Mai Văn Q', '0964444555', N'99 Đường VWX, An Giang'),
    ('CT19', N'Công Ty R', 'CTR', N'Tô Thị R', '0975555666', N'100 Đường YZA, Kiên Giang'),
    ('CT20', N'Công Ty S', 'CTS', N'Nguyễn Văn S', '0986666777', N'101 Đường BCD, Đồng Tháp'),
    ('CT21', N'Công Ty T', 'CTT', N'Châu Thị T', '0997777888', N'102 Đường EFG, Cà Mau'),
    ('CT22', N'Công Ty U', 'CTU', N'Trương Văn U', '0908888999', N'103 Đường HIJ, Tây Ninh'),
    ('CT23', N'Công Ty V', 'CTV', N'Trịnh Thị V', '0919999000', N'104 Đường KLM, Quảng Ninh'),
    ('CT24', N'Công Ty W', 'CTW', N'Đào Văn W', '0920000111', N'105 Đường NOP, Bắc Ninh'),
    ('CT25', N'Công Ty X', 'CTX', N'Nguyễn Thị X', '0931111222', N'106 Đường QRS, Hải Dương'),
    ('CT26', N'Công Ty Y', 'CTY', N'Tống Văn Y', '0942222333', N'107 Đường TUV, Nam Định'),
    ('CT27', N'Công Ty Z', 'CTZ', N'Phan Thị Z', '0953333444', N'108 Đường WXY, Thái Bình'),
    ('CT28', N'Công Ty AA', 'CTAA', N'Đặng Văn AA', '0964444555', N'109 Đường ZAB, Bắc Giang'),
    ('CT29', N'Công Ty BB', 'CTBB', N'Hứa Thị BB', '0975555666', N'110 Đường CDE, Thanh Hóa'),
    ('CT30', N'Công Ty CC', 'CTCC', N'Phùng Văn CC', '0986666777', N'111 Đường FGH, Nghệ An'),
    ('CT31', N'Công Ty DD', 'CTDD', N'Ngô Văn DD', '0997777888', N'112 Đường IJK, Hà Tĩnh'),
    ('CT32', N'Công Ty EE', 'CTEE', N'Lâm Thị EE', '0908888999', N'113 Đường LMN, Quảng Bình'),
    ('CT33', N'Công Ty FF', 'CTFF', N'Hồ Văn FF', '0919999000', N'114 Đường OPQ, Quảng Trị'),
    ('CT34', N'Công Ty GG', 'CTGG', N'Nguyễn Văn GG', '0920000111', N'115 Đường RST, Thừa Thiên Huế'),
    ('CT35', N'Công Ty HH', 'CTHH', N'Lê Văn HH', '0931111222', N'116 Đường UVW, Quảng Ngãi'),
    ('CT36', N'Công Ty II', 'CTII', N'Hoàng Văn II', '0942222333', N'117 Đường XYZ, Bình Định'),
    ('CT37', N'Công Ty JJ', 'CTJJ', N'Võ Văn JJ', '0953333444', N'118 Đường ABC, Phú Yên');
GO

--TẠO BẢNG HỢP ĐỒNG
CREATE TABLE HopDong (
    ma_hop_dong VARCHAR(50) PRIMARY KEY,
    ma_cong_ty VARCHAR(50),
    ngay_ki_HD DATE NOT NULL,
    FOREIGN KEY (ma_cong_ty) REFERENCES CongTy(ma_cong_ty) ON DELETE CASCADE
);
GO

INSERT INTO HopDong (ma_hop_dong, ma_cong_ty, ngay_ki_HD)
VALUES 
	('HD001','CT01','2025-02-13'),
    ('HD002', 'CT01', '2024-02-10'),
    ('HD003', 'CT01', '2024-05-15'),
    ('HD004', 'CT02', '2024-03-20'),
    ('HD005', 'CT03', '2024-04-05'),
	('HD006', 'CT02', '2024-06-18'),
    ('HD007', 'CT02', '2024-07-22'),
    ('HD008', 'CT03', '2024-08-15'),
    ('HD009', 'CT03', '2024-09-30'),
    ('HD010', 'CT04', '2024-10-10'),
    ('HD011', 'CT04', '2024-11-25'),
    ('HD012', 'CT05', '2024-12-05'),
    ('HD013', 'CT05', '2025-01-17'),
    ('HD014', 'CT06', '2025-02-20'),
    ('HD015', 'CT06', '2025-03-22'),
    ('HD016', 'CT07', '2025-04-18'),
    ('HD017', 'CT07', '2025-05-25'),
    ('HD018', 'CT08', '2025-06-30'),
    ('HD019', 'CT08', '2025-07-15'),
    ('HD020', 'CT09', '2025-08-10'),
    ('HD021', 'CT09', '2025-09-05'),
    ('HD022', 'CT10', '2025-10-28'),
    ('HD023', 'CT10', '2025-11-11'),
    ('HD024', 'CT11', '2025-12-20'),
    ('HD025', 'CT11', '2026-01-05');
GO

CREATE PROC USP_GetHopDongList
AS
BEGIN
    SELECT
		HopDong.ma_hop_dong AS MaHD,
        ct.ten_cong_ty AS TenCT,
        ct.ki_hieu_cong_ty AS KyHieuCT,
        ct.ma_cong_ty AS MaCT,
        HopDong.ngay_ki_HD AS NgayHD,
        ct.ten_nguoi_dai_dien AS TenDaiDien,
        ct.sdt AS Sdt,
        ct.dia_chi AS DiaChi
    FROM dbo.HopDong
	INNER JOIN dbo.CongTy ct ON HopDong.ma_cong_ty = ct.ma_cong_ty
    ORDER BY HopDong.ngay_ki_HD DESC;
END;
GO

CREATE PROC USP_InsertHopDong
	@MaHD VARCHAR(50),
    @MaCT VARCHAR(50), 
    @TenCT NVARCHAR(255), 
    @KyHieuCT NVARCHAR(50), 
    @NgayHD DATE, 
    @TenDaiDien NVARCHAR(255), 
    @Sdt NVARCHAR(15), 
    @DiaChi NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM HopDong WHERE ma_hop_dong = @MaHD)
    BEGIN
        INSERT INTO CongTy (ma_cong_ty, ten_cong_ty, ki_hieu_cong_ty, ten_nguoi_dai_dien, sdt, dia_chi)
        VALUES (@MaCT, @TenCT, @KyHieuCT, @TenDaiDien, @Sdt, @DiaChi);
    END
    INSERT INTO HopDong (ma_hop_dong, ma_cong_ty, ngay_ki_HD)
    VALUES (@MaHD, @MaCT, @NgayHD);
END;
GO

CREATE PROC USP_UpdateHopDong
    @MaHD VARCHAR(50),
    @MaCT VARCHAR(50),
    @TenCT NVARCHAR(255), 
    @KyHieuCT NVARCHAR(50), 
    @NgayHD DATE, 
    @TenDaiDien NVARCHAR(255), 
    @Sdt NVARCHAR(15), 
    @DiaChi NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CongTy
    SET ten_cong_ty = @TenCT, 
        ki_hieu_cong_ty = @KyHieuCT, 
        ten_nguoi_dai_dien = @TenDaiDien, 
        sdt = @Sdt, 
        dia_chi = @DiaChi
    WHERE ma_cong_ty = @MaCT;
    UPDATE HopDong
    SET ngay_ki_HD = @NgayHD
    WHERE ma_hop_dong = @MaHD;
END;
GO

CREATE PROC USP_DeleteHopDong
    @MaHD VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM HopDong WHERE ma_hop_dong = @MaHD;
END;
GO

CREATE PROC USP_SearchHopDong
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        HD.ma_hop_dong AS MaHD,
        ct.ten_cong_ty AS TenCT,
        ct.ki_hieu_cong_ty AS KyHieuCT,
        ct.ma_cong_ty AS MaCT,
        HD.ngay_ki_HD AS NgayHD,
        ct.ten_nguoi_dai_dien AS TenDaiDien,
        ct.sdt AS Sdt,
        ct.dia_chi AS DiaChi
    FROM 
        HopDong HD
        INNER JOIN CongTy ct ON HD.ma_cong_ty = ct.ma_cong_ty
    WHERE 
        HD.ma_hop_dong LIKE N'%' + @Keyword + '%'
		OR ct.ma_cong_ty LIKE N'%' + @Keyword + '%'
        OR ct.ten_cong_ty LIKE N'%' + @Keyword + '%'
        OR ct.ki_hieu_cong_ty LIKE N'%' + @Keyword + '%'
	ORDER BY HD.ngay_ki_HD DESC;
END;
GO

--TẠO BẢNG ĐƠN HÀNG
CREATE TABLE DonHang (
    ma_don_hang VARCHAR(10) PRIMARY KEY,
	ma_hop_dong VARCHAR(50) FOREIGN KEY REFERENCES HopDong(ma_hop_dong) ON DELETE CASCADE,
    ngay_bat_dau_lay_mau DATE NOT NULL,
    ngay_tra_ket_qua_du_kien DATE NOT NULL,
    quy INT CHECK (quy >= 1 AND quy <= 4),
    trang_thai NVARCHAR(50) CHECK (trang_thai IN (N'Đang xử lý', N'Hoàn thành', N'Quá hạn')) NOT NULL,
);
GO

-- Thêm dữ liệu mẫu vào bảng DonHang
INSERT INTO DonHang (ma_don_hang, ma_hop_dong, ngay_bat_dau_lay_mau, ngay_tra_ket_qua_du_kien, quy, trang_thai)
VALUES
('25.001', 'HD001', '2025-01-05', '2025-01-20', 1, N'Đang xử lý'),
('25.002', 'HD002', '2025-01-10', '2025-01-25', 1, N'Hoàn thành'),
('25.003', 'HD003', '2025-02-15', '2025-03-01', 1, N'Quá hạn'),
('25.004', 'HD004', '2025-03-05', '2025-03-20', 1, N'Đang xử lý'),
('25.005', 'HD005', '2025-04-01', '2025-04-15', 2, N'Hoàn thành'),
('25.006', 'HD006', '2025-04-10', '2025-04-25', 2, N'Đang xử lý'),
('25.007', 'HD007', '2025-05-01', '2025-05-15', 2, N'Quá hạn'),
('25.008', 'HD008', '2025-05-12', '2025-05-27', 2, N'Hoàn thành'),
('25.009', 'HD009', '2025-06-05', '2025-06-20', 2, N'Đang xử lý'),
('25.010', 'HD010', '2025-06-15', '2025-07-01', 2, N'Quá hạn'),
('25.011', 'HD011', '2025-07-03', '2025-07-18', 3, N'Đang xử lý'),
('25.012', 'HD012', '2025-07-12', '2025-07-27', 3, N'Hoàn thành'),
('25.013', 'HD013', '2025-08-02', '2025-08-17', 3, N'Đang xử lý'),
('25.014', 'HD014', '2025-08-20', '2025-09-05', 3, N'Quá hạn'),
('25.015', 'HD015', '2025-09-10', '2025-09-25', 3, N'Hoàn thành'),
('25.016', 'HD016', '2025-09-18', '2025-10-03', 3, N'Đang xử lý'),
('25.017', 'HD017', '2025-10-05', '2025-10-20', 4, N'Hoàn thành'),
('25.018', 'HD018', '2025-10-12', '2025-10-27', 4, N'Quá hạn'),
('25.019', 'HD019', '2025-11-03', '2025-11-18', 4, N'Đang xử lý'),
('25.020', 'HD020', '2025-11-12', '2025-11-27', 4, N'Hoàn thành'),
('25.021', 'HD021', '2025-12-01', '2025-12-16', 4, N'Đang xử lý'),
('25.022', 'HD022', '2025-12-10', '2025-12-25', 4, N'Quá hạn'),
('25.023', 'HD023', '2025-12-15', '2025-12-30', 4, N'Hoàn thành'),
('25.024', 'HD024', '2025-06-25', '2025-07-10', 2, N'Đang xử lý'),
('25.025', 'HD025', '2025-07-01', '2025-07-16', 3, N'Quá hạn');
GO

CREATE PROCEDURE USP_GenerateMaDonHang
    @NewMaDonHang VARCHAR(10) OUTPUT
AS
BEGIN
    DECLARE @YearCode VARCHAR(2)
    DECLARE @NextNumber INT
    DECLARE @NextNumberStr VARCHAR(3)
    SET @YearCode = RIGHT(YEAR(GETDATE()), 2)
    SELECT @NextNumber = ISNULL(MAX(CAST(SUBSTRING(ma_don_hang, 4, 3) AS INT)), 0) + 1
    FROM DonHang
    WHERE ma_don_hang LIKE @YearCode + '.%'
    SET @NextNumberStr = RIGHT('000' + CAST(@NextNumber AS VARCHAR), 3)
    SET @NewMaDonHang = @YearCode + '.' + @NextNumberStr
END
GO

CREATE PROC USP_GetDonHangList
AS
BEGIN
    SELECT
		ma_hop_dong AS MaHD,
        ma_don_hang AS MaDH,
        ngay_bat_dau_lay_mau AS NgayLM,
        ngay_tra_ket_qua_du_kien AS NgayKQ,
        quy AS Quy,
		trang_thai AS Trangthai
    FROM DonHang
    ORDER BY ma_don_hang DESC;
END;
GO

CREATE PROC USP_InsertDonHang
    @MaDonHang VARCHAR(10),
    @MaHopDong VARCHAR(50),
    @NgayBatDauLayMau DATE,
    @NgayTraKetQuaDuKien DATE,
    @Quy INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DonHang (ma_don_hang, ma_hop_dong, ngay_bat_dau_lay_mau, ngay_tra_ket_qua_du_kien, quy, trang_thai)
    VALUES (@MaDonHang, @MaHopDong, @NgayBatDauLayMau, @NgayTraKetQuaDuKien, @Quy, @TrangThai);
END;
GO

CREATE PROC USP_DeleteDonHang
    @MaDonHang VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM DonHang WHERE ma_don_hang = @MaDonHang;
END;
GO

CREATE PROC USP_UpdateDonHang
    @MaDonHang VARCHAR(10),
    @NgayBatDauLayMau DATE,
    @NgayTraKetQuaDuKien DATE,
    @Quy INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DonHang
    SET ngay_bat_dau_lay_mau = @NgayBatDauLayMau,
        ngay_tra_ket_qua_du_kien = @NgayTraKetQuaDuKien,
        quy = @Quy,
        trang_thai = @TrangThai
    WHERE ma_don_hang = @MaDonHang;
END;
GO

CREATE PROC USP_SearchDonHang
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
		ma_hop_dong AS MaHD,
        ma_don_hang AS MaDH,
        ngay_bat_dau_lay_mau AS NgayLM,
        ngay_tra_ket_qua_du_kien AS NgayKQ,
        quy AS Quy,
		trang_thai AS Trangthai
    FROM DonHang
    WHERE 
		ma_hop_dong LIKE N'%' + @Keyword + '%'
        OR ma_don_hang LIKE N'%' + @Keyword + '%'
        OR CAST(ngay_bat_dau_lay_mau AS NVARCHAR) LIKE '%' + @Keyword + '%'
        OR CAST(ngay_tra_ket_qua_du_kien AS NVARCHAR) LIKE '%' + @Keyword + '%'
        OR CAST(quy AS NVARCHAR) LIKE '%' + @Keyword + '%'
		OR trang_thai LIKE N'%' + @Keyword + '%'
    ORDER BY ngay_bat_dau_lay_mau DESC;
END;
GO

--TẠO BẢNG VỊ TRÍ LẤY MẪU
CREATE TABLE ViTriLayMau (
    ma_don_hang VARCHAR(50) FOREIGN KEY REFERENCES DonHang(ma_don_hang) ON DELETE CASCADE,
    ma_vi_tri VARCHAR(50) PRIMARY KEY,
    loai_vi_tri NVARCHAR(50) CHECK (loai_vi_tri IN (N'Đất', N'Nước', N'Không khí', N'Khí thải')) NOT NULL,
    ten_vi_tri NVARCHAR(255)
);
GO

-- TẠO BẢNG THÔNG SỐ MÔI TRƯỜNG
CREATE TABLE ThongSoMoiTruong (
    ma_thong_so VARCHAR(50) PRIMARY KEY,
    ma_vi_tri VARCHAR(50) FOREIGN KEY REFERENCES ViTriLayMau(ma_vi_tri) ON DELETE CASCADE,
    STT INT IDENTITY(1,1),                --#
    ten_thong_so NVARCHAR(255) NOT NULL,  -- Chỉ tiêu 
    don_vi NVARCHAR(50),                  -- Đơn vị đo (mg/L, °C, ...)
    ma_mau_phu NVARCHAR(50),              -- Mã mẫu phụ
    ket_qua FLOAT,                        -- Kết quả đo
    TT INT,                               -- Thứ tự
    an_lan_quan_trac BIT DEFAULT 0,       -- Ẩn lần quan trắc
    loai NVARCHAR(10),                    -- Loại (HT, p.TN)
    nguoi_phan_tich NVARCHAR(255),        -- Người phân tích
    thau_phu NVARCHAR(255),               -- Đơn vị thực hiện phân tích
    ngay_do DATETIME DEFAULT GETDATE(),   -- Ngày đo
    gia_tri_quy_chuan_TCVN NVARCHAR(255), -- Giá trị quy chuẩn TCVN
    ket_luan NVARCHAR(MAX)                -- Kết luận
);
GO








SELECT * FROM NGUOIDUNG
SELECT * FROM CongTy
SELECT * FROM HopDong



SELECT 
    ma_don_hang AS [Mã đơn hàng],
    ma_hop_dong AS [Mã hợp đồng],
    ngay_bat_dau_lay_mau AS [Ngày bắt đầu lấy mẫu],
    ngay_tra_ket_qua_du_kien AS [Ngày trả kết quả dự kiến],
    quy AS [Quý],
    trang_thai AS [Trạng thái]
FROM DonHang
INSERT INTO DonHang VALUES
(N'DH01',N'HD01','02/15/2025','02/25/2025',1,N'Đang xử lý')
SELECT * FROM DonHang



INSERT INTO ViTriLayMau VALUES
('DH01','Đ1',N'Đất',N'Đất khuân viên xưởng'),
('DH01','NT1',N'Nước',N'Nước thải trước khi xử lý'),
('DH01','NT2',N'Nước',N'Nước thải sau khi xử lý'),
('DH01','KK1',N'Không Khí',N'Mẫu không khí đầu xưởng'),
('DH01','KK2',N'Không khí',N'Mẫu không khí giữa xưởng'),
('DH01','KK3',N'Không khí',N'Mẫu không khí cuối xưởng')
SELECT * FROM ViTriLayMau


-- NHẬP NƯỚC THẢI TRƯỚC KHI XỬ LÝ KÍ HIỆU NT1
INSERT INTO ThongSoMoiTruong (
    ma_thong_so, ma_vi_tri, ten_thong_so, don_vi, ma_mau_phu, 
    ket_qua, TT, an_lan_quan_trac, loai, nguoi_phan_tich, 
    thau_phu, ngay_do, gia_tri_quy_chuan_TCVN, ket_luan
) VALUES
('TS01', 'NT1', '+pH 2024-HT', '-', NULL, 1, NULL, 0, 'HT', NULL, NULL, '2025-02-15', '5.5-9.0', NULL),
('TS02', 'NT1', N'Nhiệt độ 2024-HT', N'℃', NULL, 2, NULL, 0, 'HT', NULL, NULL, '2025-02-15', '≤ 40°C', NULL),
('TS03', 'NT1', N'+Lưu lượng 2024-HT', 'm³/h', NULL, 5, NULL, 0, 'HT', NULL, NULL, '2025-02-15', N'Không có quy chuẩn chung, tùy vào hệ thống', NULL),
('TS04', 'NT1',N'+Độ màu 2024-HT', 'Pt-Co', NULL, 8, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 150', NULL),
('TS05', 'NT1', N'+Nhu cầu oxy sinh học(BOD₅) 2024', 'mg/L', NULL, 10, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 30', NULL),
('TS06', 'NT1',N'+Nhu cầu oxy hóa học(COD)5220C 2024', 'mg/L', NULL, 12, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 75', NULL),
('TS07', 'NT1', N'+Tổng chất rắn lơ lửng(TSS) 2024', 'mg/L', NULL, 13, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 50', NULL),
('TS08', 'NT1', N'+Tổng dầu mỡ khoáng 2024', 'mg/L', NULL, 16, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 5', NULL),
('TS09', 'NT1', N'+Amoni(NH₄⁺ tính theo N) 2024', 'mg/L', NULL, 20, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 5', NULL),
('TS10', 'NT1', N'+Tổng N 2024', 'mg/L', NULL, 23, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 20', NULL),
('TS11', 'NT1', N'+Tổng P 2024', 'mg/L', NULL, 25, NULL, 0, 'p.TN', NULL, NULL, '2025-02-15', '≤ 4', NULL);

-- HIỂN THỊ DỮ LIỆU
SELECT 
    ma_thong_so AS [Mã thông số],
    ma_vi_tri AS [Mã vị trí],
    STT AS [#],
    ten_thong_so AS [Tên thông số],
    don_vi AS [Đơn vị],
    ma_mau_phu AS [Mã mẫu phụ],
    ket_qua AS [Kết quả đo],
    TT AS [Thứ tự],
    an_lan_quan_trac AS [Ẩn lần quan trắc],
    loai AS [Loại],
    nguoi_phan_tich AS [Người phân tích],
    thau_phu AS [Đơn vị thực hiện],
    ngay_do AS [Ngày đo],
    gia_tri_quy_chuan_TCVN AS [Giá trị quy chuẩn TCVN],
    ket_luan AS [Kết luận]
FROM ThongSoMoiTruong;


