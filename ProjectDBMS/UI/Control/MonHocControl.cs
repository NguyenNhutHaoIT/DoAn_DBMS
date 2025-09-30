using ProjectDBMS.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class MonHocControl : UserControl
    {
        private readonly MonHocDAL dal = new MonHocDAL();

        public MonHocControl()
        {
            InitializeComponent();
            LoadMonHoc();
        }

        private void LoadMonHoc()
        {
            try
            {
                DataTable dt = dal.LayDanhSachMonHoc();
                dgvMonHoc.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load môn học: " + ex.Message);
            }
        }
    }
}
