using ProjectDBMS.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class TaiKhoanRoleControl : UserControl
    {
        private readonly TaiKhoanRoleDAL dal = new TaiKhoanRoleDAL();

        public TaiKhoanRoleControl()
        {
            InitializeComponent();
        }

        private void TaiKhoanRoleControl_Load(object sender, EventArgs e)
        {
            LoadTaiKhoan();
            LoadRole();
        }

        // =================== TÀI KHOẢN ===================
        private void LoadTaiKhoan()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();

            // Ẩn ID
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TaiKhoanID",
                HeaderText = "ID",
                Visible = false
            });

            // Tên đăng nhập
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Role
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoleName",
                HeaderText = "Role",
                Width = 150
            });

            // Trạng thái
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThaiText",
                HeaderText = "Trạng thái",
                Width = 120
            });

            dgvTaiKhoan.DataSource = dal.LayTatCaTaiKhoan();
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            var frm = new FrmTaiKhoanEdit();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadTaiKhoan();
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["TaiKhoanID"].Value);
                var frm = new FrmTaiKhoanEdit(id);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadTaiKhoan();
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["TaiKhoanID"].Value);
                if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dal.XoaTaiKhoan(id);
                    LoadTaiKhoan();
                }
            }
        }

        // =================== ROLE ===================
        private void LoadRole()
        {
            dgvRole.AutoGenerateColumns = false;
            dgvRole.Columns.Clear();

            // Ẩn RoleID
            dgvRole.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoleID",
                HeaderText = "ID",
                Visible = false
            });

            // Tên Role
            dgvRole.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoleName",
                HeaderText = "Tên Role",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Mô tả
            dgvRole.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô tả",
                Width = 200
            });

            // CheckBox bật/tắt quyền
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "TrangThaiQuyen",
                HeaderText = "Bật quyền",
                Width = 100
            };
            dgvRole.Columns.Add(chk);

            dgvRole.DataSource = dal.LayTatCaRole();
        }

        private void dgvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRole.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int roleID = Convert.ToInt32(dgvRole.Rows[e.RowIndex].Cells["RoleID"].Value);
                bool trangThai = Convert.ToBoolean(dgvRole.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);

                dal.CapNhatTrangThaiRole(roleID, trangThai);
                LoadRole();
            }
        }
    }
}
