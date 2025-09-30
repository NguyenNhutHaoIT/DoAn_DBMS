using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDBMS.DAL
{
    public class TaiKhoanRoleDAL
    {
        private readonly DBConnect db = new DBConnect();

        #region ===== TÀI KHOẢN =====

        // Lấy tất cả tài khoản
        public DataTable LayTatCaTaiKhoan()
        {
            return db.ExecuteProc("sp_LayTatCaTaiKhoan");
        }

        // Thêm tài khoản
        public int ThemTaiKhoan(string tenDangNhap, string matKhau, int roleID, bool trangThai)
        {
            var result = db.ExecuteProc("sp_ThemTaiKhoan",
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@RoleID", roleID),
                new SqlParameter("@TrangThai", trangThai ? 1 : 0)
            );

            if (result.Rows.Count > 0)
                return Convert.ToInt32(result.Rows[0]["NewTaiKhoanID"]);
            return 0;
        }

        // Cập nhật tài khoản
        public int CapNhatTaiKhoan(int taiKhoanID, string tenDangNhap, string matKhau, int roleID, bool trangThai)
        {
            var dt = db.ExecuteProc("sp_CapNhatTaiKhoan",
                new SqlParameter("@TaiKhoanID", taiKhoanID),
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@RoleID", roleID),
                new SqlParameter("@TrangThai", trangThai ? 1 : 0)
            );
            return (dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0]["RowAffected"]) : 0;
        }

        // Xóa tài khoản
        public int XoaTaiKhoan(int taiKhoanID)
        {
            var dt = db.ExecuteProc("sp_XoaTaiKhoan",
                new SqlParameter("@TaiKhoanID", taiKhoanID)
            );
            return (dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0]["RowAffected"]) : 0;
        }

        #endregion

        #region ===== ROLE =====

        // Lấy tất cả role
        public DataTable LayTatCaRole()
        {
            return db.ExecuteProc("sp_LayTatCaRole");
        }

        public void CapNhatTrangThaiRole(int roleID, bool trangThai)
        {
            db.ExecuteNonQuery("sp_CapNhatTrangThaiRole",
                new SqlParameter("@RoleID", roleID),
                new SqlParameter("@TrangThaiQuyen", trangThai));
        }


        // Gán role cho user
        public void GanRoleChoUser(string userName, string roleName)
        {
            db.ExecuteNonQuery("sp_GanRoleChoUser",
                new SqlParameter("@UserName", userName),
                new SqlParameter("@RoleName", roleName));
        }

        // Hủy role của user
        public void HuyRoleCuaUser(string userName, string roleName)
        {
            db.ExecuteNonQuery("sp_HuyRoleCuaUser",
                new SqlParameter("@UserName", userName),
                new SqlParameter("@RoleName", roleName));
        }

        #endregion
    }
}
