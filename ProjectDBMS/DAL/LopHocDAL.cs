using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDBMS.DAL
{
    public class LopHocDAL
    {
        private readonly DBConnect db = new DBConnect();

        // 🔹 Lấy tất cả lớp (lọc theo DaKetThuc)
        public DataTable LayTatCaLop(bool baoGomDaKetThuc)
        {
            try
            {
                return db.ExecuteProc("sp_LayTatCaLop_Filter",
                    new SqlParameter("@BaoGomDaKetThuc", baoGomDaKetThuc ? 1 : 0));
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lớp: " + ex.Message, ex);
            }
        }

        // 🔹 Thêm lớp mới → trả về ID mới
        public int ThemLop(string tenLop, byte khoiHoc, byte hocKy, short namHoc)
        {
            try
            {
                var dt = db.ExecuteProc("sp_ThemLop",
                    new SqlParameter("@TenLop", tenLop),
                    new SqlParameter("@KhoiHoc", khoiHoc),
                    new SqlParameter("@HocKy", hocKy),
                    new SqlParameter("@NamHoc", namHoc));

                if (dt.Rows.Count > 0 && dt.Columns.Contains("NewLopHocID"))
                    return Convert.ToInt32(dt.Rows[0]["NewLopHocID"]);

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm lớp: " + ex.Message, ex);
            }
        }

        // 🔹 Cập nhật lớp → trả về số dòng bị ảnh hưởng
        public int CapNhatLop(int lopHocID, string tenLop, byte khoiHoc, byte hocKy, short namHoc, bool daKetThuc)
        {
            try
            {
                var dt = db.ExecuteProc("sp_CapNhatLop",
                    new SqlParameter("@LopHocID", lopHocID),
                    new SqlParameter("@TenLop", tenLop),
                    new SqlParameter("@KhoiHoc", khoiHoc),
                    new SqlParameter("@HocKy", hocKy),
                    new SqlParameter("@NamHoc", namHoc),
                    new SqlParameter("@DaKetThuc", daKetThuc));

                if (dt.Rows.Count > 0 && dt.Columns.Contains("RowAffected"))
                    return Convert.ToInt32(dt.Rows[0]["RowAffected"]);

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật lớp: " + ex.Message, ex);
            }
        }

        // 🔹 Xóa lớp → trả về số dòng bị ảnh hưởng
        public int XoaLop(int lopHocID)
        {
            try
            {
                var dt = db.ExecuteProc("sp_XoaLop",
                    new SqlParameter("@LopHocID", lopHocID));

                if (dt.Rows.Count > 0 && dt.Columns.Contains("RowAffected"))
                    return Convert.ToInt32(dt.Rows[0]["RowAffected"]);

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa lớp: " + ex.Message, ex);
            }
        }
    }
}
