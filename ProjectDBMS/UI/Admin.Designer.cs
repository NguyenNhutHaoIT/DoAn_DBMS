namespace ProjectDBMS.UI
{
    partial class Admin
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel sidebar;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Button btnGiaoVien;
        private Guna.UI2.WinForms.Guna2Button btnLopHoc;
        private Guna.UI2.WinForms.Guna2Button btnMonHoc;
        private Guna.UI2.WinForms.Guna2Button btnPhanCong;
        private Guna.UI2.WinForms.Guna2Button btnDanhSachTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDanhSachTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhanCong = new Guna.UI2.WinForms.Guna2Button();
            this.btnMonHoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnLopHoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiaoVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.sidebar.Controls.Add(this.btnDanhSachTaiKhoan);
            this.sidebar.Controls.Add(this.btnPhanCong);
            this.sidebar.Controls.Add(this.btnMonHoc);
            this.sidebar.Controls.Add(this.btnLopHoc);
            this.sidebar.Controls.Add(this.btnGiaoVien);
            this.sidebar.Controls.Add(this.btnTaiKhoan);
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(220, 741);
            this.sidebar.TabIndex = 0;
            // 
            // btnDanhSachTaiKhoan
            // 
            this.btnDanhSachTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhSachTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDanhSachTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDanhSachTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachTaiKhoan.Location = new System.Drawing.Point(0, 180);
            this.btnDanhSachTaiKhoan.Name = "btnDanhSachTaiKhoan";
            this.btnDanhSachTaiKhoan.Size = new System.Drawing.Size(220, 45);
            this.btnDanhSachTaiKhoan.TabIndex = 0;
            this.btnDanhSachTaiKhoan.Text = "Danh sách tài khoản";
            this.btnDanhSachTaiKhoan.Click += new System.EventHandler(this.btnDanhSachTaiKhoan_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhanCong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(0, 135);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(220, 45);
            this.btnPhanCong.TabIndex = 2;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMonHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMonHoc.ForeColor = System.Drawing.Color.White;
            this.btnMonHoc.Location = new System.Drawing.Point(0, 90);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Size = new System.Drawing.Size(220, 45);
            this.btnMonHoc.TabIndex = 3;
            this.btnMonHoc.Text = "Môn học";
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLopHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLopHoc.ForeColor = System.Drawing.Color.White;
            this.btnLopHoc.Location = new System.Drawing.Point(0, 45);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Size = new System.Drawing.Size(220, 45);
            this.btnLopHoc.TabIndex = 4;
            this.btnLopHoc.Text = "Lớp học";
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGiaoVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGiaoVien.ForeColor = System.Drawing.Color.White;
            this.btnGiaoVien.Location = new System.Drawing.Point(0, 0);
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.Size = new System.Drawing.Size(220, 45);
            this.btnGiaoVien.TabIndex = 5;
            this.btnGiaoVien.Text = "Giáo viên";
            this.btnGiaoVien.Click += new System.EventHandler(this.btnGiaoVien_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 651);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(220, 45);
            this.btnTaiKhoan.TabIndex = 8;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 696);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(220, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1106, 741);
            this.mainPanel.TabIndex = 1;
            // 
            // Admin
            // 
            this.ClientSize = new System.Drawing.Size(1326, 741);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Quản Lý Trường Học";
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
