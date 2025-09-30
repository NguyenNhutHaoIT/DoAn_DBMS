using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDBMS.DAL
{
    public class GiaoVienDAL
    {
        private readonly DBConnect db = new DBConnect();

        // Lấy danh sách giáo viên
        public DataTable LayTatCaGiaoVien()
        {
            return db.GetData("SELECT * FROM vw_GiaoVienInfo");
        }

        // Thêm giáo viên
        public int ThemGiaoVien(string hoTen, DateTime ngaySinh, int gioiTinh, int trangThai, string loaiNV,
                                bool laTuyenMoi, string cmnd, string soDinhDanh, string email, string dienThoai,
                                string danToc, string tonGiao, bool laDoanVien, bool laDangVien,
                                string soSoBHXH, string noiThuongTru, string queQuan)
        {
            return db.ExecuteNonQuery("InsertGiaoVien",
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@LoaiNV", loaiNV),
                new SqlParameter("@LaTuyenMoi", laTuyenMoi),
                new SqlParameter("@CMND_CCCD", cmnd),
                new SqlParameter("@SoDinhDanhCaNhan", soDinhDanh),
                new SqlParameter("@Email", email),
                new SqlParameter("@DienThoai", dienThoai),
                new SqlParameter("@DanToc", danToc),
                new SqlParameter("@TonGiao", tonGiao),
                new SqlParameter("@LaDoanVien", laDoanVien),
                new SqlParameter("@LaDangVien", laDangVien),
                new SqlParameter("@SoSoBHXH", soSoBHXH),
                new SqlParameter("@NoiThuongTru", noiThuongTru),
                new SqlParameter("@QueQuan", queQuan));
        }

        // Cập nhật giáo viên
        public int CapNhatGiaoVien(int giaoVienID, string hoTen, DateTime ngaySinh, int gioiTinh, int trangThai, string loaiNV,
                                   bool laTuyenMoi, string cmnd, string soDinhDanh, string email, string dienThoai,
                                   string danToc, string tonGiao, bool laDoanVien, bool laDangVien,
                                   string soSoBHXH, string noiThuongTru, string queQuan)
        {
            return db.ExecuteNonQuery("UpdateGiaoVien",
                new SqlParameter("@GiaoVienID", giaoVienID),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@LoaiNV", loaiNV),
                new SqlParameter("@LaTuyenMoi", laTuyenMoi),
                new SqlParameter("@CMND_CCCD", cmnd),
                new SqlParameter("@SoDinhDanhCaNhan", soDinhDanh),
                new SqlParameter("@Email", email),
                new SqlParameter("@DienThoai", dienThoai),
                new SqlParameter("@DanToc", danToc),
                new SqlParameter("@TonGiao", tonGiao),
                new SqlParameter("@LaDoanVien", laDoanVien),
                new SqlParameter("@LaDangVien", laDangVien),
                new SqlParameter("@SoSoBHXH", soSoBHXH),
                new SqlParameter("@NoiThuongTru", noiThuongTru),
                new SqlParameter("@QueQuan", queQuan));
        }

        // Xóa giáo viên
        public int XoaGiaoVien(int giaoVienID)
        {
            return db.ExecuteNonQuery("DeleteGiaoVien",
                new SqlParameter("@GiaoVienID", giaoVienID));
        }

        // Tìm kiếm giáo viên
        public DataTable TimKiemGiaoVien(string keyword)
        {
            return db.GetData("SearchGiaoVien",
                new SqlParameter("@Keyword", keyword));
        }
    }
}
