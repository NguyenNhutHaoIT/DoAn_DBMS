using ProjectDBMS.DAL;
using System;
using System.Windows.Forms;

namespace ProjectDBMS.UI.Forms
{
    public partial class FrmGiaoVienEdit : Form
    {
        private readonly GiaoVienDAL dal = new GiaoVienDAL();
        private readonly int? giaoVienID;

        public FrmGiaoVienEdit(int? id = null)
        {
            InitializeComponent();
            giaoVienID = id;
            LoadComboBox();
            if (giaoVienID.HasValue)
                LoadGiaoVien();
        }

        private void LoadComboBox()
        {
            cboGioiTinh.Items.AddRange(new object[] { "Nữ", "Nam", "Khác" });
            cboTrangThai.Items.AddRange(new object[] { "Nghỉ", "Đang làm", "Khác" });
        }

        private void LoadGiaoVien()
        {
            var dt = dal.TimKiemGiaoVien(""); // load toàn bộ
            var row = dt.Select($"GiaoVienID={giaoVienID.Value}");
            if (row.Length == 0) return;

            var r = row[0];
            txtHoTen.Text = r["HoTen"].ToString();
            dtpNgaySinh.Value = DateTime.Parse(r["NgaySinh"].ToString());
            cboGioiTinh.SelectedItem = r["GioiTinh"].ToString();
            cboTrangThai.SelectedItem = r["TrangThai"].ToString();
            txtLoaiNV.Text = r["LoaiNV"].ToString();
            chkLaTuyenMoi.Checked = r["LaTuyenMoi"].ToString() == "Có";
            txtCMND.Text = r["CMND_CCCD"].ToString();
            txtSoDinhDanh.Text = r["SoDinhDanhCaNhan"].ToString();
            txtEmail.Text = r["Email"].ToString();
            txtDienThoai.Text = r["DienThoai"].ToString();
            txtDanToc.Text = r["DanToc"].ToString();
            txtTonGiao.Text = r["TonGiao"].ToString();
            chkLaDoanVien.Checked = r["LaDoanVien"].ToString() == "Có";
            chkLaDangVien.Checked = r["LaDangVien"].ToString() == "Có";
            txtSoSoBHXH.Text = r["SoSoBHXH"].ToString();
            txtNoiThuongTru.Text = r["NoiThuongTru"].ToString();
            txtQueQuan.Text = r["QueQuan"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int gioiTinh = cboGioiTinh.SelectedIndex;
                int trangThai = cboTrangThai.SelectedIndex;

                if (giaoVienID.HasValue)
                {
                    dal.CapNhatGiaoVien(giaoVienID.Value, txtHoTen.Text, dtpNgaySinh.Value, gioiTinh, trangThai,
                        txtLoaiNV.Text, chkLaTuyenMoi.Checked, txtCMND.Text, txtSoDinhDanh.Text, txtEmail.Text,
                        txtDienThoai.Text, txtDanToc.Text, txtTonGiao.Text, chkLaDoanVien.Checked, chkLaDangVien.Checked,
                        txtSoSoBHXH.Text, txtNoiThuongTru.Text, txtQueQuan.Text);
                }
                else
                {
                    dal.ThemGiaoVien(txtHoTen.Text, dtpNgaySinh.Value, gioiTinh, trangThai,
                        txtLoaiNV.Text, chkLaTuyenMoi.Checked, txtCMND.Text, txtSoDinhDanh.Text, txtEmail.Text,
                        txtDienThoai.Text, txtDanToc.Text, txtTonGiao.Text, chkLaDoanVien.Checked, chkLaDangVien.Checked,
                        txtSoSoBHXH.Text, txtNoiThuongTru.Text, txtQueQuan.Text);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
