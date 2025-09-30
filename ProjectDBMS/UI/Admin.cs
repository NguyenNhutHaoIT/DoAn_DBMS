
using ProjectDBMS.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMS.UI
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            DAL.DBConnect.Initialize("sa", "123"); 
 
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
                    }

        private void btnHocSinh_Click(object sender, EventArgs e)
        { 
            
        }


        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
              LoadContent(new GiaoVienControl());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // hoặc mở form Login
        }

        private void LoadContent(Control control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }
        private void btnDiemSo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            LoadContent(new MonHocControl());
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            LoadContent(new PhanCongControl());
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            LoadContent(new LopHocControl());
        }

        private void btnDanhSachTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadContent(new TaiKhoanRoleControl());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
