using ProjectDBMS.DAL;
using System;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class PhanCongControl : UserControl
    {
        private readonly PhanCongDAL dal = new PhanCongDAL();

        public PhanCongControl()
        {
            InitializeComponent();
            LoadPhanCong();
        }

        private void LoadPhanCong()
        {
            try
            {
                dgvPhanCong.DataSource = dal.LayDanhSachPhanCong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phân công: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FrmPhanCongEdit();
            
                LoadPhanCong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhanCong.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvPhanCong.CurrentRow.Cells["PhanCongID"].Value);
            var frm = new FrmPhanCongEdit(id);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadPhanCong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhanCong.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvPhanCong.CurrentRow.Cells["PhanCongID"].Value);
            if (MessageBox.Show("Xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dal.XoaPhanCong(id);
                LoadPhanCong();
            }
        }
    }
}
