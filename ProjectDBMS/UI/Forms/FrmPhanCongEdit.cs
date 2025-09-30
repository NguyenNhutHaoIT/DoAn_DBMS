using ProjectDBMS.DAL;
using System;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class FrmPhanCongEdit : Form
    {
        private readonly PhanCongDAL dal = new PhanCongDAL();
        private readonly int? phanCongID;

        public FrmPhanCongEdit(int? id = null)
        {
            InitializeComponent();
            phanCongID = id;
            LoadCombos();

            if (phanCongID.HasValue)
                LoadData();
        }

        private void LoadCombos()
        {
            cboGiaoVien.DataSource = dal.LayTatCaGiaoVien();
            cboGiaoVien.DisplayMember = "HoTen";
            cboGiaoVien.ValueMember = "GiaoVienID";

            cboLop.DataSource = dal.LayTatCaLop(false);
            cboLop.DisplayMember = "TenLopHocKy";
            cboLop.ValueMember = "LopHocID";

            cboMon.DataSource = dal.LayTatCaMonHoc();
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MonHocID";
        }

        private void LoadData()
        {
            var dt = dal.LayDanhSachPhanCong();
            var row = dt.Select($"PhanCongID = {phanCongID.Value}");
            if (row.Length > 0)
            {
                cboGiaoVien.SelectedValue = row[0]["GiaoVienID"];
                cboLop.SelectedValue = row[0]["LopHocID"];
                cboMon.SelectedValue = row[0]["MonHocID"];
                txtSoTiet.Text = row[0]["SoTiet"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int gv = Convert.ToInt32(cboGiaoVien.SelectedValue);
            int lop = Convert.ToInt32(cboLop.SelectedValue);
            int mon = Convert.ToInt32(cboMon.SelectedValue);
            int soTiet = Convert.ToInt32(txtSoTiet.Text);

            if (phanCongID.HasValue)
                dal.CapNhatPhanCong(phanCongID.Value, gv, lop, mon, soTiet);
            else
                dal.ThemPhanCong(gv, lop, mon, soTiet);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
