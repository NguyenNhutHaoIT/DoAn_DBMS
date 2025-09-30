using System.Data;

namespace ProjectDBMS.DAL
{
    public class MonHocDAL
    {
        private readonly DBConnect db = new DBConnect();

        public DataTable LayDanhSachMonHoc()
        {
            return db.GetData("SELECT * FROM vw_DanhSachMonHoc");
        }
    }
}
