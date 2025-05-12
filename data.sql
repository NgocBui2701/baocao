CREATE DATABASE QUAN_LY_DON_HANG_MOI_TRUONG
GO
USE QUAN_LY_DON_HANG_MOI_TRUONG
GO
--TẠO BẢNG NGƯỜI DÙNG
CREATE TABLE NGUOIDUNG (
    ma_nguoi_dung VARCHAR(50) PRIMARY KEY NOT NULL,
    ten NVARCHAR(255) NOT NULL,
    vai_tro NVARCHAR(50) CHECK (vai_tro IN (N'Quản trị viên', N'Phòng kinh doanh', N'Phòng quan trắc', N'Phòng phân tích', N'Phòng kế hoạch', N'Phòng xuất kết quả')) NOT NULL,
    ten_dang_nhap VARCHAR(50) COLLATE Latin1_General_CS_AS NOT NULL UNIQUE,
    mat_khau VARCHAR(255) COLLATE Latin1_General_CS_AS NOT NULL DEFAULT '12345678',
    email VARCHAR(255) COLLATE Latin1_General_CS_AS UNIQUE NOT NULL,
    sdt VARCHAR(15) COLLATE Latin1_General_CS_AS UNIQUE NOT NULL CHECK (LEN(sdt) IN (10, 11) AND PATINDEX('%[^0-9]%', sdt) = 0)
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
INSERT INTO NGUOIDUNG (ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, mat_khau, email, sdt)
VALUES 	('NV000011', N'Bùi Thị Bích Ngọc', N'Quản trị viên', 'ngocbui', '77ba4234603ea25b281036990a970b8dabcfeb0656aec28366b249e8b132ab1b', 'cmoitruong796@gmail.com', '0795987122');
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
CREATE PROC USP_GetNguoiDungByVaiTro
    @vai_tro NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ten
    FROM NGUOIDUNG
    WHERE vai_tro = @vai_tro
	ORDER BY ten;
END;
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
		ten LIKE N'%' + @Keyword + '%'
        OR vai_tro LIKE N'%' + @Keyword + '%'
    ORDER BY ten ASC;
END;
GO
ALTER PROC USP_UpdateOwnAccount
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
		IF (@newPassword = NULL OR @newPassword = '')
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
CREATE PROC USP_InsertAccount
    @MaNguoiDung VARCHAR(50),
    @Ten NVARCHAR(255),
    @VaiTro NVARCHAR(50),
    @TenDangNhap VARCHAR(50),
    @Email VARCHAR(255),
    @Sdt VARCHAR(15),
	@MatKhau VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO NGUOIDUNG (ma_nguoi_dung, ten, vai_tro, ten_dang_nhap, mat_khau, email, sdt)
        VALUES (@MaNguoiDung, @Ten, @VaiTro, @TenDangNhap, @MatKhau, @Email, @Sdt);
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
--TẠO BẢNG CÔNG TY
CREATE TABLE CongTy (
    ma_cong_ty VARCHAR(50) PRIMARY KEY NOT NULL,
    ten_cong_ty NVARCHAR(255) UNIQUE NOT NULL,
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
CREATE PROC USP_GetCongTyByTenCongTy
    @TenCT NVARCHAR(255)
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
    WHERE ten_cong_ty = @TenCT
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
		('HD250007', '0101234573', '2025-02-14'),
		('HD250008', '0101234574', '2025-03-14');
GO
CREATE PROC USP_GenerateMaHopDong
    @NewMaHopDong VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @YearCode VARCHAR(2) = RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR), 2);
    DECLARE @MaxCurrentNumber BIGINT;
    SELECT @MaxCurrentNumber = ISNULL(MAX(TRY_CAST(SUBSTRING(ma_hop_dong, 5, LEN(ma_hop_dong) - 4) AS BIGINT)), 0)
    FROM HopDong
    WHERE ma_hop_dong LIKE 'HD' + @YearCode + '%';
    SET @MaxCurrentNumber = @MaxCurrentNumber + 1;
    DECLARE @CurrentLength INT = GREATEST(4, LEN(CAST(@MaxCurrentNumber AS VARCHAR)));
    SET @NewMaHopDong = 'HD' + @YearCode + RIGHT('0000000000' + CAST(@MaxCurrentNumber AS VARCHAR), @CurrentLength);
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
    ('24.0001', 'HD240001', '2024-02-02', '2024-02-12', 1, N'Hoàn thành'),
    ('24.0002', 'HD240001', '2024-04-02', '2024-04-15', 2, N'Hoàn thành'),
    ('24.0003', 'HD240001', '2024-07-05', '2024-07-19', 3, N'Hoàn thành'),
    ('24.0004', 'HD240001', '2024-11-03', '2024-11-13', 4, N'Hoàn thành'),
    ('24.0005', 'HD240002', '2024-02-16', '2024-02-26', 1, N'Hoàn thành'),
    ('24.0006', 'HD240002', '2024-05-02', '2024-05-12', 2, N'Hoàn thành'),
    ('24.0007', 'HD240002', '2024-11-01', '2024-11-15', 4, N'Hoàn thành'),
    ('24.0008', 'HD240003', '2024-03-05', '2024-03-15', 1, N'Hoàn thành'),
    ('24.0009', 'HD240003', '2024-07-05', '2024-07-20', 3, N'Hoàn thành'),
    ('24.0010', 'HD240003', '2024-10-06', '2024-10-19', 4, N'Hoàn thành'),
    ('24.0011', 'HD240004', '2024-03-07', '2024-03-17', 1, N'Hoàn thành'),
    ('24.0012', 'HD240004', '2024-07-02', '2024-07-16', 3, N'Hoàn thành'),
    ('24.0013', 'HD240004', '2024-12-02', '2024-12-12', 4, N'Hoàn thành'),
    ('24.0014', 'HD240005', '2024-03-11', '2024-03-21', 1, N'Hoàn thành'),
    ('24.0015', 'HD240005', '2024-09-01', '2024-09-12', 3, N'Hoàn thành'),
    ('24.0016', 'HD240005', '2024-11-05', '2024-11-19', 4, N'Hoàn thành'),
    ('24.0017', 'HD240006', '2024-04-14', '2024-04-24', 2, N'Hoàn thành'),
    ('24.0018', 'HD240007', '2024-04-20', '2024-04-30', 2, N'Hoàn thành'),
    ('24.0019', 'HD240008', '2024-05-06', '2024-05-16', 2, N'Hoàn thành'),
    ('24.0020', 'HD240009', '2024-05-21', '2024-05-31', 2, N'Hoàn thành'),
    ('24.0021', 'HD240010', '2024-06-10', '2024-06-20', 2, N'Hoàn thành'),
    ('24.0022', 'HD240011', '2024-06-17', '2024-06-27', 2, N'Hoàn thành'),
    ('24.0023', 'HD240012', '2024-07-19', '2024-07-29', 3, N'Hoàn thành'),
    ('24.0024', 'HD240013', '2024-07-23', '2024-08-02', 3, N'Hoàn thành'),
    ('24.0025', 'HD240014', '2024-08-04', '2024-08-14', 3, N'Hoàn thành'),
    ('24.0026', 'HD240015', '2024-08-10', '2024-08-20', 3, N'Hoàn thành'),
    ('24.0027', 'HD240016', '2024-09-11', '2024-09-21', 3, N'Hoàn thành'),
    ('24.0028', 'HD240017', '2024-09-21', '2024-10-01', 3, N'Hoàn thành'),
    ('24.0029', 'HD240018', '2024-10-06', '2024-10-16', 4, N'Hoàn thành'),
    ('24.0030', 'HD240019', '2024-11-04', '2024-11-14', 4, N'Hoàn thành'),
    ('24.0031', 'HD240020', '2024-12-13', '2024-12-23', 4, N'Hoàn thành'),
	('24.0032', 'HD240010', '2024-12-20', '2024-12-29', 4, N'Quá hạn'),
	('24.0033', 'HD240012', '2024-12-25', '2024-12-31', 4, N'Quá hạn'),
	('24.0034', 'HD240013', '2024-12-29', '2025-01-05', 4, N'Quá hạn'),
	('25.0001', 'HD250001', '2025-01-20', '2025-03-31', 1, N'Đang xử lý'),
	('25.0002', 'HD250002', '2025-01-24', '2025-02-03', 1, N'Quá hạn'),
	('25.0003', 'HD250003', '2025-02-28', '2025-03-15', 1, N'Quá hạn'),
	('25.0004', 'HD250004', '2025-03-10', '2025-03-22', 1, N'Đang xử lý'),
	('25.0005', 'HD250005', '2025-03-10', '2025-03-16', 1, N'Hoàn thành'),
	('25.0006', 'HD250006', '2025-03-10', '2025-03-20', 1, N'Hoàn thành'),
	('25.0007', 'HD250007', '2025-03-10', '2025-03-17', 1, N'Hoàn thành');
GO
CREATE PROC USP_GenerateMaDonHang
    @NewMaDonHang VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @YearCode VARCHAR(2) = RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR), 2);
    DECLARE @MaxCurrentNumber BIGINT;
    SELECT @MaxCurrentNumber = ISNULL(MAX(TRY_CAST(SUBSTRING(ma_don_hang, 5, LEN(ma_don_hang) - 4) AS BIGINT)), 0)
    FROM DonHang
    WHERE ma_don_hang LIKE @YearCode + '.' + '%';
    SET @MaxCurrentNumber = @MaxCurrentNumber + 1;
    DECLARE @CurrentLength INT = GREATEST(4, LEN(CAST(@MaxCurrentNumber AS VARCHAR)));
    SET @NewMaDonHang = @YearCode + '.' + RIGHT('0000000000' + CAST(@MaxCurrentNumber AS VARCHAR), @CurrentLength);
END
GO
CREATE PROC USP_GetDonHangList
AS
BEGIN
    SELECT
		dh.ma_hop_dong AS MaHD,
        ma_don_hang AS MaDH,
        ngay_bat_dau_lay_mau AS NgayLM,
        ngay_tra_ket_qua_du_kien AS NgayKQ,
        quy AS Quy,
		trang_thai AS Trangthai,
		ct.ten_cong_ty AS TenCT
    FROM DonHang dh
	INNER JOIN HopDong hd ON hd.ma_hop_dong = dh.ma_hop_dong
	INNER JOIN CongTy ct ON ct.ma_cong_ty = hd.ma_cong_ty
    ORDER BY ma_don_hang DESC;
END;
GO
CREATE PROC USP_SearchDonHang
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
		dh.ma_hop_dong AS MaHD,
        ma_don_hang AS MaDH,
        ngay_bat_dau_lay_mau AS NgayLM,
        ngay_tra_ket_qua_du_kien AS NgayKQ,
        quy AS Quy,
		trang_thai AS Trangthai,
		ct.ten_cong_ty AS TenCT
    FROM DonHang dh
	INNER JOIN HopDong hd ON hd.ma_hop_dong = dh.ma_hop_dong
	INNER JOIN CongTy ct ON ct.ma_cong_ty = hd.ma_cong_ty
    WHERE 
		ct.ten_cong_ty LIKE N'%' + @Keyword + '%'
        OR ma_don_hang LIKE '%' + @Keyword + '%'
    ORDER BY ma_don_hang DESC;
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
CREATE PROC USP_UpdateTrangThaiDonHang
    @ma_don_hang VARCHAR(50),
    @trang_thai NVARCHAR(50)
AS
BEGIN
    UPDATE DonHang
    SET trang_thai = @trang_thai
    WHERE ma_don_hang = @ma_don_hang;
END;
GO
--TẠO BẢNG VỊ TRÍ LẤY MẪU
CREATE TABLE ViTriLayMau (
    ma_vi_tri NVARCHAR(50) NOT NULL,
	ma_hop_dong VARCHAR(50) NOT NULL,
	ma_don_hang VARCHAR(50) NOT NULL,
    ten_vi_tri NVARCHAR(255) NOT NULL,
    loai_vi_tri NVARCHAR(20) CHECK (loai_vi_tri IN (N'Đất', N'Nước', N'Không khí', N'Khí thải')) NOT NULL,
	FOREIGN KEY (ma_hop_dong) REFERENCES HopDong(ma_hop_dong) ON DELETE CASCADE,
	FOREIGN KEY (ma_don_hang) REFERENCES DonHang(ma_don_hang) ON DELETE CASCADE,
	PRIMARY KEY (ma_vi_tri, ma_hop_dong, ma_don_hang)
);
GO
INSERT INTO ViTriLayMau (ma_vi_tri, ma_hop_dong, ma_don_hang, ten_vi_tri, loai_vi_tri)
VALUES  
    (N'Đ1', 'HD250001', '25.0001', N'Đất ở xưởng sản xuất', N'Đất'),
    (N'Đ2', 'HD250001', '25.0001', N'Đất ở đầu nhà máy sản xuất', N'Đất'),
    (N'Đ3', 'HD250001', '25.0001', N'Đất ở giữa xưởng sản xuất', N'Đất'),
    (N'Đ4', 'HD250001', '25.0001', N'Đất ở văn phòng', N'Đất'),
    (N'Đ5', 'HD250001', '25.0001', N'Đất ở cuối nhà máy', N'Đất'),
    (N'N1', 'HD250001', '25.0001', N'Nước thải ở xưởng sản xuất', N'Nước'),
    (N'N2', 'HD250001', '25.0001', N'Nước thải trước khi xử lý', N'Nước'),
    (N'N3', 'HD250001', '25.0001', N'Nước thải sau khi xử lý', N'Nước'),
    (N'N4', 'HD250001', '25.0001', N'Nước thải sau xử lý tại bể lắng', N'Nước'),
    (N'KK1', 'HD250001', '25.0001', N'Không khí ở xưởng sản xuất', N'Không khí'),
    (N'KK2', 'HD250001', '25.0001', N'Không khí ở nhà máy', N'Không khí'),
    (N'KK3', 'HD250001', '25.0001', N'Không khí ở văn phòng', N'Không khí'),
    (N'KT1', 'HD250001', '25.0001', N'Khí thải ở xưởng sản xuất', N'Khí thải'),
    (N'KT2', 'HD250001', '25.0001', N'Khí thải ở nhà máy', N'Khí thải'),
    (N'KT3', 'HD250001', '25.0001', N'Khí thải trước khi xử lý', N'Khí thải'),
    (N'KT4', 'HD250001', '25.0001', N'Khí thải sau khi xử lý', N'Khí thải');
GO
--TẠO BẢNG THÔNG SỐ MÔI TRƯỜNG
CREATE TABLE ThongSoMoiTruong (
    ma_thong_so VARCHAR(50) PRIMARY KEY,
    loai_vi_tri NVARCHAR(20) CHECK (loai_vi_tri IN (N'Đất', N'Nước', N'Không khí', N'Khí thải')) NOT NULL,
    ten_thong_so NVARCHAR(255) NOT NULL,
    don_vi NVARCHAR(50),
    gia_tri_quy_chuan_TCVN NVARCHAR(50)
);
GO
CREATE TRIGGER trg_AutoGenerate_MaThongSo
ON ThongSoMoiTruong
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ma_thong_so_new VARCHAR(50);
    DECLARE @loai_vi_tri NVARCHAR(50);
    DECLARE @prefix VARCHAR(10);
    DECLARE @count INT;
    DECLARE insert_cursor CURSOR FOR
    SELECT loai_vi_tri FROM inserted;
    OPEN insert_cursor;
    FETCH NEXT FROM insert_cursor INTO @loai_vi_tri;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @prefix = CASE 
            WHEN @loai_vi_tri = N'Đất' THEN 'D'
            WHEN @loai_vi_tri = N'Nước' THEN 'N'
            WHEN @loai_vi_tri = N'Không khí' THEN 'KK'
            WHEN @loai_vi_tri = N'Khí thải' THEN 'KT'
            ELSE 'TS' 
        END;
        SELECT @count = COUNT(*) + 1 FROM ThongSoMoiTruong WHERE loai_vi_tri = @loai_vi_tri;
        SET @ma_thong_so_new = @prefix + CAST(@count AS VARCHAR);
        INSERT INTO ThongSoMoiTruong (ma_thong_so, loai_vi_tri, ten_thong_so, don_vi, gia_tri_quy_chuan_TCVN)
        SELECT @ma_thong_so_new, loai_vi_tri, ten_thong_so, don_vi, gia_tri_quy_chuan_TCVN
        FROM inserted;
        FETCH NEXT FROM insert_cursor INTO @loai_vi_tri;
    END;
    CLOSE insert_cursor;
    DEALLOCATE insert_cursor;
END;
GO
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Đất','+Asen(As)','mg/Kg','25')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Đất','+Cadimi(Cd)','mg/Kg','4')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Đất',N'+Chì(Pb)','mg/Kg','200')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Đất',N'+Kẽm(Zn)','mg/Kg','300')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Đất',N'+Đồng(Cu)','mg/Kg','150')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước','+pH2024-HT','-', '6-9')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Nhiệt độ 2024-HT',N'°C','40')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Lưu lượng 2024-HT','m³/h','100')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Độ màu 2024-HT','Pt-Co','50')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Nhu cầu oxy sinh học(BOD₅) 2024','mg/L','30')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Nhu cầu oxy hóa học(COD)5220C 2024','mg/L','75')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Tổng chất rắn lơ lửng(TSS) 2024','mg/L','50')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Tổng dầu mỡ khoáng 2024','mg/L','5')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Tổng chất rắn lơ lửng N(TSS) 2024','mg/L','50')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Amoni(NH₄⁺ tính theo N) 2024','mg/L','5')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Tổng N 2024','mg/L','20')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Nước',N'+Tổng P 2024','mg/L','4')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Ánh sáng',N'Lux','300')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Nhiệt độ',N'℃','30')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Độ ẩm','%','40-70')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Tốc độ gió','m/s','0.2-0.5')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Tiếng ồn','dBA','85')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Tổng bụi lơ lửng(TSP)-Bụi toàn phần','mg/m³','10')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+NO₂','mg/m³','0.3')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Sulfur dioxide(SO₂)','mg/m³','0.5')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Không khí',N'+Hydrosulfide(H₂S)','mg/m³','0.003')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Khí thải',N'+Lưu lượng Method 1 2024-HT','Nm³/h','20000')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Khí thải',N'+CO 2024-HT','mg/Nm³','10000')
INSERT INTO ThongSoMoiTruong(loai_vi_tri, ten_thong_so,don_vi,gia_tri_quy_chuan_TCVN)
VALUES (N'Khí thải',N'+Lưu lượng Method 2 2024-HT','Nm³/h','1500')
GO
--TẠO BẢNG KẾT QUẢ
CREATE TABLE KetQua (
	ma_hop_dong VARCHAR(50) NOT NULL,
    ma_don_hang VARCHAR(50) NOT NULL,
    ma_vi_tri NVARCHAR(50) NOT NULL,
    ma_thong_so VARCHAR(50) NOT NULL,
    ket_qua FLOAT(50),
    loai NVARCHAR(10),
    nguoi_phan_tich NVARCHAR(255),
    an_lan_quan_trac BIT DEFAULT 0,
    ket_luan NVARCHAR(MAX),
    PRIMARY KEY (ma_don_hang, ma_vi_tri, ma_thong_so),
    FOREIGN KEY (ma_vi_tri, ma_hop_dong, ma_don_hang) REFERENCES ViTriLayMau(ma_vi_tri, ma_hop_dong, ma_don_hang) ON DELETE CASCADE,
    FOREIGN KEY (ma_thong_so) REFERENCES ThongSoMoiTruong(ma_thong_so)
);
GO
INSERT INTO KetQua (ma_hop_dong, ma_don_hang, ma_vi_tri, ma_thong_so, ket_qua, loai, nguoi_phan_tich, an_lan_quan_trac, ket_luan)
SELECT 
    'HD250001' AS ma_hop_dong, 
    '25.0001' AS ma_don_hang, 
    v.ma_vi_tri, 
    t.ma_thong_so, 
    '' AS ket_qua, 
	'' AS loai,
	'' AS nguoi_phan_tich,
    0 AS an_lan_quan_trac, 
    N'' AS ket_luan
FROM ViTriLayMau v
JOIN ThongSoMoiTruong t ON v.loai_vi_tri = t.loai_vi_tri
WHERE v.ma_hop_dong = 'HD250001';
GO
CREATE PROC USP_GetViTriByMaHD
    @MaHD VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FirstMaDH VARCHAR(50);
    SELECT @FirstMaDH = MIN(ma_don_hang)
    FROM ViTriLayMau
    WHERE ma_hop_dong = @MaHD;

    SELECT *
    FROM ViTriLayMau
    WHERE ma_hop_dong = @MaHD AND ma_don_hang = @FirstMaDH;
END;
GO

CREATE PROC USP_GetViTriByMaDH
    @MaDH VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM ViTriLayMau WHERE ma_don_hang = @MaDH;
END
GO
CREATE PROC USP_InsertViTri
    @MaVT NVARCHAR(50),
    @MaHD VARCHAR(50),
    @MaDH VARCHAR(50),
    @TenVT NVARCHAR(255),
    @LoaiVT NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ViTriLayMau (ma_vi_tri, ma_hop_dong, ma_don_hang, ten_vi_tri, loai_vi_tri) 
    VALUES (@MaVT, @MaHD, @MaDH, @TenVT, @LoaiVT);
END
GO
CREATE PROC USP_UpdateTenViTri
    @MaHopDong NVARCHAR(50),
    @MaDonHang NVARCHAR(50),
    @MaViTri NVARCHAR(50),
    @NewTenViTri NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ViTriLayMau
    SET ten_vi_tri = @NewTenViTri
    WHERE ma_hop_dong = @MaHopDong
      AND ma_don_hang = @MaDonHang
      AND ma_vi_tri = @MaViTri;
END;
GO
CREATE PROC USP_DeleteViTri
    @MaVT NVARCHAR(50),
    @MaHD VARCHAR(50),
    @MaDH VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ViTriLayMau WHERE ma_vi_tri = @MaVT AND ma_hop_dong = @MaHD AND ma_don_hang = @MaDH;
END
GO
CREATE PROC USP_GetThongSoByLoaiViTri
    @LoaiViTri NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
		ma_thong_so AS MaTS,
		loai_vi_tri AS LoaiVT,
		ten_thong_so AS TenTS,
		don_vi AS DonVi,
		gia_tri_quy_chuan_TCVN AS TCVN
    FROM ThongSoMoiTruong
    WHERE loai_vi_tri = @LoaiViTri;
END
GO
CREATE PROC USP_CheckViTriExists
    @maViTri NVARCHAR(50),
    @maHD NVARCHAR(50),
    @maDH NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (
        SELECT 1 
        FROM KetQua
        WHERE ma_vi_tri = @maViTri
          AND ma_hop_dong = @maHD
          AND ma_don_hang = @maDH
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO
CREATE PROC USP_InsertThongSoMoiTruong
    @loai_vi_tri NVARCHAR(20),
    @ten_thong_so NVARCHAR(255),
    @don_vi NVARCHAR(50),
    @gia_tri_quy_chuan_TCVN NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (
        SELECT 1 FROM ThongSoMoiTruong 
        WHERE loai_vi_tri = @loai_vi_tri 
        AND ten_thong_so = @ten_thong_so 
        AND don_vi = @don_vi 
        AND gia_tri_quy_chuan_TCVN = @gia_tri_quy_chuan_TCVN)
    BEGIN
        INSERT INTO ThongSoMoiTruong (loai_vi_tri, ten_thong_so, don_vi, gia_tri_quy_chuan_TCVN)
        VALUES (@loai_vi_tri, @ten_thong_so, @don_vi, @gia_tri_quy_chuan_TCVN)
    END
END;
GO
CREATE PROC USP_GetKetQuaList 
	@MaDH VARCHAR(50),
	@MaVT NVARCHAR(50)
AS
BEGIN
	SELECT
		TS.ma_thong_so AS maTS,
		TS.ten_thong_so AS TenTS,
		TS.don_vi AS DonVi,
		kq.ket_qua AS KetQua,
		kq.an_lan_quan_trac AS AnLanQuanTrac,
		kq.loai AS Loai,
		kq.nguoi_phan_tich AS NguoiPT,
		TS.gia_tri_quy_chuan_TCVN AS TCVN,
		kq.ket_luan AS KetLuan
	FROM KetQua kq
	INNER JOIN ThongSoMoiTruong TS ON TS.ma_thong_so = kq.ma_thong_so
	WHERE
		kq.ma_don_hang = @MaDH
		AND kq.ma_vi_tri = @MaVT
	ORDER BY ten_thong_so ASC
END;
GO
CREATE PROC USP_InsertKetQuaDefault
    @ma_hop_dong VARCHAR(50),
    @ma_don_hang VARCHAR(50),
    @ma_vi_tri NVARCHAR(50),
    @ma_thong_so VARCHAR(50),
    @ket_qua FLOAT NULL,
	@loai NVARCHAR(10) NULL,
    @nguoi_phan_tich NVARCHAR(255) NULL,
    @an_lan_quan_trac BIT,
    @ket_luan NVARCHAR(MAX) NULL
AS
BEGIN
    INSERT INTO KetQua (ma_hop_dong, ma_don_hang, ma_vi_tri, ma_thong_so, ket_qua, loai, nguoi_phan_tich, an_lan_quan_trac, ket_luan)
    VALUES (@ma_hop_dong, @ma_don_hang, @ma_vi_tri, @ma_thong_so, @ket_qua, @loai, @nguoi_phan_tich, @an_lan_quan_trac, @ket_luan)
END;
GO
CREATE PROC USP_InsertOrUpdateKetQua
    @ma_hop_dong VARCHAR(50),
    @ma_don_hang VARCHAR(50),
    @ma_vi_tri NVARCHAR(50),
    @loai_vi_tri NVARCHAR(20),
    @ten_thong_so NVARCHAR(255),
    @don_vi NVARCHAR(50),
    @gia_tri_quy_chuan_TCVN NVARCHAR(50),
    @ma_thong_so_cu VARCHAR(50),
    @ket_qua FLOAT,
    @loai NVARCHAR(10),
    @nguoi_phan_tich NVARCHAR(255),
    @an_lan_quan_trac BIT,
    @ket_luan NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ma_thong_so VARCHAR(50);
    
    SELECT @ma_thong_so = ma_thong_so 
    FROM ThongSoMoiTruong 
    WHERE loai_vi_tri = @loai_vi_tri 
    AND ten_thong_so = @ten_thong_so 
    AND don_vi = @don_vi 
    AND gia_tri_quy_chuan_TCVN = @gia_tri_quy_chuan_TCVN;
    
    IF @ma_thong_so IS NULL
    BEGIN
        EXEC USP_InsertThongSoMoiTruong @loai_vi_tri, @ten_thong_so, @don_vi, @gia_tri_quy_chuan_TCVN;
        
        SELECT @ma_thong_so = ma_thong_so 
        FROM ThongSoMoiTruong 
        WHERE loai_vi_tri = @loai_vi_tri 
        AND ten_thong_so = @ten_thong_so 
        AND don_vi = @don_vi 
        AND gia_tri_quy_chuan_TCVN = @gia_tri_quy_chuan_TCVN;
    END
    
    IF EXISTS (
        SELECT 1 FROM KetQua 
        WHERE ma_hop_dong = @ma_hop_dong 
        AND ma_don_hang = @ma_don_hang 
        AND ma_vi_tri = @ma_vi_tri 
        AND ma_thong_so = @ma_thong_so_cu)
    BEGIN
        UPDATE KetQua
        SET ma_thong_so = @ma_thong_so,
            ket_qua = @ket_qua,
            loai = @loai,
            nguoi_phan_tich = @nguoi_phan_tich,
            an_lan_quan_trac = @an_lan_quan_trac,
            ket_luan = @ket_luan
        WHERE ma_hop_dong = @ma_hop_dong 
        AND ma_don_hang = @ma_don_hang 
        AND ma_vi_tri = @ma_vi_tri 
        AND ma_thong_so = @ma_thong_so_cu;
    END
    ELSE
    BEGIN
        INSERT INTO KetQua (ma_hop_dong, ma_don_hang, ma_vi_tri, ma_thong_so, ket_qua, loai, nguoi_phan_tich, an_lan_quan_trac, ket_luan)
        VALUES (@ma_hop_dong, @ma_don_hang, @ma_vi_tri, @ma_thong_so, @ket_qua, @loai, @nguoi_phan_tich, @an_lan_quan_trac, @ket_luan);
    END
END;
GO
CREATE PROC USP_DeleteKetQua
    @ma_hop_dong VARCHAR(50),
    @ma_don_hang VARCHAR(50),
    @ma_vi_tri NVARCHAR(50),
    @ma_thong_so VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM KetQua
    WHERE ma_hop_dong = @ma_hop_dong 
          AND ma_don_hang = @ma_don_hang 
          AND ma_vi_tri = @ma_vi_tri 
          AND ma_thong_so = @ma_thong_so;
END;
GO
CREATE PROCEDURE USP_GetKetQuaTruoc
    @MaThongSo VARCHAR(50),
    @MaViTri NVARCHAR(50),
    @MaHopDong VARCHAR(50),
    @CurrentQuy INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrevQuy INT;
    SET @PrevQuy = CASE WHEN @CurrentQuy = 1 THEN 4 ELSE @CurrentQuy - 1 END;

    SELECT TOP 1 kq.ket_qua
    FROM KetQua kq
    JOIN DonHang d ON kq.ma_don_hang = d.ma_don_hang
    WHERE kq.ma_thong_so = @MaThongSo
      AND kq.ma_vi_tri = @MaViTri
      AND kq.ma_hop_dong = @MaHopDong
      AND d.quy = @PrevQuy
    ORDER BY d.ngay_bat_dau_lay_mau DESC;

    IF (@@ROWCOUNT = 0)
    BEGIN
        SELECT 'N/A' AS ket_qua;
    END
END;
GO
CREATE PROC dbo.USP_GetThongSoByMaViTri
    @MaViTri NVARCHAR(50),
    @MaHopDong NVARCHAR(50),
    @MaDonHang NVARCHAR(50),
    @LoaiViTri NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ts.ma_thong_so          AS MaTS,
        ts.ten_thong_so         AS TenTS,
        ts.don_vi               AS DonVi,
        ts.gia_tri_quy_chuan_TCVN AS TCVN,
        ts.loai_vi_tri          AS LoaiViTri  -- Nếu cần, alias thêm các cột khác
    FROM ThongSoMoiTruong ts
    JOIN ViTriLayMau vt ON ts.loai_vi_tri = vt.loai_vi_tri
    WHERE vt.ma_vi_tri = @MaViTri
      AND vt.ma_hop_dong = @MaHopDong
      AND vt.ma_don_hang = @MaDonHang;
END;
GO