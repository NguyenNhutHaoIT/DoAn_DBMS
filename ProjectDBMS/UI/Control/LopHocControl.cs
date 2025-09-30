using System;
using System.Data;
using System.Windows.Forms;
using ProjectDBMS.DAL;

namespace ProjectDBMS.UI
{
    public partial class LopHocControl : UserControl
    {
        private readonly LopHocDAL dal = new LopHocDAL();

        public LopHocControl()
        {
            InitializeComponent();

            // Gắn sự kiện
            this.chkShowAll.CheckedChanged += ChkShowAll_CheckedChanged;
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;

            LoadData();
        }

        private void LoadData()
        {
            bool showAll = chkShowAll.Checked;
            DataTable dt = dal.LayTatCaLop(showAll);
            dgvLop.DataSource = dt;
        }

        private void ChkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            var frm = new FrmLopEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null) return;

            int lopHocID = Convert.ToInt32(dgvLop.CurrentRow.Cells["LopHocID"].Value);
            string tenLop = dgvLop.CurrentRow.Cells["TenLopHocKy"].Value.ToString();
            byte daKetThuc = Convert.ToByte(dgvLop.CurrentRow.Cells["DaKetThuc"].Value);

            var frm = new FrmLopEdit(lopHocID, tenLop, daKetThuc);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null) return;

            int lopHocID = Convert.ToInt32(dgvLop.CurrentRow.Cells["LopHocID"].Value);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dal.XoaLop(lopHocID);
                LoadData();
            }
        }
    }
}
