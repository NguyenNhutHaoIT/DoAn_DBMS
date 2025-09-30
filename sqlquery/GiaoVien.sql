-- 2. Function: chuyển trạng thái số -> chữ
-------------------------------------------------
IF OBJECT_ID('fn_TrangThaiText', 'FN') IS NOT NULL
    DROP FUNCTION fn_TrangThaiText;
GO

CREATE FUNCTION fn_TrangThaiText(@TrangThai INT)
RETURNS NVARCHAR(20)
AS
BEGIN
    RETURN (
        CASE @TrangThai
            WHEN 0 THEN N'Nghỉ'
            WHEN 1 THEN N'Đang làm'
            ELSE N'Khác'
        END
    );
END;
GO

-------------------------------------------------
-- 3. View: In danh sách giáo viên
-------------------------------------------------
IF OBJECT_ID('vw_GiaoVienInfo', 'V') IS NOT NULL
    DROP VIEW vw_GiaoVienInfo;
GO

CREATE VIEW vw_GiaoVienInfo
AS
SELECT
    gv.GiaoVienID,
    gv.HoTen,
    CONVERT(NVARCHAR(10), gv.NgaySinh, 103) AS NgaySinh,
    CASE gv.GioiTinh WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' ELSE N'Khác' END AS GioiTinh,
    dbo.fn_TrangThaiText(gv.TrangThai) AS TrangThai,
    ISNULL(gv.LoaiNV, N'') AS LoaiNV,
    CASE WHEN gv.LaTuyenMoi = 1 THEN N'Có' ELSE N'Không' END AS LaTuyenMoi,
    ISNULL(gv.CMND_CCCD, N'') AS CMND_CCCD,
    ISNULL(gv.SoDinhDanhCaNhan, N'') AS SoDinhDanhCaNhan,
    ISNULL(gv.Email, N'') AS Email,
    ISNULL(gv.DienThoai, N'') AS DienThoai,
    ISNULL(gv.DanToc, N'') AS DanToc,
    ISNULL(gv.TonGiao, N'') AS TonGiao,
    CASE WHEN gv.LaDoanVien = 1 THEN N'Có' ELSE N'Không' END AS LaDoanVien,
    CASE WHEN gv.LaDangVien = 1 THEN N'Có' ELSE N'Không' END AS LaDangVien,
    ISNULL(gv.SoSoBHXH, N'') AS SoSoBHXH,
    ISNULL(gv.NoiThuongTru, N'') AS NoiThuongTru,
    ISNULL(gv.QueQuan, N'') AS QueQuan
FROM GiaoVien gv;
GO

-------------------------------------------------
-- 4. Trigger: Kiểm tra trùng CMND/CCCD
-------------------------------------------------
IF OBJECT_ID('trg_Check_CMND', 'TR') IS NOT NULL
    DROP TRIGGER trg_Check_CMND;
GO

CREATE TRIGGER trg_Check_CMND
ON GiaoVien
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 
               FROM GiaoVien gv 
               JOIN inserted i ON gv.CMND_CCCD = i.CMND_CCCD)
    BEGIN
        RAISERROR(N'CMND/CCCD đã tồn tại.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO GiaoVien(HoTen, NgaySinh, GioiTinh, TrangThai, LoaiNV,
            LaTuyenMoi, CMND_CCCD, SoDinhDanhCaNhan, Email, DienThoai, DanToc,
            TonGiao, LaDoanVien, LaDangVien, SoSoBHXH, NoiThuongTru, QueQuan)
        SELECT HoTen, NgaySinh, GioiTinh, TrangThai, LoaiNV,
            LaTuyenMoi, CMND_CCCD, SoDinhDanhCaNhan, Email, DienThoai, DanToc,
            TonGiao, LaDoanVien, LaDangVien, SoSoBHXH, NoiThuongTru, QueQuan
        FROM inserted;
    END
END;
GO

-------------------------------------------------
-- 5. Proc: Insert GiaoVien
-------------------------------------------------
IF OBJECT_ID('InsertGiaoVien', 'P') IS NOT NULL
    DROP PROCEDURE InsertGiaoVien;
GO

CREATE PROCEDURE InsertGiaoVien
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh INT,
    @TrangThai INT,
    @LoaiNV NVARCHAR(50),
    @LaTuyenMoi BIT,
    @CMND_CCCD NVARCHAR(20),
    @SoDinhDanhCaNhan NVARCHAR(50),
    @Email NVARCHAR(100),
    @DienThoai NVARCHAR(20),
    @DanToc NVARCHAR(50),
    @TonGiao NVARCHAR(50),
    @LaDoanVien BIT,
    @LaDangVien BIT,
    @SoSoBHXH NVARCHAR(50),
    @NoiThuongTru NVARCHAR(200),
    @QueQuan NVARCHAR(200)
AS
BEGIN
    INSERT INTO GiaoVien(HoTen, NgaySinh, GioiTinh, TrangThai, LoaiNV, LaTuyenMoi, CMND_CCCD, 
        SoDinhDanhCaNhan, Email, DienThoai, DanToc, TonGiao, LaDoanVien, LaDangVien, 
        SoSoBHXH, NoiThuongTru, QueQuan)
    VALUES(@HoTen, @NgaySinh, @GioiTinh, @TrangThai, @LoaiNV, @LaTuyenMoi, @CMND_CCCD,
        @SoDinhDanhCaNhan, @Email, @DienThoai, @DanToc, @TonGiao, @LaDoanVien, @LaDangVien,
        @SoSoBHXH, @NoiThuongTru, @QueQuan);
END;
GO

-------------------------------------------------
-- 6. Proc: Update GiaoVien
-------------------------------------------------
IF OBJECT_ID('UpdateGiaoVien', 'P') IS NOT NULL
    DROP PROCEDURE UpdateGiaoVien;
GO

CREATE PROCEDURE UpdateGiaoVien
    @GiaoVienID INT,
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh INT,
    @TrangThai INT,
    @LoaiNV NVARCHAR(50),
    @LaTuyenMoi BIT,
    @CMND_CCCD NVARCHAR(20),
    @SoDinhDanhCaNhan NVARCHAR(50),
    @Email NVARCHAR(100),
    @DienThoai NVARCHAR(20),
    @DanToc NVARCHAR(50),
    @TonGiao NVARCHAR(50),
    @LaDoanVien BIT,
    @LaDangVien BIT,
    @SoSoBHXH NVARCHAR(50),
    @NoiThuongTru NVARCHAR(200),
    @QueQuan NVARCHAR(200)
AS
BEGIN
    UPDATE GiaoVien
    SET HoTen = @HoTen,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        TrangThai = @TrangThai,
        LoaiNV = @LoaiNV,
        LaTuyenMoi = @LaTuyenMoi,
        CMND_CCCD = @CMND_CCCD,
        SoDinhDanhCaNhan = @SoDinhDanhCaNhan,
        Email = @Email,
        DienThoai = @DienThoai,
        DanToc = @DanToc,
        TonGiao = @TonGiao,
        LaDoanVien = @LaDoanVien,
        LaDangVien = @LaDangVien,
        SoSoBHXH = @SoSoBHXH,
        NoiThuongTru = @NoiThuongTru,
        QueQuan = @QueQuan
    WHERE GiaoVienID = @GiaoVienID;
END;
GO

-------------------------------------------------
-- 7. Proc: Delete GiaoVien (xóa PhanCong trước)
-------------------------------------------------
IF OBJECT_ID('DeleteGiaoVien', 'P') IS NOT NULL
    DROP PROCEDURE DeleteGiaoVien;
GO

CREATE PROCEDURE DeleteGiaoVien
    @GiaoVienID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
            -- Xóa phân công trước
            DELETE FROM PhanCong WHERE GiaoVienID = @GiaoVienID;

            -- Xóa giáo viên
            DELETE FROM GiaoVien WHERE GiaoVienID = @GiaoVienID;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO

-------------------------------------------------
-- 8. Proc: Search GiaoVien
-------------------------------------------------
IF OBJECT_ID('SearchGiaoVien', 'P') IS NOT NULL
    DROP PROCEDURE SearchGiaoVien;
GO

CREATE PROCEDURE SearchGiaoVien
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM vw_GiaoVienInfo
    WHERE HoTen LIKE N'%' + @Keyword + '%'
       OR CMND_CCCD LIKE N'%' + @Keyword + '%'
       OR Email LIKE N'%' + @Keyword + '%'
       OR DienThoai LIKE N'%' + @Keyword + '%';
END;
GO

-------------------------------------------------
-- 9. Ví dụ gọi thử để test
-------------------------------------------------
-- Thêm mới giáo viên
-- EXEC InsertGiaoVien N'Nguyễn Văn A', '1985-05-10', 1, 1, N'Trưởng khoa', 0, 
 --  N'123456789', N'111111111', N'testa@gmail.com', N'0912345678',   N'Kinh', N'Không', 1, 0, N'BHXH001', N'Hà Nội', N'Hải Phòng';

-- Cập nhật giáo viên
-- EXEC UpdateGiaoVien 1, N'Nguyễn Văn A1', '1985-05-10', 1, 1, N'Trưởng khoa', 0, 
--     N'123456789', N'111111111', N'testupdate@gmail.com', N'0912345678',
--     N'Kinh', N'Không', 1, 0, N'BHXH001', N'Hà Nội', N'Hải Phòng';

-- Xóa giáo viên (sẽ tự xóa phân công trước)
-- EXEC DeleteGiaoVien 1;

-- Tìm kiếm
-- EXEC SearchGiaoVien N'A';

-- Xem danh sách
-- SELECT * FROM vw_GiaoVienInfo;