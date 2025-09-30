using ProjectDBMS.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class FrmTaiKhoanEdit : Form
    {
        private readonly TaiKhoanRoleDAL dal = new TaiKhoanRoleDAL();
        private readonly int? taiKhoanID;

        public FrmTaiKhoanEdit(int? id = null, string ten = "", string mk = "", int roleID = 0, bool trangThai = true)
        {
            InitializeComponent();
            taiKhoanID = id;
            txtTenDangNhap.Text = ten;
            txtMatKhau.Text = mk;
            chkTrangThai.Checked = trangThai;

            LoadRole(roleID);
        }

        private void LoadRole(int selectedID = 0)
        {
            DataTable dt = dal.LayTatCaRole();
            cboRole.DataSource = dt;
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleID";
            if (selectedID > 0)
                cboRole.SelectedValue = selectedID;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            int roleID = Convert.ToInt32(cboRole.SelectedValue);
            bool trangThai = chkTrangThai.Checked;

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            if (taiKhoanID.HasValue)
            {
                dal.CapNhatTaiKhoan(taiKhoanID.Value, tenDangNhap, matKhau, roleID, trangThai);
                MessageBox.Show("Cập nhật thành công!");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    return;
                }
                dal.ThemTaiKhoan(tenDangNhap, matKhau, roleID, trangThai);
                MessageBox.Show("Thêm tài khoản thành công!");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
