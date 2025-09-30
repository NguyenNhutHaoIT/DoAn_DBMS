USE DBMS;
GO

/* ==========================================================
   1. Tạo ROLE (nếu chưa có)
   ========================================================== */
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'Admin')
    CREATE ROLE [Admin];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'QuanLyHocSinh')
    CREATE ROLE [QuanLyHocSinh];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'GiaoVien')
    CREATE ROLE [GiaoVien];
GO

/* ==========================================================
   2. Cấp quyền cho ROLE
   ========================================================== */

-- Admin: toàn quyền
GRANT CONTROL ON DATABASE::DBMS TO Admin;

-- QuanLyHocSinh: CRUD Học sinh, Giám hộ, Quan hệ
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.HocSinh TO QuanLyHocSinh;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.GiamHo TO QuanLyHocSinh;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.HocSinh_GiamHo TO QuanLyHocSinh;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.HocSinh_Lop TO QuanLyHocSinh;

GRANT EXECUTE ON dbo.sp_ThemHocSinh TO QuanLyHocSinh;
GRANT EXECUTE ON dbo.sp_CapNhatHocSinh TO QuanLyHocSinh;
GRANT EXECUTE ON dbo.sp_XoaHocSinh TO QuanLyHocSinh;

GRANT EXECUTE ON dbo.sp_ThemGiamHo TO QuanLyHocSinh;
GRANT EXECUTE ON dbo.sp_CapNhatGiamHo TO QuanLyHocSinh;
GRANT EXECUTE ON dbo.sp_XoaGiamHo TO QuanLyHocSinh;

GRANT EXECUTE ON dbo.sp_ChuyenLopHocSinh TO QuanLyHocSinh;
GRANT EXECUTE ON dbo.sp_ChuyenToanBoHocSinh TO QuanLyHocSinh;

-- Giáo viên: Quản lý điểm
GRANT SELECT, UPDATE ON dbo.DiemHocSinh TO GiaoVien;
GRANT EXECUTE ON dbo.sp_NhapDiem TO GiaoVien;
GO

/* ==========================================================
   3. Trigger đồng bộ Tài khoản ↔ Login/User/Role
   ========================================================== */

-- Khi thêm tài khoản
CREATE OR ALTER TRIGGER trg_CreateSQLAccount
ON TaiKhoan
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @username NVARCHAR(50), @password NVARCHAR(50), @role NVARCHAR(50);
    SELECT TOP 1 @username = TenDangNhap, @password = MatKhau, @role = LoaiNguoiDung
    FROM inserted;

    DECLARE @sql NVARCHAR(MAX);

    -- Tạo LOGIN
    IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @username)
    BEGIN
        SET @sql = 'CREATE LOGIN [' + @username + '] WITH PASSWORD = ''' + @password + ''', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;';
        EXEC (@sql);
    END

    -- Tạo USER
    IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @username)
    BEGIN
        SET @sql = 'CREATE USER [' + @username + '] FOR LOGIN [' + @username + ']';
        EXEC (@sql);
    END

    -- Thêm vào Role
    SET @sql = 'ALTER ROLE [' + @role + '] ADD MEMBER [' + @username + ']';
    EXEC (@sql);
END;
GO

-- Khi xóa tài khoản
CREATE OR ALTER TRIGGER trg_DeleteSQLAccount
ON TaiKhoan
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @username NVARCHAR(50);
    SELECT TOP 1 @username = TenDangNhap FROM deleted;

    DECLARE @sql NVARCHAR(MAX);

    BEGIN TRY
        IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @username)
        BEGIN
            SET @sql = 'DROP USER [' + @username + ']';
            EXEC (@sql);
        END
        IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @username)
        BEGIN
            SET @sql = 'DROP LOGIN [' + @username + ']';
            EXEC (@sql);
        END
    END TRY
    BEGIN CATCH
        PRINT 'Lỗi khi xóa login/user: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- Khi cập nhật tài khoản
CREATE OR ALTER TRIGGER trg_UpdateSQLAccount
ON TaiKhoan
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @username NVARCHAR(50), @password NVARCHAR(50), @role NVARCHAR(50), @status BIT;
    SELECT TOP 1 @username = TenDangNhap, @password = MatKhau, @role = LoaiNguoiDung, @status = TrangThai
    FROM inserted;

    DECLARE @sql NVARCHAR(MAX);

    -- Đổi mật khẩu
    IF UPDATE(MatKhau)
    BEGIN
        SET @sql = 'ALTER LOGIN [' + @username + '] WITH PASSWORD = ''' + @password + ''', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;';
        EXEC (@sql);
    END

    -- Đổi role
    IF UPDATE(LoaiNguoiDung)
    BEGIN
        BEGIN TRY
            EXEC('ALTER ROLE [Admin] DROP MEMBER [' + @username + ']');
            EXEC('ALTER ROLE [QuanLyHocSinh] DROP MEMBER [' + @username + ']');
            EXEC('ALTER ROLE [GiaoVien] DROP MEMBER [' + @username + ']');
        END TRY BEGIN CATCH END CATCH;

        SET @sql = 'ALTER ROLE [' + @role + '] ADD MEMBER [' + @username + ']';
        EXEC (@sql);
    END

    -- Đổi trạng thái
    IF UPDATE(TrangThai)
    BEGIN
        IF @status = 0
            SET @sql = 'ALTER LOGIN [' + @username + '] DISABLE';
        ELSE
            SET @sql = 'ALTER LOGIN [' + @username + '] ENABLE';
        EXEC (@sql);
    END
END;
GO

/* ==========================================================
   4. Proc quản lý Role & User
   ========================================================== */

-- Gỡ toàn bộ user khỏi role
CREATE OR ALTER PROCEDURE sp_RemoveAllUsersFromRole
    @RoleName NVARCHAR(100)
AS
BEGIN
    DECLARE @username NVARCHAR(100), @sql NVARCHAR(MAX);
    DECLARE cur CURSOR FOR
    SELECT dp.name
    FROM sys.database_role_members drm
    JOIN sys.database_principals dp ON drm.member_principal_id = dp.principal_id
    WHERE drm.role_principal_id = USER_ID(@RoleName);

    OPEN cur; FETCH NEXT FROM cur INTO @username;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @sql = 'ALTER ROLE [' + @RoleName + '] DROP MEMBER [' + @username + ']';
        EXEC(@sql);
        FETCH NEXT FROM cur INTO @username;
    END
    CLOSE cur; DEALLOCATE cur;
END;
GO

-- Gán lại toàn bộ user vào role theo bảng TaiKhoan
CREATE OR ALTER PROCEDURE sp_AddUsersBackToRole
    @RoleName NVARCHAR(100)
AS
BEGIN
    DECLARE @username NVARCHAR(100), @sql NVARCHAR(MAX);
    DECLARE cur CURSOR FOR
    SELECT TenDangNhap FROM TaiKhoan WHERE LoaiNguoiDung = @RoleName AND TrangThai = 1;

    OPEN cur; FETCH NEXT FROM cur INTO @username;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @sql = 'ALTER ROLE [' + @RoleName + '] ADD MEMBER [' + @username + ']';
        EXEC(@sql);
        FETCH NEXT FROM cur INTO @username;
    END
    CLOSE cur; DEALLOCATE cur;
END;
GO

-- Cấp quyền cho user cụ thể
CREATE OR ALTER PROCEDURE sp_CapQuyenUser
    @UserName NVARCHAR(100),
    @ObjectName NVARCHAR(200),
    @Permission NVARCHAR(50)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'GRANT ' + @Permission + ' ON ' + @ObjectName + ' TO [' + @UserName + ']';
    EXEC (@sql);
END;
GO

-- Hủy quyền của user cụ thể
CREATE OR ALTER PROCEDURE sp_HuyQuyenUser
    @UserName NVARCHAR(100),
    @ObjectName NVARCHAR(200),
    @Permission NVARCHAR(50)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'REVOKE ' + @Permission + ' ON ' + @ObjectName + ' FROM [' + @UserName + ']';
    EXEC (@sql);
END;
GO

/* ==========================================================
   5. Proc đổi mật khẩu
   ========================================================== */

CREATE OR ALTER PROCEDURE sp_DoiMatKhauUser
    @UserName NVARCHAR(50),
    @NewPassword NVARCHAR(50)
WITH EXECUTE AS OWNER
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sql NVARCHAR(MAX);

    -- Đổi mật khẩu LOGIN
    IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @UserName)
    BEGIN
        SET @sql = 'ALTER LOGIN [' + @UserName + '] WITH PASSWORD = ''' + @NewPassword + ''', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;';
        EXEC(@sql);
    END

    -- Đồng bộ bảng TaiKhoan
    UPDATE TaiKhoan
    SET MatKhau = @NewPassword
    WHERE TenDangNhap = @UserName;
END;
GO
