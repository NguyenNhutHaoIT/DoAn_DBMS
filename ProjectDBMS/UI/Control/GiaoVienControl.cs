using ProjectDBMS.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using ProjectDBMS.UI.Forms;

namespace ProjectDBMS.UI
{
    public partial class GiaoVienControl : UserControl
    {
        private readonly GiaoVienDAL dal = new GiaoVienDAL();

        public GiaoVienControl()
        {
            InitializeComponent();
            LoadGiaoVien();
        }

        private void LoadGiaoVien()
        {
            dgvGiaoVien.DataSource = dal.LayTatCaGiaoVien();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGiaoVien();
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvGiaoVien.DataSource = dal.TimKiemGiaoVien(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmGiaoVienEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGiaoVien();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvGiaoVien.CurrentRow.Cells["GiaoVienID"].Value);
            using (var frm = new FrmGiaoVienEdit(id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGiaoVien();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvGiaoVien.CurrentRow.Cells["GiaoVienID"].Value);
            if (MessageBox.Show("Bạn có chắc muốn xóa giáo viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal.XoaGiaoVien(id);
                    LoadGiaoVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
