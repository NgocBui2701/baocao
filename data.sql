CREATE DATABASE QUAN_LY_DON_HANG_MOI_TRUONG
GO
USE QUAN_LY_DON_HANG_MOI_TRUONG
GO
--TẠO BẢNG CÔNG TY
CREATE TABLE CongTy (
    ma_cong_ty VARCHAR(50) PRIMARY KEY NOT NULL,
    ten_cong_ty NVARCHAR(255) NOT NULL,
    ki_hieu_cong_ty NVARCHAR(50) NOT NULL,
    ten_nguoi_dai_dien NVARCHAR(255),
    sdt NVARCHAR(15) CHECK (sdt IS NULL OR (LEN(sdt) IN (10, 11) AND PATINDEX('%[^0-9]%', sdt) = 0)),
    dia_chi NVARCHAR(500)
);
GO
INSERT INTO CongTy (ma_cong_ty, ten_cong_ty, ki_hieu_cong_ty, ten_nguoi_dai_dien, sdt, dia_chi)  
VALUES  ('0101234567', N'Công ty TNHH Môi Trường Xanh', 'MTX', N'Nguyễn Văn Hùng', '0912345678', N'12 Nguyễn Trãi, Hà Nội'),  
		('0101234568', N'Công ty CP Phân Tích Môi Trường Việt', 'MTV', N'Trần Thị Mai', '0923456789', N'45 Lý Thường Kiệt, TP. Hồ Chí Minh'),  
		('0101234569', N'Công ty TNHH Dịch Vụ Quan Trắc Môi Trường', 'QMT', N'Lê Minh Tuấn', '0934567890', N'78 Phan Đình Phùng, Đà Nẵng'),  
		('0101234570', N'Công ty CP Kiểm Định Môi Trường', 'KMT', N'Phạm Văn Hoàng', '0945678901', N'23 Lê Lợi, Hải Phòng'),  
		('0101234571', N'Công ty TNHH Tư Vấn & Giám Sát Môi Trường', 'GSM', N'Hoàng Thị Hạnh', '0956789012', N'56 Hai Bà Trưng, Cần Thơ'),  
		('0101234572', N'Công ty CP Khoa Học & Công Nghệ Môi Trường', 'KCM', N'Nguyễn Thành Đạt', '0967890123', N'89 Nguyễn Huệ, Huế'),  
		('0101234573', N'Công ty TNHH Công Nghệ Sinh Học & Môi Trường', 'CSM', N'Đặng Thị Kim Oanh', '0978901234', N'12 Nguyễn Văn Cừ, Quảng Ninh'),  
		('0101234574', N'Công ty CP Đo Lường & Phân Tích Môi Trường', 'DLM', N'Võ Minh Phúc', '0989012345', N'34 Trần Hưng Đạo, Đà Lạt'),  
		('0101234575', N'Công ty TNHH Bảo Vệ Tài Nguyên & Môi Trường', 'BMT', N'Bùi Thị Thanh Trúc', '0990123456', N'67 Lý Tự Trọng, Nha Trang'),  
		('0101234576', N'Công ty CP Nghiên Cứu & Ứng Dụng Môi Trường', 'NAM', N'Ngô Văn Đức', '0901234567', N'21 Trần Quang Khải, Bình Dương'),  
		('0101234577', N'Công ty TNHH Giải Pháp Môi Trường', 'GPM', N'Lý Hoàng Nam', '0912233445', N'23 Nguyễn Hữu Cảnh, Biên Hòa'),  
		('0101234578', N'Công ty CP Xử Lý Chất Thải & Quan Trắc Môi Trường', 'XMT', N'Đoàn Văn Thịnh', '0923344556', N'15 Pasteur, Vũng Tàu'),  
		('0101234579', N'Công ty TNHH Phát Triển Công Nghệ Xanh', 'CNX', N'La Thanh Tùng', '0934455667', N'55 Hoàng Văn Thụ, Bắc Ninh'),  
		('0101234580', N'Công ty CP Tài Nguyên & Phát Triển Môi Trường', 'TNM', N'Huỳnh Thị Lan', '0945566778', N'43 Điện Biên Phủ, Nam Định'),  
		('0101234581', N'Công ty TNHH Môi Trường Toàn Cầu', 'MTT', N'Tôn Nữ Thu Hằng', '0956677889', N'99 Nguyễn Thị Minh Khai, Quy Nhơn'),  
		('0101234582', N'Công ty CP Kiểm Soát Ô Nhiễm', 'KSO', N'Đinh Văn Hào', '0967788990', N'88 Nguyễn An Ninh, Vinh'),  
		('0101234583', N'Công ty TNHH Công Nghệ Xử Lý Nước', 'XLN', N'Hoàng Thị Bích Ngọc', '0978899001', N'45 Võ Văn Kiệt, Bạc Liêu'),  
		('0101234584', N'Công ty CP Quan Trắc & Kiểm Nghiệm Môi Trường', 'QKM', N'Phạm Ngọc Sơn', '0989900112', N'56 Nguyễn Trãi, Sóc Trăng'),  
		('0101234585', N'Công ty TNHH Dịch Vụ & Tư Vấn Môi Trường', 'TVM', N'Nguyễn Xuân Quang', '0991001123', N'78 Trần Nhật Duật, Cà Mau'),  
		('0101234586', N'Công ty CP Ứng Dụng Công Nghệ Môi Trường', 'UCT', N'Lý Hữu Dũng', '0902112233', N'23 Lý Văn Phức, Thanh Hóa');  
GO
CREATE PROC USP_GetCongTyList
AS
BEGIN
    SELECT
        ma_cong_ty AS MaCT,
        ten_cong_ty AS TenCT,
        ki_hieu_cong_ty AS KyHieuCT,
        ten_nguoi_dai_dien AS TenDaiDien,
        sdt AS Sdt,
        dia_chi AS DiaChi
    FROM CongTy
    ORDER BY ten_cong_ty ASC
END;
GO
CREATE PROC USP_GetCongTyByMaCongTy
    @MaCT VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ma_cong_ty AS MaCT,
        ten_cong_ty AS TenCT,
        ki_hieu_cong_ty AS KyHieuCT,
        ten_nguoi_dai_dien AS TenDaiDien,
        sdt AS Sdt,
        dia_chi AS DiaChi
    FROM CongTy 
    WHERE ma_cong_ty = @MaCT
	ORDER BY ten_cong_ty ASC
END;
GO
CREATE PROC USP_SearchCongTy
    @keyword NVARCHAR(255)
AS
BEGIN
    SELECT
        ma_cong_ty AS MaCT,
        ten_cong_ty AS TenCT,
        ki_hieu_cong_ty AS KyHieuCT,
        ten_nguoi_dai_dien AS TenDaiDien,
        sdt AS Sdt,
        dia_chi AS DiaChi
    FROM CongTy
    WHERE ten_cong_ty LIKE '%' + @keyword + '%'
       OR ki_hieu_cong_ty LIKE '%' + @keyword + '%'
       OR ten_nguoi_dai_dien LIKE '%' + @keyword + '%'
	ORDER BY ten_cong_ty ASC
END;
GO
CREATE PROC USP_InsertCongTy
    @MaCT VARCHAR(50),
    @TenCT NVARCHAR(255),
    @KyHieuCT NVARCHAR(50),
    @TenDaiDien NVARCHAR(255),
    @Sdt NVARCHAR(15),
    @DiaChi NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO CongTy (ma_cong_ty, ten_cong_ty, ki_hieu_cong_ty, ten_nguoi_dai_dien, sdt, dia_chi)
        VALUES (@MaCT, @TenCT, @KyHieuCT, @TenDaiDien, @Sdt, @DiaChi);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_UpdateCongTy
    @MaCT VARCHAR(50),
    @TenCT NVARCHAR(255),
    @KyHieuCT NVARCHAR(50),
    @TenDaiDien NVARCHAR(255),
    @Sdt NVARCHAR(15),
    @DiaChi NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
        UPDATE CongTy
        SET ten_cong_ty = @TenCT,
            ki_hieu_cong_ty = @KyHieuCT,
            ten_nguoi_dai_dien = @TenDaiDien,
            sdt = @Sdt,
            dia_chi = @DiaChi
        WHERE ma_cong_ty = @MaCT;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_DeleteCongTy
    @MaCT VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
        DELETE FROM CongTy WHERE ma_cong_ty = @MaCT;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
--TẠO BẢNG HỢP ĐỒNG
CREATE TABLE HopDong (
    ma_hop_dong VARCHAR(50) PRIMARY KEY NOT NULL,
    ma_cong_ty VARCHAR(50) NOT NULL,
    ngay_ki_HD DATE NOT NULL,
    CONSTRAINT FK_HopDong_CongTy 
        FOREIGN KEY (ma_cong_ty) 
        REFERENCES CongTy(ma_cong_ty) 
        ON DELETE NO ACTION
);
GO
INSERT INTO HopDong (ma_hop_dong, ma_cong_ty, ngay_ki_HD) 
VALUES  ('HD240001', '0101234567', '2024-02-01'),
		('HD240002', '0101234568', '2024-02-15'),
		('HD240003', '0101234569', '2024-03-04'),
		('HD240004', '0101234570', '2024-03-06'),
		('HD240005', '0101234571', '2024-03-10'),
		('HD240006', '0101234572', '2024-04-13'),
		('HD240007', '0101234573', '2024-04-19'),
		('HD240008', '0101234574', '2024-05-05'),
		('HD240009', '0101234575', '2024-05-20'),
		('HD240010', '0101234576', '2024-06-09'),
		('HD240011', '0101234577', '2024-06-16'),
		('HD240012', '0101234578', '2024-07-18'),
		('HD240013', '0101234579', '2024-07-22'),
		('HD240014', '0101234580', '2024-08-03'),
		('HD240015', '0101234581', '2024-08-09'),
		('HD240016', '0101234582', '2024-09-10'),
		('HD240017', '0101234583', '2024-09-20'),
		('HD240018', '0101234584', '2024-10-05'),
		('HD240019', '0101234585', '2024-11-03'),
		('HD240020', '0101234586', '2024-01-02'),
		('HD250001', '0101234567', '2025-01-02'),
		('HD250002', '0101234568', '2025-01-10'),
		('HD250003', '0101234569', '2025-01-12'),
		('HD250004', '0101234570', '2025-01-13'),
		('HD250005', '0101234571', '2025-01-25'),
		('HD250006', '0101234572', '2025-02-13'),
		('HD250007', '0101234573', '2025-02-14');
GO
CREATE PROC USP_GenerateMaHopDong
    @NewMaHopDong VARCHAR(50) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
    DECLARE @YearCode VARCHAR(2) = RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR), 2);
    DECLARE @NextNumber INT;
    SELECT @NextNumber = ISNULL(MAX(TRY_CAST(RIGHT(ma_hop_dong, 4) AS INT)), 0) + 1
    FROM HopDong
    WHERE ma_hop_dong LIKE 'HD' + @YearCode + '%';
    IF @NextNumber > 9999
        RAISERROR(N'Số lượng hợp đồng đã vượt quá giới hạn trong năm!', 16, 1);
    ELSE
        SET @NewMaHopDong = 'HD' + @YearCode + RIGHT('0000' + CAST(@NextNumber AS VARCHAR), 4);
END
GO
CREATE PROC USP_GetHopDongList
AS
BEGIN
    SELECT
		HD.ma_hop_dong AS MaHD,
        ct.ten_cong_ty AS TenCT,
        ct.ki_hieu_cong_ty AS KyHieuCT,
        ct.ma_cong_ty AS MaCT,
        HD.ngay_ki_HD AS NgayHD,
        ct.ten_nguoi_dai_dien AS TenDaiDien,
        ct.sdt AS Sdt,
        ct.dia_chi AS DiaChi
    FROM HopDong HD
	INNER JOIN CongTy ct ON HD.ma_cong_ty = ct.ma_cong_ty
    ORDER BY HD.ngay_ki_HD DESC
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
    FROM HopDong HD
    INNER JOIN CongTy ct ON HD.ma_cong_ty = ct.ma_cong_ty
    WHERE 
        HD.ma_hop_dong LIKE '%' + @Keyword + '%'
		OR ct.ma_cong_ty LIKE '%' + @Keyword + '%'
        OR ct.ten_cong_ty LIKE N'%' + @Keyword + '%'
        OR ct.ki_hieu_cong_ty LIKE N'%' + @Keyword + '%'
	ORDER BY HD.ngay_ki_HD DESC
END;
GO
CREATE PROC USP_InsertHopDong
	@MaHD VARCHAR(50),
    @MaCT VARCHAR(50), 
    @NgayHD DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO HopDong (ma_hop_dong, ma_cong_ty, ngay_ki_HD)
        VALUES (@MaHD, @MaCT, @NgayHD);
    END TRY
    BEGIN CATCH
        THROW; 
    END CATCH;
END;
GO
CREATE PROC USP_UpdateHopDong
    @MaHD VARCHAR(50),
    @MaCT VARCHAR(50),
    @NgayHD DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE HopDong
        SET ma_cong_ty = @MaCT,
            ngay_ki_HD = @NgayHD
        WHERE ma_hop_dong = @MaHD;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_DeleteHopDong
    @MaHD VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM HopDong WHERE ma_hop_dong = @MaHD;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
--TẠO BẢNG ĐƠN HÀNG
CREATE TABLE DonHang (
    ma_don_hang VARCHAR(50) PRIMARY KEY NOT NULL,
    ma_hop_dong VARCHAR(50) NOT NULL,
    ngay_bat_dau_lay_mau DATE NOT NULL,
    ngay_tra_ket_qua_du_kien DATE NOT NULL,
    quy INT NOT NULL CHECK (quy BETWEEN 1 AND 4),
    trang_thai NVARCHAR(50) NOT NULL CHECK (trang_thai IN (N'Đang xử lý', N'Hoàn thành', N'Quá hạn')),
    CONSTRAINT FK_DonHang_HopDong 
        FOREIGN KEY (ma_hop_dong) 
        REFERENCES HopDong(ma_hop_dong) 
        ON DELETE NO ACTION
);
GO
INSERT INTO DonHang (ma_don_hang, ma_hop_dong, ngay_bat_dau_lay_mau, ngay_tra_ket_qua_du_kien, quy, trang_thai) 
VALUES 
    ('DH24000001', 'HD240001', '2024-02-02', '2024-02-12', 1, N'Hoàn thành'),
    ('DH24000002', 'HD240001', '2024-04-02', '2024-04-15', 2, N'Hoàn thành'),
    ('DH24000003', 'HD240001', '2024-07-05', '2024-07-19', 3, N'Hoàn thành'),
    ('DH24000004', 'HD240001', '2024-11-03', '2024-11-13', 4, N'Hoàn thành'),
    ('DH24000005', 'HD240002', '2024-02-16', '2024-02-26', 1, N'Hoàn thành'),
    ('DH24000006', 'HD240002', '2024-05-02', '2024-05-12', 2, N'Hoàn thành'),
    ('DH24000007', 'HD240002', '2024-11-01', '2024-11-15', 4, N'Hoàn thành'),
    ('DH24000008', 'HD240003', '2024-03-05', '2024-03-15', 1, N'Hoàn thành'),
    ('DH24000009', 'HD240003', '2024-07-05', '2024-07-20', 3, N'Hoàn thành'),
    ('DH24000010', 'HD240003', '2024-10-06', '2024-10-19', 4, N'Hoàn thành'),
    ('DH24000011', 'HD240004', '2024-03-07', '2024-03-17', 1, N'Hoàn thành'),
    ('DH24000012', 'HD240004', '2024-07-02', '2024-07-16', 3, N'Hoàn thành'),
    ('DH24000013', 'HD240004', '2024-12-02', '2024-12-12', 4, N'Hoàn thành'),
    ('DH24000014', 'HD240005', '2024-03-11', '2024-03-21', 1, N'Hoàn thành'),
    ('DH24000015', 'HD240005', '2024-09-01', '2024-09-12', 3, N'Hoàn thành'),
    ('DH24000016', 'HD240005', '2024-11-05', '2024-11-19', 4, N'Hoàn thành'),
    ('DH24000017', 'HD240006', '2024-04-14', '2024-04-24', 2, N'Hoàn thành'),
    ('DH24000018', 'HD240007', '2024-04-20', '2024-04-30', 2, N'Hoàn thành'),
    ('DH24000019', 'HD240008', '2024-05-06', '2024-05-16', 2, N'Hoàn thành'),
    ('DH24000020', 'HD240009', '2024-05-21', '2024-05-31', 2, N'Hoàn thành'),
    ('DH24000021', 'HD240010', '2024-06-10', '2024-06-20', 2, N'Hoàn thành'),
    ('DH24000022', 'HD240011', '2024-06-17', '2024-06-27', 2, N'Hoàn thành'),
    ('DH24000023', 'HD240012', '2024-07-19', '2024-07-29', 3, N'Hoàn thành'),
    ('DH24000024', 'HD240013', '2024-07-23', '2024-08-02', 3, N'Hoàn thành'),
    ('DH24000025', 'HD240014', '2024-08-04', '2024-08-14', 3, N'Hoàn thành'),
    ('DH24000026', 'HD240015', '2024-08-10', '2024-08-20', 3, N'Hoàn thành'),
    ('DH24000027', 'HD240016', '2024-09-11', '2024-09-21', 3, N'Hoàn thành'),
    ('DH24000028', 'HD240017', '2024-09-21', '2024-10-01', 3, N'Hoàn thành'),
    ('DH24000029', 'HD240018', '2024-10-06', '2024-10-16', 4, N'Hoàn thành'),
    ('DH24000030', 'HD240019', '2024-11-04', '2024-11-14', 4, N'Hoàn thành'),
    ('DH24000031', 'HD240020', '2024-12-13', '2024-12-23', 4, N'Hoàn thành'),
	('DH24000032', 'HD240010', '2024-12-20', '2024-12-29', 4, N'Quá hạn'),
	('DH24000033', 'HD240012', '2024-12-25', '2024-12-31', 4, N'Quá hạn'),
	('DH24000034', 'HD240013', '2024-12-29', '2025-01-05', 4, N'Quá hạn'),
	('DH25000001', 'HD250001', '2025-01-20', '2025-01-29', 1, N'Quá hạn'),
	('DH25000002', 'HD250002', '2025-01-24', '2025-02-03', 1, N'Quá hạn'),
	('DH25000003', 'HD250003', '2025-02-28', '2025-03-15', 1, N'Quá hạn'),
	('DH25000004', 'HD250004', '2025-03-10', '2025-03-22', 1, N'Đang xử lý'),
	('DH25000005', 'HD250005', '2025-03-10', '2025-03-16', 1, N'Hoàn thành'),
	('DH25000006', 'HD250006', '2025-03-10', '2025-03-20', 1, N'Hoàn thành'),
	('DH25000007', 'HD250007', '2025-03-10', '2025-03-17', 1, N'Hoàn thành');
GO
CREATE PROC USP_GenerateMaDonHang
    @NewMaDonHang VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @YearCode VARCHAR(2) = RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR), 2);
    DECLARE @NextNumber INT;
    SELECT @NextNumber = ISNULL(MAX(TRY_CAST(RIGHT(ma_don_hang, 6) AS INT)), 0) + 1
    FROM DonHang
    WHERE ma_don_hang LIKE 'DH' + @YearCode + '%';
    IF @NextNumber > 999999
        RAISERROR(N'Số lượng đơn hàng đã vượt quá giới hạn trong năm!', 16, 1);
    ELSE
        SET @NewMaDonHang = 'DH' + @YearCode + RIGHT('000000' + CAST(@NextNumber AS VARCHAR), 6);
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
		ma_hop_dong LIKE '%' + @Keyword + '%'
        OR ma_don_hang LIKE '%' + @Keyword + '%'
        OR CONVERT(NVARCHAR(10), ngay_bat_dau_lay_mau, 23) LIKE '%' + @Keyword + '%'
        OR CONVERT(NVARCHAR(10), ngay_tra_ket_qua_du_kien, 23) LIKE '%' + @Keyword + '%'
        OR CAST(quy AS NVARCHAR) LIKE '%' + @Keyword + '%'
		OR trang_thai LIKE N'%' + @Keyword + '%'
    ORDER BY ngay_bat_dau_lay_mau DESC;
END;
GO
CREATE PROC USP_InsertDonHang
    @MaDonHang VARCHAR(50),
    @MaHopDong VARCHAR(50),
    @NgayBatDauLayMau DATE,
    @NgayTraKetQuaDuKien DATE,
    @Quy INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO DonHang (ma_don_hang, ma_hop_dong, ngay_bat_dau_lay_mau, ngay_tra_ket_qua_du_kien, quy, trang_thai)
        VALUES (@MaDonHang, @MaHopDong, @NgayBatDauLayMau, @NgayTraKetQuaDuKien, @Quy, @TrangThai);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_UpdateDonHang
    @MaDonHang VARCHAR(50),
	@MaHopDong VARCHAR(50),
    @NgayBatDauLayMau DATE,
    @NgayTraKetQuaDuKien DATE,
    @Quy INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE DonHang
        SET ma_hop_dong = @MaHopDong,
            ngay_bat_dau_lay_mau = @NgayBatDauLayMau,
            ngay_tra_ket_qua_du_kien = @NgayTraKetQuaDuKien,
            quy = @Quy,
            trang_thai = @TrangThai
        WHERE ma_don_hang = @MaDonHang;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_DeleteDonHang
    @MaDonHang VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM DonHang 
        WHERE ma_don_hang = @MaDonHang;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_GetOrderStatusCounts 
    @quy INT, 
    @nam INT
AS
BEGIN
	SET NOCOUNT ON;
    SELECT trang_thai, COUNT(*) AS SoLuong 
    FROM DonHang 
    WHERE quy = @quy AND YEAR(ngay_bat_dau_lay_mau) = @nam 
    GROUP BY trang_thai;
END;
GO
CREATE PROC USP_GetOrderListByStatusAndQuy
    @status NVARCHAR(50),
    @quy INT,
    @nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_don_hang 
    FROM DonHang 
    WHERE trang_thai = @status 
          AND quy = @quy 
          AND YEAR(ngay_bat_dau_lay_mau) = @nam;
END;
GO
CREATE PROC USP_GetOrderStatusCountsByDot
    @dot INT,
    @nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT trang_thai, COUNT(*) AS SoLuong 
    FROM DonHang 
    WHERE YEAR(ngay_bat_dau_lay_mau) = @nam 
          AND ((@dot = 1 AND MONTH(ngay_bat_dau_lay_mau) BETWEEN 1 AND 6) 
            OR (@dot = 2 AND MONTH(ngay_bat_dau_lay_mau) BETWEEN 7 AND 12))
    GROUP BY trang_thai;
END;
GO
CREATE PROC USP_GetOrderListByStatusAndDot
    @status NVARCHAR(50),
    @dot INT,
    @nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ma_don_hang 
    FROM DonHang 
    WHERE trang_thai = @status 
    AND YEAR(ngay_bat_dau_lay_mau) = @nam 
    AND ((@dot = 1 AND MONTH(ngay_bat_dau_lay_mau) BETWEEN 1 AND 6) 
         OR (@dot = 2 AND MONTH(ngay_bat_dau_lay_mau) BETWEEN 7 AND 12));
END;
GO
--TẠO BẢNG NGƯỜI DÙNG
CREATE TABLE NGUOIDUNG (
    ma_nguoi_dung VARCHAR(50) PRIMARY KEY NOT NULL,
    ten NVARCHAR(255) NOT NULL,
    vai_tro NVARCHAR(50) CHECK (vai_tro IN (N'Quản trị viên', N'Phòng kinh doanh', N'Phòng quan trắc', N'Phòng phân tích', N'Phòng kế hoạch', N'Phòng xuất kết quả')) NOT NULL,
    ten_dang_nhap VARCHAR(50) NOT NULL UNIQUE,
    mat_khau VARCHAR(255) NOT NULL DEFAULT '12345678',
    email VARCHAR(255) UNIQUE NOT NULL,
    sdt VARCHAR(15) UNIQUE NOT NULL CHECK (LEN(sdt) IN (10, 11) AND PATINDEX('%[^0-9]%', sdt) = 0)
);
GO
INSERT INTO NGUOIDUNG (ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, email, sdt)
VALUES 	('NV000001', N'Nguyễn Minh Hùng', N'Quản trị viên', 'minhhung', 'minhhung@gmail.com', '0886600112'),
		('NV000002', N'Trần Thị Mai', N'Phòng quan trắc', 'thimai', 'thimai@gmail.com', '0923556399'),
		('NV000003', N'Lê Văn Khánh', N'Phòng kinh doanh', 'vankhanh', 'vankhanh@gmail.com', '0973254874'),
		('NV000004', N'Phạm Ngọc Anh', N'Phòng xuất kết quả', 'ngocanh', 'ngocanh@gmail.com', '0935541187'),
		('NV000005', N'Hoàng Thanh Tùng', N'Phòng phân tích', 'thanhtung', 'thanhtung@gmail.com', '0977861233'),
		('NV000006', N'Bùi Thị Hạnh', N'Phòng quan trắc', 'thihanh', 'thihanh@gmail.com', '0967890162'),
		('NV000007', N'Đặng Hoàng Nam', N'Phòng kinh doanh', 'hoangnam', 'hoangnam@gmail.com', '0935540087'),
		('NV000008', N'Ngô Phương Linh', N'Phòng xuất kết quả', 'phuonglinh', 'phuonglinh@gmail.com', '0935544867'),
		('NV000009', N'Vũ Đức Duy', N'Phòng phân tích', 'ducduy', 'ducduy@gmail.com', '0935668777'),
		('NV000010', N'Tống Hải Yến', N'Phòng quan trắc', 'haiyen', 'haiyen@gmail.com', '0901211962');
GO
CREATE PROC USP_Login 
    @userName NVARCHAR(50), 
    @passWord NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM NGUOIDUNG 
    WHERE ten_dang_nhap = @userName 
        AND mat_khau = @passWord;
END;
GO
CREATE PROC USP_GenerateMaNguoiDung
    @NewMaNguoiDung VARCHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NextID INT;
    SELECT @NextID = ISNULL(MAX(TRY_CAST(RIGHT(ma_nguoi_dung, 6) AS INT)), 0) + 1
    FROM NGUOIDUNG;
    IF @NextID > 999999
        RAISERROR(N'Số lượng người dùng đã vượt quá giới hạn!', 16, 1);
    ELSE
        SET @NewMaNguoiDung = 'NV' + RIGHT('000000' + CAST(@NextID AS VARCHAR), 6);
END;
GO
CREATE PROC USP_GetAccountByUsername
    @username NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
    SELECT * FROM NGUOIDUNG WHERE ten_dang_nhap = @username
END
GO
CREATE PROC USP_UpdateOwnAccount
	@username NVARCHAR(50), 
	@ID VARCHAR(50), 
	@name NVARCHAR(255), 
	@email VARCHAR(255), 
	@sdt VARCHAR(15), 
	@password VARCHAR(255), 
	@newPassword VARCHAR(255) = null
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		IF (@newPassword = NULL OR @newPassword = ' ')
		BEGIN
			UPDATE NGUOIDUNG 
			SET ma_nguoi_dung = @ID, 
				ten = @name, 
				email = @email, 
				sdt = @sdt 
			WHERE ten_dang_nhap = @username 
					AND mat_khau = @password
		END
		ELSE
			UPDATE NGUOIDUNG 
			SET mat_khau = @newPassword 
			WHERE ten_dang_nhap = @username
					AND mat_khau = @password
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH;
END
GO
CREATE PROC USP_GetAccountList
AS
BEGIN
	SET NOCOUNT ON;
    SELECT 
        ma_nguoi_dung, 
        ten_dang_nhap, 
        ten, 
        vai_tro, 
		mat_khau,
        email, 
        sdt
    FROM NGUOIDUNG
	ORDER BY ten ASC;
END
GO
CREATE PROC USP_SearchAccount
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ma_nguoi_dung,
        ten,
        vai_tro,
        ten_dang_nhap,
        email,
        sdt
    FROM NGUOIDUNG
    WHERE 
        ma_nguoi_dung LIKE '%' + @Keyword + '%'
        OR ten LIKE N'%' + @Keyword + '%'
        OR vai_tro LIKE N'%' + @Keyword + '%'
        OR ten_dang_nhap LIKE '%' + @Keyword + '%'
        OR email LIKE '%' + @Keyword + '%'
        OR sdt LIKE '%' + @Keyword + '%'
    ORDER BY ten ASC;
END;
GO
CREATE PROC USP_InsertAccount
    @MaNguoiDung VARCHAR(50),
    @Ten NVARCHAR(255),
    @VaiTro NVARCHAR(50),
    @TenDangNhap VARCHAR(50),
    @Email VARCHAR(255),
    @Sdt VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO NGUOIDUNG (ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, email, sdt)
        VALUES (@MaNguoiDung, @Ten, @VaiTro, @TenDangNhap, @Email, @Sdt);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
CREATE PROC USP_UpdateAccount
	@MaNguoiDung VARCHAR(50),
    @Ten NVARCHAR(255),
    @VaiTro NVARCHAR(50),
    @TenDangNhap VARCHAR(50),
    @Email VARCHAR(255),
    @Sdt VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE NGUOIDUNG
        SET ten = @Ten,
            vai_tro = @VaiTro,
            ten_dang_nhap = @TenDangNhap,
            email = @Email,
            sdt = @Sdt
        WHERE ma_nguoi_dung = @MaNguoiDung;
    END TRY
    BEGIN CATCH
    END CATCH;
END;
GO
CREATE PROC USP_DeleteAccount
    @MaNguoiDung VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM NGUOIDUNG 
        WHERE ma_nguoi_dung = @MaNguoiDung;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
GO
--TẠO BẢNG VỊ TRÍ LẤY MẪU
CREATE TABLE ViTriLayMau (
    ma_don_hang VARCHAR(50) FOREIGN KEY REFERENCES DonHang(ma_don_hang) ON DELETE CASCADE,
    ma_vi_tri NVARCHAR(50),
    ten_vi_tri NVARCHAR(255) NOT NULL,
    loai_vi_tri NVARCHAR(20) CHECK (loai_vi_tri IN (N'Đất', N'Nước', N'Không khí', N'Khí thải')) NOT NULL,
    PRIMARY KEY (ma_don_hang, ma_vi_tri)
);
GO
INSERT INTO ViTriLayMau (ma_don_hang, ma_vi_tri, ten_vi_tri, loai_vi_tri)
VALUES  ('DH24000001', N'Đất 1', N'Đất ở xưởng sản xuất', N'Đất'),
        ('DH24000001', N'Nước 1', N'Nước thải ở xưởng sản xuất', N'Nước'),
        ('DH24000001', N'Không khí 1', N'Không khí ở xưởng sản xuất', N'Không khí'),
        ('DH24000001', N'Khí thải 1', N'Khí thải ở xưởng sản xuất', N'Khí thải'),
        ('DH24000002', N'Đất 1', N'Đất ở đầu nhà máy sản xuất', N'Đất'),
        ('DH24000002', N'Đất 2', N'Đất ở giữa xưởng sản xuất', N'Đất'),
        ('DH24000002', N'Nước 1', N'Nước thải trước khi xử lý', N'Nước'),
        ('DH24000002', N'Nước 2', N'Nước thải sau khi xử lý', N'Nước'),
        ('DH24000002', N'Không khí 1', N'Không khí ở nhà máy', N'Không khí'),
        ('DH24000002', N'Khí thải 1', N'Khí thải ở nhà máy', N'Khí thải'),
        ('DH24000003', N'Đất 1', N'Đất ở văn phòng', N'Đất'),
        ('DH24000003', N'Nước 1', N'Nước thải trước khi xử lý', N'Nước'),
        ('DH24000003', N'Nước 2', N'Nước thải sau khi xử lý', N'Nước'),
        ('DH24000003', N'Không khí 1', N'Không khí ở văn phòng', N'Không khí'),
        ('DH24000003', N'Khí thải 1', N'Khí thải trước khi xử lý', N'Khí thải'),
        ('DH24000003', N'Khí thải 2', N'Khí thải sau khi xử lý', N'Khí thải'),
        ('DH24000004', N'Đất 1', N'Đất ở đầu nhà máy', N'Đất'),
        ('DH24000004', N'Đất 2', N'Đất ở giữa nhà máy', N'Đất'),
        ('DH24000004', N'Đất 3', N'Đất ở cuối nhà máy', N'Đất'),
        ('DH24000004', N'Nước 1', N'Nước thải trước khi xử lý', N'Nước'),
        ('DH24000004', N'Nước 2', N'Nước thải sau khi xử lý', N'Nước'),
        ('DH24000004', N'Không Khí 1', N'Không khí ở nhà máy', N'Không khí'),
        ('DH24000004', N'Khí thải 1', N'Khí thải trước khi xử lý', N'Khí thải'),
        ('DH24000004', N'Khí thải 2', N'Khí thải sau khi xử lý', N'Khí thải');
GO
--TẠO BẢNG THÔNG SỐ MÔI TRƯỜNG
CREATE TABLE ThongSoMoiTruong (
    ma_thong_so VARCHAR(50) PRIMARY KEY,
    ma_don_hang VARCHAR(50),
    ma_vi_tri NVARCHAR(50),
    STT INT IDENTITY(1,1),
    ten_thong_so NVARCHAR(255) NOT NULL,
    don_vi NVARCHAR(50),
    ket_qua NVARCHAR(50),
    an_lan_quan_trac BIT DEFAULT 0,
    loai NVARCHAR(10) CHECK (loai IN ('HT', 'p.TN')),
    nguoi_phan_tich NVARCHAR(255),
    gia_tri_quy_chuan_TCVN NVARCHAR(50),
    ket_luan NVARCHAR(MAX),
    FOREIGN KEY (ma_don_hang, ma_vi_tri) REFERENCES ViTriLayMau(ma_don_hang, ma_vi_tri) ON DELETE CASCADE
);
GO
INSERT INTO ThongSoMoiTruong(ma_thong_so,ma_don_hang,ma_vi_tri,ten_thong_so,don_vi,ket_qua,an_lan_quan_trac,loai,nguoi_phan_tich,gia_tri_quy_chuan_TCVN,ket_luan)VALUES
('TS01','DH24000001',N'Đất 1','+Asen(As)','mg/Kg',0.0001,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS02','DH24000001',N'Đất 1','+Cadimi(Cd)','mg/Kg',0.306,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS03','DH24000001',N'Đất 1',N'+Chì(Pb)','mg/Kg',0.550,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS04','DH24000001',N'Đất 1',N'+Kẽm(Zn)','mg/Kg',0.135,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS05','DH24000001',N'Đất 1',N'+Đồng(Cu)','mg/Kg',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS06','DH24000001',N'Nước 1','+pH2024-HT','-',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS07','DH24000001',N'Nước 1',N'+Nhiệt độ 2024-HT',N'℃',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS08','DH24000001',N'Nước 1',N'+Lưu lượng 2024-HT','m³/h',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS09','DH24000001',N'Nước 1',N'+Độ màu 2024-HT','Pt-Co',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS10','DH24000001',N'Nước 1',N'+Nhu cầu oxy sinh học(BOD₅) 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS11','DH24000001',N'Nước 1',N'+Nhu cầu oxy hóa học(COD)5220C 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS12','DH24000001',N'Nước 1',N'+Tổng chất rắn lơ lửng(TSS) 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS13','DH24000001',N'Nước 1',N'+Tổng dầu mỡ khoáng 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS14','DH24000001',N'Nước 1',N'+Tổng chất rắn lơ lửng(TSS) 2024','mg/L',0.040,0,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS15','DH24000001',N'Nước 1',N'+Amoni(NH₄⁺ tính theo N) 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS16','DH24000001',N'Nước 1',N'+Tổng N 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS17','DH24000001',N'Nước 1',N'+Tổng P 2024','mg/L',0.040,0,'p.TN',N'Phạm Quốc Việt',0,NULL),
('TS18','DH24000001',N'Không khí 1',N'+Ánh sáng',N'Lux',607.66,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS19','DH24000001',N'Không khí 1',N'+Nhiệt độ',N'℃',28.2,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS20','DH24000001',N'Không khí 1',N'+Độ ẩm','%',63.2,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS21','DH24000001',N'Không khí 1',N'+Tốc độ gió','m/s',0.2,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS22','DH24000001',N'Không khí 1',N'+Tiếng ồn','dBA',71.766,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS23','DH24000001',N'Không khí 1',N'+Tổng bụi lơ lửng(TSP)-Bụi toàn phần','mg/m³',0.01,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS24','DH24000001',N'Không khí 1',N'+NO₂','mg/m³',3.24,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS25','DH24000001',N'Không khí 1',N'+Sulfur dioxide(SO₂)','mg/m³',5.86,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS26','DH24000001',N'Không khí 1',N'+Hydrosulfide(H₂S)','mg/m³',0.13,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS27','DH24000001',N'Khí thải 1',N'+Lưu lượng Method 2 2024-HT','Nm³/h',0,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS28','DH24000001',N'Khí thải 1',N'+CO 2024-HT','mg/Nm³',0,1,'HT',N'Hoàng Thanh Hùng',0,NULL),
('TS29','DH24000001',N'Khí thải 1',N'+Lưu lượng Method 2 2024-HT','mg/Nm³',0,1,'p.TN',N'Phạm Quốc Việt',0,null)
GO
