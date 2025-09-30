using ProjectDBMS.DAL;
using System;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class FrmLopEdit : Form
    {
        private readonly LopHocDAL dal = new LopHocDAL();
        private readonly int? lopHocID; // null = thêm mới

        public FrmLopEdit(int lopHocID = 0, string tenLop = "", byte khoiHoc = 1, byte hocKy = 1, short namHoc = 2025, bool daKetThuc = false)
        {
            InitializeComponent();
            if (lopHocID > 0)
            {
                this.lopHocID = lopHocID;
                txtTenLop.Text = tenLop;
                numKhoi.Value = khoiHoc;
                numHocKy.Value = hocKy;
                numNamHoc.Value = namHoc;
                chkDaKetThuc.Checked = daKetThuc;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text.Trim();
            byte khoiHoc = (byte)numKhoi.Value;
            byte hocKy = (byte)numHocKy.Value;
            short namHoc = (short)numNamHoc.Value;
            bool daKetThuc = chkDaKetThuc.Checked;

            if (lopHocID == null)
                dal.ThemLop(tenLop, khoiHoc, hocKy, namHoc);
            else
                dal.CapNhatLop(lopHocID.Value, tenLop, khoiHoc, hocKy, namHoc, daKetThuc);

            DialogResult = DialogResult.OK;
        }
    }
}
