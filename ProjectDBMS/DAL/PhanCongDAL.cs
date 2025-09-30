using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDBMS.DAL
{
    public class PhanCongDAL
    {
        private readonly DBConnect db = new DBConnect();

        public DataTable LayDanhSachPhanCong()
            => db.GetData("SELECT * FROM vw_DanhSachPhanCong");

        public DataTable LayTatCaGiaoVien()
            => db.GetData("SELECT * FROM vw_DanhSachGiaoVien");

        public DataTable LayTatCaMonHoc()
            => db.GetData("SELECT * FROM vw_DanhSachMonHoc");

        public DataTable LayTatCaLop(bool baoGomDaKetThuc = false)
            => db.ExecuteProc("sp_LayTatCaLop_Filter",
                new SqlParameter("@BaoGomDaKetThuc", baoGomDaKetThuc ? 1 : 0));

        public int ThemPhanCong(int giaoVienID, int lopHocID, int monHocID, int soTiet)
            => db.ExecuteNonQuery("sp_ThemPhanCong",
                new SqlParameter("@GiaoVienID", giaoVienID),
                new SqlParameter("@LopHocID", lopHocID),
                new SqlParameter("@MonHocID", monHocID),
                new SqlParameter("@SoTiet", soTiet));

        public int CapNhatPhanCong(int phanCongID, int giaoVienID, int lopHocID, int monHocID, int soTiet)
            => db.ExecuteNonQuery("sp_CapNhatPhanCong",
                new SqlParameter("@PhanCongID", phanCongID),
                new SqlParameter("@GiaoVienID", giaoVienID),
                new SqlParameter("@LopHocID", lopHocID),
                new SqlParameter("@MonHocID", monHocID),
                new SqlParameter("@SoTiet", soTiet));

        public int XoaPhanCong(int phanCongID)
            => db.ExecuteNonQuery("sp_XoaPhanCong",
                new SqlParameter("@PhanCongID", phanCongID));
    }
}
